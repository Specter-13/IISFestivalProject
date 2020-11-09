using System;
using System.Collections.Generic;
using System.Text;
using FestivalProject.DAL.Entities;

namespace FestivalProject.DAL.Interfaces
{
    public interface IMembersRepository
    {
        InterpretEntity Create(InterpretEntity member);
        InterpretEntity Update(InterpretEntity member);
        void Delete(InterpretEntity member);
    }
}
