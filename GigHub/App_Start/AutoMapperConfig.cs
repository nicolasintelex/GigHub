using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigHub.Models;
using GigHub.Dtos;

namespace GigHub.App_Start
{
    public static class AutoMapperConfig
    {
        public static IMapper mapper;
        public static MapperConfiguration MapperConfiguration;

        public static void RegisterMappings()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationUser, UserDto>();
                cfg.CreateMap<Genre, GenreDto>();
                cfg.CreateMap<Gig, GigDto>();
                cfg.CreateMap<Notification, NotificationDto>();
            });

            mapper = MapperConfiguration.CreateMapper();
        }

    }
}