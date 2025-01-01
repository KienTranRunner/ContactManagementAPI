using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitectureWithCQRS.Domain.Entities;
using CleanArchitectureWithCQRS.Domain.Repository;
using MediatR;

namespace CleanArchitectureWithCQRS.Application.ContactInfos.Queries.GetAllContactInfo
{
    public class GetAllContactInfoQueryHandler : IRequestHandler<GetAllContactInfoQuery, IEnumerable<ContactInfo>>
    {
        private readonly IContactInfoRepository _contactInfoRepository;
        private readonly IMapper _mapper;
        public GetAllContactInfoQueryHandler(IContactInfoRepository contactInfoRepository, IMapper mapper)
        {
            this._contactInfoRepository = contactInfoRepository;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<ContactInfo>> Handle(GetAllContactInfoQuery request, CancellationToken cancellationToken)
        {
            var contactInfos = await _contactInfoRepository.GetAllAsync();
           
            
            var contactInfosList = _mapper.Map<IEnumerable<ContactInfo>>(contactInfos);
            return contactInfosList;
        }
    }
}