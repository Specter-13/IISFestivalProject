using System;
using System.Collections.Generic;
using System.Text;
using FestivalProject.DAL.Entities;

namespace FestivalProject.DAL.Interfaces
{
    public interface ILoginRepository
    {
        LoginEntity GetByUserName(string userName);
        LoginEntity Create(LoginEntity login);
        LoginEntity Update(LoginEntity login);
        void Delete(LoginEntity login);
    }
}
