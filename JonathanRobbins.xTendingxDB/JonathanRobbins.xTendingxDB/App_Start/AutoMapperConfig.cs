using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using JonathanRobbins.xTendingxDB.CMS.xDB.Entities;
using JonathanRobbins.xTendingxDB.ViewModels;
using Sitecore.Publishing.Diagnostics;

namespace JonathanRobbins.xTendingxDB.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(config => config.CreateMap<SampleOrderVM, ContactModel>()
                    .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.Surname, opts => opts.MapFrom(src => src.Surname))
                    .ForMember(dest => dest.Role, opts => opts.MapFrom(src => src.Role))
                    .ForMember(dest => dest.EmailAddress, opts => opts.MapFrom(src => src.EmailAddress))
                    .ForMember(dest => dest.Number, opts => opts.MapFrom(src => src.Number))
                    .ForMember(dest => dest.AddressLine1, opts => opts.MapFrom(src => src.AddressLine1))
                    .ForMember(dest => dest.AddressLine1, opts => opts.MapFrom(src => src.AddressLine1))
                    .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.City))
                    .ForMember(dest => dest.Country, opts => opts.MapFrom(src => src.Country))
                    .ForMember(dest => dest.PostCode, opts => opts.MapFrom(src => src.PostCode))
            );
        }
    }
}