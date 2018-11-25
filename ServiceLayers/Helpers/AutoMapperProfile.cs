using AutoMapper;
using ServiceLayers.DTOs;
using ServiceLayers.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayers.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
