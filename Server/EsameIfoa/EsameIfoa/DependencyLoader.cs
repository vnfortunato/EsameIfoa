using EsameIfoa.Domain.Repositories;
using EsameIfoa.Domain.Services;
using EsameIfoa.Infrastructure.Repositories;
using EsameIfoa.Infrastructure.Services;
using EsameIfoa.Mappings;

namespace EsameIfoa;

public class DependencyLoader()
{
  public static void LoadServices(IServiceCollection services)
  {
    services.AddScoped<IContactService, ContactService>();
  }

  public static void LoadRepositories(IServiceCollection services)
  {
    services.AddScoped<IContactRepository, ContactRepository>();
  }
  public static void LoadMappings(IServiceCollection services)
  {
    services.AddAutoMapper(typeof(ContactProfile));
  }
}
