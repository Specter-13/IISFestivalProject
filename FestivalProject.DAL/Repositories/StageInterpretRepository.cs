using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Interfaces;

namespace FestivalProject.DAL.Repositories
{
    public class StageInterpretRepository : IGenericBindingTablesOperations<StageInterpretEntity>
    {
        private readonly FestivalDbContext _dbContext;

        public StageInterpretRepository(FestivalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public StageInterpretEntity Create(StageInterpretEntity item)
        {
            _dbContext.StageInterprets.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public StageInterpretEntity Update(StageInterpretEntity item)
        {
            _dbContext.StageInterprets.Update(item);
            _dbContext.SaveChanges();
            return item;
        }

        public void Delete(Guid id)
        {
            var entity = _dbContext.StageInterprets.First(t => t.Id == id);
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
