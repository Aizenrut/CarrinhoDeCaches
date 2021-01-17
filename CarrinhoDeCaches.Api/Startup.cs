using CarrinhoDeCaches.Dados;
using CarrinhoDeCaches.IDados;
using CarrinhoDeCaches.IServicos;
using CarrinhoDeCaches.Servicos;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceStack.Redis;

namespace CarrinhoDeCaches.Api
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddTransient<IRedisRepositorio, RedisRepositorio>();
            services.AddTransient<ICarrinhoServico, CarrinhoServico>();

            services.AddSingleton(factory => new RedisManagerPool(configuration.GetConnectionString("Redis")));
            services.AddTransient(factory => factory.GetService<RedisManagerPool>().GetClient());
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
