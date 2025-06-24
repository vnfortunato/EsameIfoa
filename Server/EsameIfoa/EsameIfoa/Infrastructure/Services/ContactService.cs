using AutoMapper;
using EsameIfoa.Domain.Model;
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
  public async Task AddAsync(ContactDto contactDto, CancellationToken cancellationToken)
  {
    await contactRepository.AddAsync(mapper.Map<Contact>(contactDto), cancellationToken);
  }
}
