using API.Model.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Model.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<SuperHero, SuperHeroDTO>();
            CreateMap<SuperHeroDTO, SuperHero>();

        }
    }
}
