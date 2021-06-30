using ApiRestComASPNet.Model.Context;
using ApiRestComASPNet.Services;
using ApiRestComASPNet.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestComASPNet
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Metodo responsavel por descobrir os Controllers
            services.AddControllers();
            #endregion
            #region Regiao de conexao com banco de dados MySql
            var MySqlConnectionString = Configuration.GetConnectionString("MySQLString");
            services.AddDbContext<MySqlContext>(optionsAction => optionsAction.UseMySql(MySqlConnectionString, ServerVersion.AutoDetect(MySqlConnectionString)));
            #endregion
            #region Declaração de serviços para de Services
            services.AddScoped<IPersonService, PersonServiceImplementation>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
