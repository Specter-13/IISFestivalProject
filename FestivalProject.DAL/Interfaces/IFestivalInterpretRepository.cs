using System;
using System.Collections.Generic;
using System.Text;
using FestivalProject.DAL.Entities;

namespace FestivalProject.DAL.Interfaces
{
    public interface IFestivalInterpretRepository
    {
       
        FestivalInterpretEntity Create(FestivalInterpretEntity festivalInterpret);
        void Delete(FestivalInterpretEntity festivalInterpret);
    }
}
