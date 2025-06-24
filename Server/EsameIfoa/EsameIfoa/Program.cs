using EsameIfoa.Domain.Model;
using EsameIfoa.Domain.Repositories;
using EsameIfoa.Domain.Services;
using EsameIfoa.Infrastructure.Data;
using EsameIfoa.Infrastructure.Repositories;
using EsameIfoa.Infrastructure.Services;
using EsameIfoa.Mappings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAngularClient", policy =>
  {
    policy.WithOrigins("http://localhost:4200")
          .AllowAnyHeader()
          .AllowAnyMethod()
          .AllowCredentials();
  });
});

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer("Server=localhost;Database=EsameIfoa;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"));

builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddAutoMapper(typeof(ContactProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAngularClient");

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
  var context = scope.ServiceProvider.GetRequiredService<DataContext>();

  context.Database.EnsureDeleted();
  context.Database.EnsureCreated();

  Contact contact = new Contact
  {
    Department = "IT",
    FullName = "Mario Rossi",
    Phone = "1234567890",
    Email = "mariorossi@example.com"
  };

  context.Contacts.Add(contact);
  context.SaveChanges();
}

app.Run();
