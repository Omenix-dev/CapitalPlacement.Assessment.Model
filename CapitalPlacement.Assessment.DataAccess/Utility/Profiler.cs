﻿using AutoMapper;
using CapitalPlacement.Assessment.Model.Dto;
using CapitalPlacement.Assessment.Model.Entities;

namespace CapitalPlacement.Assessment.DataAccess.Utility
{
    public class Profiler : AutoMapper.Profile
    {
        public Profiler()
        {
           CreateMap<ProgramRequestDto, ProgramDetails>().ReverseMap();
           CreateMap<PreviewDto, ProgramDetails>().ReverseMap();
           CreateMap<WorkFlow, WorkFlowRequestDto>().ReverseMap();
           CreateMap<ApplicationForm, ApplicantRequestDto>().ReverseMap();
        }
    }
}
