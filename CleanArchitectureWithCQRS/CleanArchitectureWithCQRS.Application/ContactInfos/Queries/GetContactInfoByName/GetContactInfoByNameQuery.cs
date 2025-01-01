using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureWithCQRS.Domain.Entities;
using MediatR;

namespace CleanArchitectureWithCQRS.Application.ContactInfos.Queries.GetContactInfoByName
{
    public class GetContactInfoByNameQuery : IRequest<IEnumerable<ContactInfo>>
    {
        public string ContactName { get; set; }
    }
}