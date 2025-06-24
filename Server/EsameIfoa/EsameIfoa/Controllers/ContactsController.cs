using EsameIfoa.Domain.Services;
using EsameIfoa.Dto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace EsameIfoa.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ContactsController(IContactService contactService) : ControllerBase
  {
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetContactsAsync(CancellationToken cancellationToken)
    {
      await contactService.GetAllAsync(cancellationToken);

      return Ok(await contactService.GetAllAsync(cancellationToken));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddContactAsync(ContactDto contactDto, CancellationToken cancellationToken)
    {
      bool success = await contactService.AddAsync(contactDto, cancellationToken);
      if (success)
      {
        return Ok(new { message = "Contact added" });
      }
      return BadRequest(new { message = "User already exists" });
    }
  }
}
