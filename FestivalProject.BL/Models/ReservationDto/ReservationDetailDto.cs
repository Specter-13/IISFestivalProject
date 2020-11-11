using System;
using System.ComponentModel.DataAnnotations.Schema;
using FestivalProject.BL.Models.FestivalDto;
using FestivalProject.BL.Models.FestivalInterpretDto;
using FestivalProject.BL.Models.UserDto;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Enums;

namespace FestivalProject.BL.Models.ReservationDto
{
    public class ReservationDetailDto : EntityBase
    {
        public ReservationStatus State { get; set; }
        public string Name { get; set; }
        public int Tickets { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string Description { get; set; }

        public UserDetailDto User { get; set; }
        public FestivalInterpretForInterpretDto Festival { get; set; }
    }
}
