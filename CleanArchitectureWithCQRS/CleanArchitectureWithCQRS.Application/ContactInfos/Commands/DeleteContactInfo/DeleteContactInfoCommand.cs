using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchitectureWithCQRS.Application.ContactInfos.Commands.DeleteContactInfo
{
    public class DeleteContactInfoCommand : IRequest<bool>
    {
        public int ContactInfoID { get; set;}
    }
}