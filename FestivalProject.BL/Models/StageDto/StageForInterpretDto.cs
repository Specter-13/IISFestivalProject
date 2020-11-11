using System;
using System.Collections.Generic;
using System.Text;
using FestivalProject.BL.Models.FestivalInterpretDto;
using FestivalProject.BL.Models.StageInterpretDto;

namespace FestivalProject.BL.Models.StageDto
{
    public class StageForInterpretDto 
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string FestivalName { get;set; }
        
    }
}
