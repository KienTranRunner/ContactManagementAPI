using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var stopwatch = Stopwatch.StartNew();

            var contactInfos = await Mediator.Send(new GetAllContactInfoQuery());

            stopwatch.Stop();
            return Ok(new
            {
                Message = "Thành công!",
                ExecutionTime = $"{stopwatch.ElapsedMilliseconds} ms",
                Data = contactInfos
            });
        }

        [HttpGet("by-id/{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var stopwatch = Stopwatch.StartNew();

            var contactInfo = await Mediator.Send(new GetContactInfoByIDQuery() { ContactInfoID = id });

            stopwatch.Stop();
            if (contactInfo == null)
            {
                return NotFound(new
                {
                    Message = "Không tìm thấy thông tin liên lạc.",
                    ExecutionTime = $"{stopwatch.ElapsedMilliseconds} ms"
                });
            }

            return Ok(new
            {
                Message = "Thành công!",
                ExecutionTime = $"{stopwatch.ElapsedMilliseconds} ms",
                Data = contactInfo
            });
        }

        [HttpGet("by-name/{contactName}")]
        public async Task<IActionResult> GetByName(string contactName)
        {
            var stopwatch = Stopwatch.StartNew();

            var contactInfo = await Mediator.Send(new GetContactInfoByNameQuery() { ContactName = contactName });

            stopwatch.Stop();
            if (contactInfo == null)
            {
                return NotFound(new
                {
                    Message = "Không tìm thấy thông tin liên lạc.",
                    ExecutionTime = $"{stopwatch.ElapsedMilliseconds} ms"
                });
            }

            return Ok(new
            {
                Message = "Thành công!",
                ExecutionTime = $"{stopwatch.ElapsedMilliseconds} ms",
                Data = contactInfo
            });
        }

        [HttpGet("by-email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var stopwatch = Stopwatch.StartNew();

            var contactInfo = await Mediator.Send(new GetContactInfoByEmailQuery() { Email = email });

            stopwatch.Stop();
            if (contactInfo == null)
            {
                return NotFound(new
                {
                    Message = "Không tìm thấy thông tin liên lạc.",
                    ExecutionTime = $"{stopwatch.ElapsedMilliseconds} ms"
                });
            }

            return Ok(new
            {
                Message = "Thành công!",
                ExecutionTime = $"{stopwatch.ElapsedMilliseconds} ms",
                Data = contactInfo
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateContactInfoCommand command)
        {
            var stopwatch = Stopwatch.StartNew();

            var createContactInfo = await Mediator.Send(command);

            stopwatch.Stop();
            return Ok(new
            {
                Message = "Tạo thông tin liên hệ thành công!",
                ExecutionTime = $"{stopwatch.ElapsedMilliseconds} ms",
                Data = createContactInfo
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateContactInfoCommand command)
        {
            var stopwatch = Stopwatch.StartNew();

            command.ContactInfoID = id;
            var updatedId = await Mediator.Send(command);

            stopwatch.Stop();
            if (updatedId == 0)
            {
                return NotFound(new
                {
                    Message = "ID thông tin liên lạc không tồn tại.",
                    ExecutionTime = $"{stopwatch.ElapsedMilliseconds} ms"
                });
            }

            return Ok(new
            {
                Message = $"Cập nhật thành công với id {updatedId}",
                ExecutionTime = $"{stopwatch.ElapsedMilliseconds} ms"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var stopwatch = Stopwatch.StartNew();

            var command = new DeleteContactInfoCommand { ContactInfoID = id };
            var result = await Mediator.Send(command);

            stopwatch.Stop();
            if (!result)
            {
                return NotFound(new
                {
                    Message = "Thông tin liên lạc không tồn tại.",
                    ExecutionTime = $"{stopwatch.ElapsedMilliseconds} ms"
                });
            }

            return Ok(new
            {
                Message = $"Xoá thông tin liên lạc thành công với id liên lạc là {id}",
                ExecutionTime = $"{stopwatch.ElapsedMilliseconds} ms"
            });
        }
    }
}
