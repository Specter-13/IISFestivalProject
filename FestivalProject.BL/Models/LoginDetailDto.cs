using System;
using FestivalProject.BL.Models.UserDto;
using FestivalProject.DAL.Entities;

namespace FestivalProject.BL.Models
{
    public class LoginDetailDto: EntityBase
    {
        
        public string Username { get; set; }
        public string Password { get; set; } // mozno pozuzit nejaky hash na heslo
        public Guid UserId { get; set; }
    }
}
