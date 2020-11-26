﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FestivalProject.BL.Models.ReservationDto;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Repositories;

namespace FestivalProject.BL.Mapper
{
   public class ReservationProfiles : Profile
    {
        public ReservationProfiles()
        {
            CreateMap<ReservationListDto, ReservationEntity>();
            CreateMap<ReservationDetailDto, ReservationEntity>();

            CreateMap<ReservationEntity, ReservationListDto > ().ForMember(d=> d.FestivalName, o=>o.MapFrom(s=>s.Festival.Name));
            CreateMap<ReservationEntity,ReservationDetailDto > ();
        }
    }
}
