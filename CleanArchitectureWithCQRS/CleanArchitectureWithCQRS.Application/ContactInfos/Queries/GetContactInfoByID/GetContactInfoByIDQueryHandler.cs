using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitectureWithCQRS.Domain.Entities;
using CleanArchitectureWithCQRS.Domain.Repository;
using MediatR;

namespace CleanArchitectureWithCQRS.Application.ContactInfos.Queries.GetContactInfoByID
{
    public class GetContactInfoByIDQueryHandler : IRequestHandler<GetContactInfoByIDQuery, ContactInfo>
    {
        private readonly IContactInfoRepository _contactInfo;
        private readonly IMapper _mapper;


        public GetContactInfoByIDQueryHandler(IContactInfoRepository contactInfo, IMapper mapper)
        {
            _contactInfo = contactInfo;
            _mapper = mapper;
        }

        public async Task<ContactInfo> Handle(GetContactInfoByIDQuery request, CancellationToken cancellationToken)
        {

            var entity = await _contactInfo.GetByIdAsync(request.ContactInfoID);

            if (entity == null)
            {
                return null!;
            }

            return _mapper.Map<ContactInfo>(entity);
        }
    }
}