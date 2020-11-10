using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FestivalProject.DAL.Repositories
{
    public class FestivalRepository : IGenericCrudOperations<FestivalEntity>
    {
        private readonly FestivalDbContext _dbContext;
        public FestivalRepository(FestivalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<FestivalEntity> GetAll()
        {
            return _dbContext.Festivals
                .Include(entity => entity.FestivalInterpret)
                .Include(entity => entity.StageList)
                .ToList();
        }

        public FestivalEntity GetById(Guid id)
        {
            return _dbContext.Festivals.Include(x => x.StageList)
                .ThenInclude(x => x.StageInterpret)
                .Include(x => x.FestivalInterpret)
                .ThenInclude(x => x.Interpret)
                .First(x => x.Id == id);
        }

        public FestivalEntity Create(FestivalEntity item)
        {
            _dbContext.Festivals.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public FestivalEntity Update(FestivalEntity item)
        {
            _dbContext.Festivals.Update(item);
            _dbContext.SaveChanges();
            return item;
        }

        public void Delete(Guid id)
        {
            var entity = _dbContext.Festivals.First(t => t.Id == id);
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
