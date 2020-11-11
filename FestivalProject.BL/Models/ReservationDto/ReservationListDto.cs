using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Enums;

namespace FestivalProject.BL.Models.ReservationDto
{
    public class ReservationListDto : EntityBase
    {
        public ReservationStatus State { get; set; }
        public string Name { get; set; }

        public string Username { get; set; } // MAPPER FIX
        public string RealName { get; set; }
        public string Surname { get; set; }
    }
}
