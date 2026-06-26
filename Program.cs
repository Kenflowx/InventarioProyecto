using Microsoft.EntityFrameworkCore;
using InventarioProyecto.Data;
using InventarioProyecto.Modules.Inventario;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddInventarioModule();
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"));
});

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();

app.Run();