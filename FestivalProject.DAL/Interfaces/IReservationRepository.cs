using System;
using System.Collections.Generic;
using System.Text;
using FestivalProject.DAL.Entities;

namespace FestivalProject.DAL.Interfaces
{
    public interface IReservationRepository
    {
        IList<ReservationEntity> GetAll();
        ReservationEntity GetById(Guid id);
        ReservationEntity Create(ReservationEntity reservation);
        ReservationEntity Update(ReservationEntity reservation);
        void Delete(ReservationEntity reservation);
    }
}
