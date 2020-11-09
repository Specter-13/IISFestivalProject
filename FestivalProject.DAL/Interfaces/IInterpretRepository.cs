using System;
using System.Collections.Generic;
using System.Text;
using FestivalProject.DAL.Entities;

namespace FestivalProject.DAL.Interfaces
{
    public interface IInterpretRepository
    {
        IList<InterpretEntity> GetAll();
        InterpretEntity GetById(Guid id);
        InterpretEntity Create(InterpretEntity interpret);
        InterpretEntity Update(InterpretEntity interpret);
        void Delete(InterpretEntity interpret);
    }
}
