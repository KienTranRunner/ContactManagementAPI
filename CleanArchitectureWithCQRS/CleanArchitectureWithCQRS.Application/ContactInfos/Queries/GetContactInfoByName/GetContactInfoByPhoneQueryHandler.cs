using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitectureWithCQRS.Domain.Entities;
using CleanArchitectureWithCQRS.Domain.Repository;
using MediatR;

namespace CleanArchitectureWithCQRS.Application.ContactInfos.Queries.GetContactInfoByName
{
    public class GetContactInfoByPhoneQueryHandler : IRequestHandler<GetContactInfoByNameQuery, IEnumerable<ContactInfo>>
    {
        private readonly IContactInfoRepository _contactInfo;
        private readonly IMapper _mapper;

        public GetContactInfoByPhoneQueryHandler(IContactInfoRepository contactInfo, IMapper mapper)
        {
            _contactInfo = contactInfo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactInfo>> Handle(GetContactInfoByNameQuery request, CancellationToken cancellationToken)
        {
            var entity = await _contactInfo.GetByContactNameAsync(request.ContactName);

            if (entity == null)
            {
                return null!;
            }

            return _mapper.Map<IEnumerable<ContactInfo>>(entity);
        }
    }
}