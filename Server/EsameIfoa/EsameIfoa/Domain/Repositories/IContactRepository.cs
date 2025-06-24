using EsameIfoa.Domain.Model;

namespace EsameIfoa.Domain.Repositories;

public interface IContactRepository
{
  Task<IEnumerable<Contact>> GetAllAsync(CancellationToken cancellationToken);
  Task AddAsync(Contact contact, CancellationToken cancellationToken);
}
