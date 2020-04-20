using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Persona.IdentityServer.Models;
using Persona.IdentityServer.Persistence;
using Persona.IdentityServer.Configurations;
using System.Collections.Generic;
using IdentityServer4.Test;

namespace Persona.IdentityServer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public string DefaultConnectionString => this.Configuration.GetConnectionString("Default");

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContextPool<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(this.DefaultConnectionString);
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddIdentityServer(opt =>
            {
                opt.IssuerUri = Configuration["IdentityServer:IssuerUri"];
            })
            .AddInMemoryClients(Config.Clients)
            .AddInMemoryIdentityResources(Config.IdentityResources)
            .AddInMemoryApiResources(Config.ApiResources)
            .AddDeveloperSigningCredential()
            .AddTestUsers(new List<TestUser>
            {
                new TestUser{ Username="test", Password="password", IsActive= true, }
            })
            .AddOperationalStore(opt =>
            {
                opt.ConfigureDbContext = builder => builder.UseSqlServer(this.DefaultConnectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
                opt.EnableTokenCleanup = true;
            })
            .AddConfigurationStore(opt =>
            {
                opt.ConfigureDbContext = builder => builder.UseSqlServer(this.DefaultConnectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
            })
            .AddAspNetIdentity<ApplicationUser>();


            services.AddHealthChecks()
                .AddAsyncCheck("self", async () => await Task.Run(() => HealthCheckResult.Healthy()))
                .AddSqlServer(
                    DefaultConnectionString,
                    name: "IdentityDb-Hc",
                    tags: new string[] { "IdentityDb", "hc" }
                );

            services.AddControllers();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();

            }

            app.UseStaticFiles();
            app.UseForwardedHeaders();

            app.UseIdentityServer();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();

                endpoints.MapHealthChecks("/hc", new HealthCheckOptions());
            });
        }
    }
}
