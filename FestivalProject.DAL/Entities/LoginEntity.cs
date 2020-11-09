using System;
using System.Collections.Generic;
using System.Text;


namespace FestivalProject.DAL.Entities
{
    public class LoginEntity: EntityBase
    {
        
        public string Username { get; set; }
        public string Password { get; set; } // mozno pozuzit nejaky hash na heslo
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
