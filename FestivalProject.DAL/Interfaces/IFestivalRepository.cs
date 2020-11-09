using System;
using System.Collections.Generic;
using System.Text;
using FestivalProject.DAL.Entities;

namespace FestivalProject.DAL.Interfaces
{
    public interface IFestivalRepository
    {
        IList<FestivalEntity> GetAll();
        FestivalEntity GetById(Guid Id);
        FestivalEntity Create(FestivalEntity festival);
        FestivalEntity Update(FestivalEntity festival);
        void Delete(FestivalEntity festival);
    }
}
