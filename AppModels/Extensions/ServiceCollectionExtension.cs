using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portofolio.AppModels.Repositories;
using Portofolio.Models;
using Portofolio.AppModels.Services;
using Portofolio.AppModels.Models;
using Portofolio.Database;
using Microsoft.AspNetCore.Identity;
using System;
using static Portofolio.AppModels.Utils.Constants;
namespace Portofolio.AppModels.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(ContactRepository));
            services.AddTransient(typeof(ContactStatusRepository));
            services.AddTransient(typeof(ServicesRepository));
            services.AddTransient(typeof(ProjectsRepository));
            services.AddTransient(typeof(RequestedServicesRepository));
            services.AddTransient(typeof(UIPRepository));
            services.AddTransient(typeof(UserLinksRepository));
            services.AddTransient(typeof(LinkTypesRepository));
            services.AddTransient(typeof(ProjectFeedbacksRepository));
            services.AddTransient(typeof(ProjectImagesRepository));
            services.AddTransient(typeof(ProjectLinksRepository));
            services.AddTransient(typeof(ProjectTypeRepository));
            services.AddTransient(typeof(UserRoleInProjectRepository));
            services.AddTransient(typeof(ProjectLogsRepository));
            services.AddTransient(typeof(UserCertificatesRepository));
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(BasePaginator<Project>), typeof(ProjectsPaginator));
            services.AddTransient(typeof(BasePaginator<User>), typeof(MembersPaginator));
            services.AddTransient(typeof(BasePaginator<Service>), typeof(ServicesPaginator));
            services.AddTransient(typeof(IMailService), typeof(MailService));
            services.AddTransient(typeof(IEmailParserFromModelAsync<HTMLWithModel<Contact>>), typeof(HTMLWithContactEmailParser));
            services.AddTransient(typeof(IEmailParserFromModelAsync<HTMLModel>), typeof(HTMLEmailParser));
            services.AddTransient(typeof(IImageServices), typeof(ImageServices));
            services.AddTransient(typeof(IDisplayOutput), typeof(OutputDisplayer));
            services.AddIdentity<User, UserRole>().AddEntityFrameworkStores<PortofolioDbContext>().AddRoles<UserRole>().AddDefaultTokenProviders();
            services.AddAuthorization((options) =>
            {
                options.AddPolicy("Admin", (policy) =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireRole("Admin");
                });
            });
        }

        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireUppercase = false;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ";
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = new TimeSpan(0, 5, 0);
                options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/user/login");
                options.LogoutPath = new Microsoft.AspNetCore.Http.PathString("/user/logout");
                options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/errors/error401");
            });
        }
    }
}