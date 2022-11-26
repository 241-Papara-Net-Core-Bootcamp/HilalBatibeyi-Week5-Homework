using System.ComponentModel.DataAnnotations.Schema;

namespace Papara.Core.Entites
{
    [Table("Users")]
    public class User : BaseEntity
    {
        public string UserId { get; set; }

        public string Title { get; set; }
        
        public string Body { get; set; }
    }
}
