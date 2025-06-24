using EsameIfoa;
using EsameIfoa.Infrastructure.Data;
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
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

DependencyLoader.LoadMappings(builder.Services);
DependencyLoader.LoadRepositories(builder.Services);
DependencyLoader.LoadServices(builder.Services);

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

using (IServiceScope scope = app.Services.CreateScope())
{
  CancellationToken cancellationToken = new CancellationToken();

  await DbSeeder.SeedAsync(scope.ServiceProvider, cancellationToken);
}

app.Run();
