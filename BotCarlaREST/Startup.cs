using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotCarlaREST.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace BotCarlaREST
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
            services.AddControllers();
            var ConnectionString = @"Server=JOSSAN\SQLEXPRESS; Database=Carla;Trusted_Connection=True; ";
            //@"server=VISTI\SQLEXPRESS; Database=BiografApiData; Trusted_Connection=true";

            services.AddDbContext<Datasql>(option => option.UseSqlServer(ConnectionString));
            //services.AddControllers();
            // dette sørger for vi ikke får uendeligt loop






            services.AddSwaggerGen(c =>
            {
                services.AddCors();
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors("MyAllowSpecificOrigins");
            //app.UseCors(options =>
            //options.WithOrigins("http://localhost:4200")
            //.AllowAnyMethod()
            //.AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "API V2");
            });
            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}