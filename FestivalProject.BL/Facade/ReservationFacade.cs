using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FestivalProject.BL.Models.InterpretDto;
using FestivalProject.BL.Models.ReservationDto;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Repositories;

namespace FestivalProject.BL.Facade
{
    public class ReservationFacade
    {
        private readonly ReservationRepository _repo;
        private readonly IMapper _mapper;
        public ReservationFacade(ReservationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public IList<ReservationListDto> GetAll()
        {
            return _mapper.Map<IList<ReservationListDto>>(_repo.GetAll());
        }

        public ReservationDetailDto GetById(Guid id)
        {
            return _mapper.Map<ReservationDetailDto>(_repo.GetById(id));
        }

        public ReservationDetailDto Create(ReservationDetailDto item)
        {
            return _mapper.Map<ReservationDetailDto>(_repo.Create(_mapper.Map<ReservationEntity>(item)));
        }

        public ReservationDetailDto Update(ReservationDetailDto item)
        {
            return _mapper.Map<ReservationDetailDto>(_repo.Update(_mapper.Map<ReservationEntity>(item)));
        }

        public void Delete(Guid id)
        {
            _repo.Delete(id);
        }
    }
}
