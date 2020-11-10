using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FestivalProject.DAL.Repositories
{
    public class UserRepository : IGenericCrudOperations<UserEntity>
    {
        private readonly FestivalDbContext _dbContext;

        public UserRepository(FestivalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<UserEntity> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public UserEntity GetById(Guid id)
        {
            return _dbContext.Users.Include(x => x.ReservationList)
                .ThenInclude(x => x.Festival)
                .First(x => x.Id == id);
        }

        public UserEntity Create(UserEntity item)
        {
            _dbContext.Users.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public UserEntity Update(UserEntity item)
        {
            _dbContext.Users.Update(item);
            _dbContext.SaveChanges();
            return item;
        }

        public void Delete(Guid id)
        {
            var entity = _dbContext.Users.First(t => t.Id == id);
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
