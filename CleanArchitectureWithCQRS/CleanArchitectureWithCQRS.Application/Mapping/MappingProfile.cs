using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitectureWithCQRS.Application.ContactInfos.Commands.CreateContactInfo;
using CleanArchitectureWithCQRS.Application.ContactInfos.Commands.UpdateContactInfo;
using CleanArchitectureWithCQRS.Application.ContactInfos.Queries.GetContactInfoByName;
using CleanArchitectureWithCQRS.Domain.Entities;

namespace CleanArchitectureWithCQRS.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateContactInfoCommand, ContactInfo>()
                .ForMember(dest => dest.ContactInfoID, opt => opt.Ignore());

            CreateMap<UpdateContactInfoCommand, ContactInfo>()
                .ForMember(dest => dest.ContactInfoID, opt => opt.Ignore())
                .ConvertUsing(new NullValueIgnoringConverter<UpdateContactInfoCommand, ContactInfo>());

            // CreateMap<IEnumerable<ContactInfo>, List<ContactInfo>>()
            // .ConvertUsing((src, dest, context) => src.ToList());



        }
    }
}