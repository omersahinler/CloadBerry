using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloadBerry.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
