using System;
using System.Collections.Generic;
using System.Text;
using FestivalProject.DAL.Entities;

namespace FestivalProject.BL.Models.StageInterpretDto
{
    public class StageInterpretBaseDto
    {
        public Guid InterpretId { get; set; }
        public InterpretEntity Interpret { get; set; }

        public TimeSpan ConcertLength { get; set; }
        public DateTime ConcertStart { get; set; }
    }
}
