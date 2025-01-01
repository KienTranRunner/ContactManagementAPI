using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureWithCQRS.Domain.Entities;
using MediatR;

namespace CleanArchitectureWithCQRS.Application.ContactInfos.Queries.GetContactInfoByEmail
{
    public class GetContactInfoByEmailQuery : IRequest<IEnumerable<ContactInfo>>
    {
        public string Email { get; set; }
    }
}