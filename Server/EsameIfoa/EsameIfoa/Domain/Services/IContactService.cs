using EsameIfoa.Dto;

namespace EsameIfoa.Domain.Services;

public interface IContactService
{
  Task<IEnumerable<ContactDto>> GetAllAsync(CancellationToken cancellationToken);
}
