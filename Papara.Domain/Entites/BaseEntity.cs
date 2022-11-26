using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papara.Core.Entites
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastUpdatAt { get; set; }
    }
}
