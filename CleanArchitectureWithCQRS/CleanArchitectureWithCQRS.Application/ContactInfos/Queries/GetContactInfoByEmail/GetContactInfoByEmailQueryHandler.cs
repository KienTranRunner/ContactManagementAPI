using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitectureWithCQRS.Domain.Entities;
using CleanArchitectureWithCQRS.Domain.Repository;
using MediatR;

namespace CleanArchitectureWithCQRS.Application.ContactInfos.Queries.GetContactInfoByEmail
{
    public class GetContactInfoByEmailQueryHandler : IRequestHandler<GetContactInfoByEmailQuery, IEnumerable<ContactInfo>>
    {
        private readonly IContactInfoRepository _contactInfo;
        private readonly IMapper _mapper;

        public GetContactInfoByEmailQueryHandler(IContactInfoRepository contactInfo, IMapper mapper)
        {
            _contactInfo = contactInfo;
            _mapper = mapper;

        }
        
        public async Task<IEnumerable<ContactInfo>> Handle(GetContactInfoByEmailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _contactInfo.GetByContactEmailAsync(request.Email);
            

            if (entity == null)
            {
                
                return null!;

            }
            return _mapper.Map<IEnumerable<ContactInfo>>(entity);
        }
    }
}