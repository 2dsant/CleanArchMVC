using Microsoft.Extensions.DependencyInjection;
using CleanArchMVC.Infra.Data.Repositories;
using CleanArchMVC.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using CleanArchMVC.Application.Mappings;
using CleanArchMVC.Application.Services;
using CleanArchMVC.Infra.Data.Identity;
using CleanArchMvc.Infra.Data.Identity;
using CleanArchMVC.Infra.Data.Context;
using CleanArchMVC.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CleanArchMVC.Domain.Account;
using MediatR;
using System;

namespace CleanArchMVC.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
            );

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
                options.AccessDeniedPath = "/account/login");

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            var myHandlers = AppDomain.CurrentDomain.Load("CleanArchMVC.Application");
            services.AddMediatR(myHandlers);
            return services;
        }
    }
}
