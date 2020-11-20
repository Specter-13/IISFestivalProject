using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FestivalProject.DAL.Entities;

namespace FestivalProject.BL.Models.UserDto
{
    public class UserAuthenticateDto : EntityBase
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; } // mozno pozuzit nejaky hash na heslo
    }
}
