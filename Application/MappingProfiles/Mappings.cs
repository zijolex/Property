﻿using Application.Models;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class Mappings:Profile
    {
        public Mappings()
        {
            CreateMap<NewProperty, Property>();
            CreateMap<Property, PropertyDto>();

            CreateMap<NewImage, Image>();
            CreateMap<Image, ImageDto>();
        }
    }
}
