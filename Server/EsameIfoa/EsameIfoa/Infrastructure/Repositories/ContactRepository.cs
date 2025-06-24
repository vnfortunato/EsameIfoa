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

  public async Task AddAsync(Contact contact, CancellationToken cancellationToken)
  {
    await context.Contacts.AddAsync(contact, cancellationToken);
    context.SaveChanges();
  }

  public async Task<Contact?> GetByEmailAsync(string email, CancellationToken cancellationToken)
  {
    return await context.Contacts.FirstOrDefaultAsync(c => c.Email == email, cancellationToken);
  }
}
