using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchitectureWithCQRS.Application.ContactInfos.Commands.UpdateContactInfo
{
    public class UpdateContactInfoCommand : IRequest<int>
    {
        [JsonIgnore]
        public int ContactInfoID { get; set; }
        
        public string? ContactName { get; set;}

        public string? Phone  { get; set;}
        
        public string? Email { get; set;}
    }
}