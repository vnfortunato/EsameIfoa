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
  public async Task<bool> AddAsync(ContactDto contactDto, CancellationToken cancellationToken)
  {
    Contact? alreadyExists = await contactRepository.GetByEmailAsync(contactDto.Email, cancellationToken);

    if (alreadyExists != null)
    {
      return false;
    }

    await contactRepository.AddAsync(mapper.Map<Contact>(contactDto), cancellationToken);
    return true;
  }
}
