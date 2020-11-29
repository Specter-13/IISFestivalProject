using System;
using System.ComponentModel.DataAnnotations.Schema;
using FestivalProject.BL.Models.FestivalDto;
using FestivalProject.BL.Models.FestivalInterpretDto;
using FestivalProject.BL.Models.UserDto;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Enums;

namespace FestivalProject.BL.Models.ReservationDto
{
    public class ReservationCreateUpdate : EntityBase
    {
        public ReservationStatus State { get; set; }
        public int Tickets { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }


        public Guid UserId  { get; set; }
        public Guid  FestivalId { get; set; }
    }
}
