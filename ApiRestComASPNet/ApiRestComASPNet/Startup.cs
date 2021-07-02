using ApiRestComASPNet.Model.Context;
using ApiRestComASPNet.Business;
using ApiRestComASPNet.Business.Implementations;
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
using ApiRestComASPNet.Repository;
using ApiRestComASPNet.Repository.Implementations;
using Serilog;
using MySqlConnector;

namespace ApiRestComASPNet
{
    public class Startup
    {
        public IWebHostEnvironment Enviroment { get; }
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment enviroment)
        {
            Configuration = configuration;
            Enviroment = enviroment;
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            #region Metodo responsavel por descobrir os Controllers
            services.AddControllers();
            #endregion
            #region Responsavel pro versionalizar a aplicação Usando o Mvc,Versioning.Aplicação atual usando versionalizacao por controllers
            services.AddApiVersioning();
            #endregion
            #region Regiao de conexao com banco de dados MySql
            var MySqlConnectionString = Configuration.GetConnectionString("MySQLString");
            services.AddDbContext<MySqlContext>(optionsAction => optionsAction.UseMySql(MySqlConnectionString, ServerVersion.AutoDetect(MySqlConnectionString)));
            #endregion
            #region Declaração de serviços para de Business e seu devido Repository
            services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
            services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();

            services.AddScoped<IBooksBusiness, BooksBusinessImplementation>();
            services.AddScoped<IBooksRepository, BooksRepositoryImplementation>();
            #endregion

            if (Enviroment.IsDevelopment())
            {
                MigrateDatabase(MySqlConnectionString);
            }
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
        private void MigrateDatabase(string mySqlConnectionString)
        {
            try
            {
                var evolveConnection = new MySqlConnection(mySqlConnectionString);

                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "db/migrations", "db/dataset" },
                    IsEraseDisabled = true,
                };
                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error("Database migration failed", ex);
                throw;
            }
        }
    }
}
