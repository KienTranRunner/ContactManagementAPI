using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureWithCQRS.Domain.Entities;
using MediatR;

namespace CleanArchitectureWithCQRS.Application.ContactInfos.Queries.GetContactInfoByID
{
    public class GetContactInfoByIDQuery : IRequest<ContactInfo>
    {
        public int ContactInfoID { get; set; }
    }
}