using System;
using System.Collections.Generic;
using System.Text;
using FestivalProject.DAL.Entities;

namespace FestivalProject.DAL.Interfaces
{
    public interface IUserRepository
    {
        IList<UserEntity> GetAll();
        UserEntity GetById(Guid id);
        UserEntity Create(UserEntity user);
        UserEntity Update(UserEntity user);
        void Delete(UserEntity user);
    }
}
