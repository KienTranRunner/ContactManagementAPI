using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureWithCQRS.Domain.Repository;
using MediatR;

namespace CleanArchitectureWithCQRS.Application.ContactInfos.Commands.DeleteContactInfo
{
    public class DeleteContactInfoCommandHandler : IRequestHandler<DeleteContactInfoCommand, bool>
    {
        private readonly IContactInfoRepository _contactInfoRepository;

        public DeleteContactInfoCommandHandler(IContactInfoRepository contactInfoRepository)
        {
            _contactInfoRepository = contactInfoRepository;
        }
        public async Task<bool> Handle(DeleteContactInfoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _contactInfoRepository.GetByIdAsync(request.ContactInfoID);

            if (entity == null)
            {
                return false;
            }

             _contactInfoRepository.DeleteAsync(entity);
            await _contactInfoRepository.SaveChangesAsync();

            return true;

        }
    }
}