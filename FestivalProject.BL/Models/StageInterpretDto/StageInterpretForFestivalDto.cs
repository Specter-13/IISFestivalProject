﻿using System;
using System.Collections.Generic;
using System.Text;
using FestivalProject.BL.Models.StageDto;

namespace FestivalProject.BL.Models.StageInterpretDto
{
    public class StageInterpretForFestivalDto
    {
        public StageForFestivalDto Stage { get; set; }
        public Guid StageId { get; set; }

        public TimeSpan ConcertLength { get; set; }
        public DateTime ConcertStart { get; set; }
    }
}
