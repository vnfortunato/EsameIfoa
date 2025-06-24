using EsameIfoa.Domain.Model;
using EsameIfoa.Domain.Repositories;
using EsameIfoa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EsameIfoa.Infrastructure.Repositories;

public class ContactRepository(DataContext context) : IContactRepository
{
  public async Task<IEnumerable<Contact>> GetAllAsync(CancellationToken cancellationToken)
  {
    return await context.Contacts.ToListAsync(cancellationToken);
  }
}
