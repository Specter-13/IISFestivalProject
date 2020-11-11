using System;
using System.Collections.Generic;
using System.Text;
using FestivalProject.DAL.Entities;

namespace FestivalProject.BL.Models.UserDto
{
    public class UserAuthenticateDto : EntityBase
    {
        public string Username { get; set; }
        public string Password { get; set; } // mozno pozuzit nejaky hash na heslo
    }
}
