using AutoMapper;
using EsameIfoa.Domain.Model;
using EsameIfoa.Dto;

namespace EsameIfoa.Mappings
{
  public class ContactProfile : Profile
  {
    public ContactProfile()
    {
      CreateMap<Contact, ContactDto>().ReverseMap();
    }
  }
}
