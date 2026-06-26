using InventarioProyecto.Modules.Inventario.Repositories;
using InventarioProyecto.Modules.Inventario.Services;

namespace InventarioProyecto.Modules.Inventario
{
    public static class InventarioModule
    {
        public static IServiceCollection AddInventarioModule(this IServiceCollection services)
        {
            services.AddScoped<InventarioService>();
            services.AddScoped<InventarioRepository>();
            return services;
        }
    }
}