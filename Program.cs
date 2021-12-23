using CRUD_funcionarios;
using CRUD_funcionarios.repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DataBaseSession>();
builder.Services.AddTransient<IRepository, Repository>();
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAll",
    builder =>
    {
      builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseCors("AllowAll");
  app.UseSwagger();
  app.UseSwaggerUI(options =>
  {
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "CRUD funcionarios V1");
    options.RoutePrefix = string.Empty;
  });

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
