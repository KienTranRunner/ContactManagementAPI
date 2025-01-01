using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureWithCQRS.Domain.Entities;
using MediatR;

namespace CleanArchitectureWithCQRS.Application.ContactInfos.Queries.GetAllContactInfo
{
    public class GetAllContactInfoQuery : IRequest<IEnumerable<ContactInfo>>
    {
        
    }
}