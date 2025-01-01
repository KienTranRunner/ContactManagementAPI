using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureWithCQRS.Domain.Entities;
using MediatR;

namespace CleanArchitectureWithCQRS.Application.ContactInfos.Commands.CreateContactInfo
{
    public class CreateContactInfoCommand : IRequest<ContactInfo>
    {
        [Required]
        public string ContactName { get; set;} = string.Empty;

        [Required]
        public string Phone  { get; set;} = string.Empty;
        
        [Required]
        public string Email { get; set;} = string.Empty;
    }
}