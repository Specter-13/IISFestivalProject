using System;
using System.Collections.Generic;
using System.Text;
using FestivalProject.BL.Models.InterpretDto;
using FestivalProject.DAL.Entities;

namespace FestivalProject.BL.Models.StageInterpretDto
{
    public class StageInterpretBaseDto
    {
        public Guid InterpretId { get; set; }
        public InterpretListDto Interpret { get; set; }

        public int ConcertLength { get; set; }
        public DateTime ConcertStart { get; set; }
        public DateTime ConcertEnd { get; set; }
    }
}
