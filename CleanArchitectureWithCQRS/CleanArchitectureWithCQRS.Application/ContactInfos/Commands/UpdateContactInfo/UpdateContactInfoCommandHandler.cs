using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitectureWithCQRS.Domain.Entities;
using CleanArchitectureWithCQRS.Domain.Repository;
using MediatR;

namespace CleanArchitectureWithCQRS.Application.ContactInfos.Commands.UpdateContactInfo
{
    public class UpdateContactInfoCommandHandler : IRequestHandler<UpdateContactInfoCommand, int>
    {
        private readonly IContactInfoRepository _contactInfoRepository;
        private readonly IMapper _mapper;

        public UpdateContactInfoCommandHandler(IContactInfoRepository contactInfoRepository, IMapper mapper)
        {
            _contactInfoRepository = contactInfoRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateContactInfoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _contactInfoRepository.GetByIdAsync(request.ContactInfoID);

            if (entity == null)
            {
                return 0;
            }
            _mapper.Map(request, entity);
            await _contactInfoRepository.UpdateAsync(entity);
            await _contactInfoRepository.SaveChangesAsync();
            return entity.ContactInfoID;
        }
    }
}