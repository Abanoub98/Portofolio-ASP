using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Portofolio.Database;
using Portofolio.AppModels.Extensions;
using Microsoft.EntityFrameworkCore;
namespace Portofolio
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
            services.AddControllersWithViews();
            string connString = Configuration.GetConnectionString("PortofolioMySQLConn");
            services.AddDbContextPool<PortofolioDbContext>(options =>
            {
                options.UseMySql(connString, ServerVersion.AutoDetect(connString), dbOptions =>
                {
                    dbOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                });
            });
            services.AddRepositories();
            services.AddServices();
            services.ConfigureServices(Configuration);
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.Use(async (cxt, next) =>
            {
                await next();
                if (cxt.Response.StatusCode == 404)
                {
                    cxt.Response.Redirect("/Errors/Error404");
                }
                else if (cxt.Response.StatusCode == 401)
                {
                    cxt.Response.Redirect("/Errors/Error401");
                }
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
