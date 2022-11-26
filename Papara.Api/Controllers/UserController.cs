using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Papara.Core.Entites;
using Papara.Core.Enums;
using Papara.Core.Interfaces;
using Papara.DataAccess.Abstract;
using Papara.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Papara.Api.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly Func<CacheTech, ICacheService> _cacheService;
        private IMapper _mapper;

        public UserController(IUserRepository repository, Func<CacheTech, ICacheService> cacheService, IMapper mapper)
        {
            _repository = repository;
            _cacheService = cacheService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task GetDataFromApi()

        {
            HttpWebRequest httpWeb = (HttpWebRequest)WebRequest.Create("https://jsonplaceholder.typicode.com/posts ");
            httpWeb.Method = "GET";

            HttpWebResponse webResponse = (HttpWebResponse)httpWeb.GetResponse();
            Console.WriteLine(webResponse.StatusCode);
            Console.WriteLine(webResponse.Server);

            string Json;
            using (Stream stream = webResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                Json = reader.ReadToEnd();
            }
            List<UserDTO> items = (List<UserDTO>)JsonConvert.DeserializeObject(Json, typeof(List<UserDTO>));
            var mapp = _mapper.Map<List<User>>(items);
            foreach (var item in mapp)
            {
                await _repository.AddAsync(item);
            }

            Console.WriteLine(items);
        }

        [HttpPost]
        public IActionResult Post()
        {
            RecurringJob.AddOrUpdate(() => GetDataFromApi(), "*/5 * * * * *");
            return Ok();
        }
    }
}
