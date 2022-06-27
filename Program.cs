using Microsoft.EntityFrameworkCore;
using TesteBackEndAiko.Models;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddControllers();

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<Contexto>
    (option =>
    option.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=TESTE_Api_Aiko; Id=postgres;Password=fluminense22;"));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

IApplicationBuilder applicationBuilder = app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
