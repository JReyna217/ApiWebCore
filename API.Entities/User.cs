using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    [Index(nameof(Email))]
    public class User : BaseEntity
    {
        [StringLength(50, ErrorMessage ="Max Length {1}")]
        public string FullName { get; set; }
        [StringLength(50, ErrorMessage = "Max Length {1}")]
        public string Email { get; set; }
        [StringLength(50, ErrorMessage = "Max Length {1}")]
        public string UserName { get; set; }
        [StringLength(50, ErrorMessage = "Max Length {1}")]
        public string Password { get; set; }
    }
}
