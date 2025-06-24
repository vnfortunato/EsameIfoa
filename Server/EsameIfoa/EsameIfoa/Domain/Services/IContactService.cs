using EsameIfoa.Dto;

namespace EsameIfoa.Domain.Services;

public interface IContactService
{
  /// <summary>
  /// Retrieves all contacts
  /// </summary>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  Task<IEnumerable<ContactDto>> GetAllAsync(CancellationToken cancellationToken);

  /// <summary>
  /// Adds a contact
  /// </summary>
  /// <param name="contactDto"></param>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  Task<bool> AddAsync(ContactDto contactDto, CancellationToken cancellationToken);
}
