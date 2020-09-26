using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloadBerry.Models.DTO
{
    public class UserRegisterDTO
    {
        [Required(ErrorMessage ="Email boş geçilemez")]
        public string Mail { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required(ErrorMessage = "şifre boş geçilemez")]

        public string Password { get; set; }
    }
}
