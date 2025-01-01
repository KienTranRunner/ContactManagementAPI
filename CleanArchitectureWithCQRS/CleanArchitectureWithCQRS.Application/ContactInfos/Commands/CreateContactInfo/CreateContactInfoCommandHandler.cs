using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitectureWithCQRS.Domain.Entities;
using CleanArchitectureWithCQRS.Domain.Repository;
using MediatR;

namespace CleanArchitectureWithCQRS.Application.ContactInfos.Commands.CreateContactInfo
{
    public class CreateContactInfoCommandHandler : IRequestHandler<CreateContactInfoCommand, ContactInfo>
    {
        private readonly IContactInfoRepository _contactInfo;
        private readonly IMapper _mapper;
        
        public CreateContactInfoCommandHandler(IContactInfoRepository contactInfo, IMapper mapper)
        {
            _contactInfo = contactInfo;
            _mapper = mapper;
        }
        public async Task<ContactInfo> Handle(CreateContactInfoCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ContactInfo>(request);
            await _contactInfo.AddAsync(entity);
            await _contactInfo.SaveChangesAsync();
            return entity;
        }
    }
}