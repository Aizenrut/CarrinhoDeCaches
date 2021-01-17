using CarrinhoDeCaches.Dados;
using CarrinhoDeCaches.IDados;
using CarrinhoDeCaches.IServicos;
using CarrinhoDeCaches.Servicos;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CarrinhoDeCaches.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });

            services.AddTransient<IRedisRepositorio, RedisRepositorio>();
            services.AddTransient<IItemServico, ItemServico>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
