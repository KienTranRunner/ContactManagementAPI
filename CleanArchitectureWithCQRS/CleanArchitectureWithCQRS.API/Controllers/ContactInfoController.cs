using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureWithCQRS.Application.ContactInfos.Commands.CreateContactInfo;
using CleanArchitectureWithCQRS.Application.ContactInfos.Commands.DeleteContactInfo;
using CleanArchitectureWithCQRS.Application.ContactInfos.Commands.UpdateContactInfo;
using CleanArchitectureWithCQRS.Application.ContactInfos.Queries.GetAllContactInfo;
using CleanArchitectureWithCQRS.Application.ContactInfos.Queries.GetContactInfoByEmail;
using CleanArchitectureWithCQRS.Application.ContactInfos.Queries.GetContactInfoByID;
using CleanArchitectureWithCQRS.Application.ContactInfos.Queries.GetContactInfoByName;
using CleanArchitectureWithCQRS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureWithCQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ApiControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contactInfos = await Mediator.Send(new GetAllContactInfoQuery());
            return Ok(contactInfos);
        }

        [HttpGet("by-id/{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var contactInfo = await Mediator.Send(new GetContactInfoByIDQuery() { ContactInfoID = id });
            if (contactInfo == null)
            {
                return NotFound();
            }
            return Ok(contactInfo);

        }


        [HttpGet("by-name/{contactName}")]
        public async Task<IActionResult> GetByName(string contactName)

        {
            var contactInfo = await Mediator.Send(new GetContactInfoByNameQuery() { ContactName = contactName });
            if (contactInfo == null)
            {
                return NotFound();
            }
            return Ok(contactInfo);
        }


        [HttpGet("by-email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)

        {
            var contactInfo = await Mediator.Send(new GetContactInfoByEmailQuery() { Email = email });
            if (contactInfo == null)
            {
                return NotFound();
            }
            return Ok(contactInfo);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateContactInfoCommand command)
        {
            var createContactInfo = await Mediator.Send(command);
            return Ok(new { Message = "Tạo thông tin liên hệ thành công!", createContactInfo });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateContactInfoCommand command)
        {
            command.ContactInfoID = id;

            var updatedId = await Mediator.Send(command);

            if (updatedId == 0)
            {
                return NotFound(new { Message = "ID thông tin liên lạc không tồn tại." });
            }
            return Ok(new { Message = $"Cập nhật thành công với id {updatedId}" });

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var command = new DeleteContactInfoCommand { ContactInfoID = id };
            var result = await Mediator.Send(command);

            if (result == false)
            {
                return NotFound("Thông tin liên lạc không tồn tại.");
            }

            return Ok($"Xoá thông tin liên lạc thành công với id liên lạc là {id} ");

        }


    }
}