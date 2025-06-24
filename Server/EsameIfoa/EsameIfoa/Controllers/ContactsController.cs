using EsameIfoa.Domain.Services;
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
  }
}
