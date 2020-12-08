using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Contacts.Dal.Ldb;
using Contacts.Dal.Mem;
using Contacts.Domain.Dal;
using LiteDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Contacts.Api
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

            services.AddSwaggerGen();

            services.AddScoped<IContactRepository>(sp =>
                {
                    DataLayerInfrastructure<ContactsContext> infrastructure = new Infrastructure();
                    infrastructure.EnsureStorageCreated(Configuration);               
                    return new ContactRepository(infrastructure);
                }
            );

            services.AddScoped<ISkillRepository>(sp =>
                {
                    DataLayerInfrastructure<ContactsContext> infrastructure = new Infrastructure();
                    infrastructure.EnsureStorageCreated(Configuration);
                    return new SkillRepository(infrastructure);
                }
            );

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

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contacts API v1");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
