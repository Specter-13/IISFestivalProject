using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Interfaces;

namespace FestivalProject.DAL.Repositories
{
    public class ReservationRepository : IGenericCrudOperations<ReservationEntity>
    {
        private readonly FestivalDbContext _dbContext;

        public ReservationRepository(FestivalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<ReservationEntity> GetAll()
        {
            return _dbContext.Reservations.ToList();
        }

        public ReservationEntity GetById(Guid id)
        {
            return _dbContext.Reservations.First(x => x.Id == id);
        }

        public ReservationEntity Create(ReservationEntity item)
        {
            _dbContext.Reservations.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public ReservationEntity Update(ReservationEntity item)
        {
            _dbContext.Reservations.Update(item);
            _dbContext.SaveChanges();
            return item;
        }

        public void Delete(Guid id)
        {
            var entity = _dbContext.Reservations.First(t => t.Id == id);
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
