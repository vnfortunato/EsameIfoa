using EsameIfoa.Domain.Services;
using EsameIfoa.Dto;
using Microsoft.AspNetCore.Mvc;


namespace EsameIfoa.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ContactsController(IContactService contactService) : ControllerBase
  {
    [HttpGet]
    public async Task<IActionResult> GetContactsAsync(CancellationToken cancellationToken)
    {
      await contactService.GetAllAsync(cancellationToken);

      return Ok(await contactService.GetAllAsync(cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> AddContactAsync(ContactDto contactDto, CancellationToken cancellationToken)
    {
      await contactService.AddAsync(contactDto, cancellationToken);

      return Ok(new { message = "Contact added" });
    }
  }
}
