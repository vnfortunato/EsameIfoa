using AutoMapper;
using EsameIfoa.Domain.Repositories;
using EsameIfoa.Domain.Services;
using EsameIfoa.Dto;

namespace EsameIfoa.Infrastructure.Services;

public class ContactService(IContactRepository contactRepository, IMapper mapper) : IContactService
{
  public async Task<IEnumerable<ContactDto>> GetAllAsync(CancellationToken cancellationToken)
  {
    return mapper.Map<IEnumerable<ContactDto>>(await contactRepository.GetAllAsync(cancellationToken));
  }
}
