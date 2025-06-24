using EsameIfoa.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace EsameIfoa.Infrastructure.Data;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions<DataContext> options): base(options){}

  public DbSet<Contact> Contacts { get; set; }
}
