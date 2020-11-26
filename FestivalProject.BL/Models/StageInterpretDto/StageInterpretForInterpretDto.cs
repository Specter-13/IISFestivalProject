using System;
using FestivalProject.BL.Models.InterpretDto;
using FestivalProject.BL.Models.StageDto;
using FestivalProject.DAL.Entities;

namespace FestivalProject.BL.Models.StageInterpretDto
{
    public class StageInterpretForInterpretDto 
    {
        
        public StageForInterpretDto Stage { get; set; }
        public Guid StageId { get; set; }

        public TimeSpan ConcertLength { get; set; }
        public DateTime ConcertStart { get; set; }
    }
}
