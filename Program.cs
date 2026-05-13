using Trabalho_Api.Services;
using Trabalho_Api.DataContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Registrar os serviços
builder.Services.AddScoped<AlunoService>();
builder.Services.AddScoped<AvaliacaoService>();

// Configurar o DbContext com a string de conexão
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();