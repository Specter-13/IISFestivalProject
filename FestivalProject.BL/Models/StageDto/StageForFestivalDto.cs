using System;
using System.Collections.Generic;
using System.Text;
using FestivalProject.BL.Models.StageInterpretDto;
using FestivalProject.DAL.Entities;

namespace FestivalProject.BL.Models.StageDto
{
    public class StageForFestivalDto : EntityBase
    {
        public string Name { get; set; }
        public int Capacity { get; set; }

    }
}
