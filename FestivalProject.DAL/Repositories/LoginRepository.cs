using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FestivalProject.DAL.Repositories
{
    public class LoginRepository: IGenericCrudOperations<LoginEntity>
    {
        private readonly FestivalDbContext _dbContext;

        public LoginRepository(FestivalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<LoginEntity> GetAll()
        {
            return _dbContext.Logins
                .ToList();
        }

        public LoginEntity GetById(Guid id)
        {
            return _dbContext.Logins
                .First(x => x.Id == id);
        }
        public LoginEntity GetByUsername(string name)
        {
            return _dbContext.Logins
                .First(x => x.Username == name);
        }

        public LoginEntity Create(LoginEntity item)
        {
            _dbContext.Logins.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public LoginEntity Update(LoginEntity item)
        {
            _dbContext.Logins.Update(item);
            _dbContext.SaveChanges();
            return item;
        }

        public void Delete(Guid id)
        {
            var entity = _dbContext.Logins.First(t => t.Id == id);
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
