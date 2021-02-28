using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Index(nameof(Deleted), nameof(CreatedDate))]
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ID { get; set; }

        public bool Deleted { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
    }
}
