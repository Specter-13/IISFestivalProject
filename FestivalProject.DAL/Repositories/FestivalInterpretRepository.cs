using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Interfaces;

namespace FestivalProject.DAL.Repositories
{
    public class FestivalInterpretRepository : IGenericBindingTablesOperations<FestivalInterpretEntity>
    {
        private readonly FestivalDbContext _dbContext;

        public FestivalInterpretRepository(FestivalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public FestivalInterpretEntity Create(FestivalInterpretEntity item)
        {
            _dbContext.FestivalInterprets.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public FestivalInterpretEntity Update(FestivalInterpretEntity item)
        {
            _dbContext.FestivalInterprets.Update(item);
            _dbContext.SaveChanges();
            return item;
        }

        public void Delete(Guid id)
        {
            var entity = _dbContext.FestivalInterprets.First(t => t.Id == id);
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
