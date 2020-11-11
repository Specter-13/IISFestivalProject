using System.Collections.Generic;
using FestivalProject.BL.Models.FestivalInterpretDto;
using FestivalProject.BL.Models.StageInterpretDto;
using FestivalProject.DAL.Entities;

namespace FestivalProject.BL.Models.StageDto
{
    public class StageDetailDto : EntityBase
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public FestivalInterpretForInterpretDto Festival { get; set; }
        public IList<StageInterpretForInterpretDto> StageInterpret { get; set; }
    }
}
