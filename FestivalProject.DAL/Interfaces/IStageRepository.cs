using System;
using System.Collections.Generic;
using System.Text;
using FestivalProject.DAL.Entities;

namespace FestivalProject.DAL.Interfaces
{
    public interface IStageRepository
    {
        StageEntity Create(StageEntity stage);
        StageEntity Update(StageEntity stage);
        void Delete(StageEntity stage);
    }
}
