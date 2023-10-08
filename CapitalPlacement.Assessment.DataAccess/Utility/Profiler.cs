using AutoMapper;
using CapitalPlacement.Assessment.Model.Dto;
using CapitalPlacement.Assessment.Model.Entities;

namespace CapitalPlacement.Assessment.DataAccess.Utility
{
    public class Profiler : AutoMapper.Profile
    {
        public Profiler()
        {
           CreateMap<ProgramRequestDto, ProgramDetails>();
        }
    }
}
