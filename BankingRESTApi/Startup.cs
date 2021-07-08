using BankingRESTApi.Models.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using BankingRESTApi.Hypermedia.Filters;
using BankingRESTApi.Hypermedia.Enricher;
using BankingRESTApi.Business;
using BankingRESTApi.Business.Implementations;
using BankingRESTApi.Repository;
using BankingRESTApi.Repository.Generic;
using Microsoft.AspNetCore.Rewrite;
using BankingRESTApi.Repository.Implementations;

namespace BankingRESTApi
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
            services.AddCors(options => options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            services.AddControllers();

            var connection = Configuration["MySQLConnection:MySQLConnectionString"];
            services.AddDbContextPool<MySQLContext>(options =>
            {
                options.UseMySql(connection, ServerVersion.AutoDetect(connection));
            });

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;

                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            })
           .AddXmlSerializerFormatters();

            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(new ClienteEnricher());
            filterOptions.ContentResponseEnricherList.Add(new ContaEnricher());
            services.AddSingleton(filterOptions);

            //Versionamento
            services.AddApiVersioning();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo { 
                        Title = "BankingRESTApi", 
                        Version = "v1",
                        Description = "Apenas um testes de desenvolvimento",
                        Contact = new OpenApiContact
                        {
                            Name = "Gilseone Moraes",
                            Url = new Uri("https://github.com/Gilseone")
                        }
                    });
            });

            //Dependency Injection
            //Cliente
            services.AddScoped<IClienteBusiness, ClienteBusinessImplementation>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            //Conta
            services.AddScoped<IContaBusiness, ContaBusinessImplementation>();
            services.AddScoped<IContaRepository, ContaRepository>();
            //Generic Repository
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
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

            app.UseCors();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "BankingRESTApi v1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
            });
        }
    }
}
