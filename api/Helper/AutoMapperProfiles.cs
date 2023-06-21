using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto;
using AutoMapper;
using jwtAuth.Model;
using model.Entities;

namespace api.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<SignUpDto, User>();
            CreateMap<User, UserDto>();

            CreateMap<EventDto, Event>();
        }
    }
}