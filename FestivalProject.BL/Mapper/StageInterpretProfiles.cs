using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FestivalProject.BL.Models.StageInterpretDto;
using FestivalProject.DAL.Entities;

namespace FestivalProject.BL.Mapper
{
    public class StageInterpretProfiles: Profile
    {
        public StageInterpretProfiles()
        {
            CreateMap<StageInterpretEntity, StageInterpretForInterpretDto>();
            CreateMap<StageInterpretEntity, StageInterpretForFestivalDto>();
            CreateMap<StageInterpretForInterpretDto,StageInterpretEntity>();
            CreateMap<StageInterpretForFestivalDto, StageInterpretEntity>();
        }
    }
}
