using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureWithCQRS.Domain.Entities
{
    [Table("ContactInfo")]
    public class ContactInfo
    {
        [Key]
        public int ContactInfoID { get; set;}
        public string ContactName { get; set;}
        public string Phone  { get; set;}
        public string Email { get; set;}

    }
}