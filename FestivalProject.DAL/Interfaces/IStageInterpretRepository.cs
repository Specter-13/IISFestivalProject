using System;
using System.Collections.Generic;
using System.Text;
using FestivalProject.DAL.Entities;

namespace FestivalProject.DAL.Interfaces
{
    public interface IStageInterpretRepository
    {
        StageInterpretEntity Create(StageInterpretEntity stageInterpret);
        void Delete(StageInterpretEntity stageInterpret);
    }
}
