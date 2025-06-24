using EsameIfoa.Domain.Model;
using EsameIfoa.Infrastructure.Data;

namespace EsameIfoa;

public class DbSeeder
{
  public static async Task SeedAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
  {
    using var scope = serviceProvider.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();

    await context.Database.EnsureDeletedAsync(cancellationToken);
    await context.Database.EnsureCreatedAsync(cancellationToken);

    Contact contact = new Contact
    {
      Department = "IT",
      FullName = "Mario Rossi",
      Phone = "1234567890",
      Email = "mariorossi@example.com"
    };

    Contact secondContact = new Contact
    {
      Department = "DevOps",
      FullName = "Luigi Verdi",
      Phone = "0987654321",
      Email = "luigiverdi@example.com"
    };

    await context.Contacts.AddRangeAsync(contact, secondContact);
    await context.SaveChangesAsync(cancellationToken);

  }
}
