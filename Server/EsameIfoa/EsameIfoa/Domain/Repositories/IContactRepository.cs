using EsameIfoa.Domain.Model;

namespace EsameIfoa.Domain.Repositories;

public interface IContactRepository
{
  /// <summary>
  /// Retrieves all contacts from the database
  /// </summary>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  Task<IEnumerable<Contact>> GetAllAsync(CancellationToken cancellationToken);

  /// <summary>
  /// Retrieves a contact by its email from the database
  /// </summary>
  /// <param name="email"></param>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  Task<Contact?> GetByEmailAsync(string email, CancellationToken cancellationToken);

  /// <summary>
  /// Adds a contact to the database
  /// </summary>
  /// <param name="contact"></param>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  Task AddAsync(Contact contact, CancellationToken cancellationToken);
}
