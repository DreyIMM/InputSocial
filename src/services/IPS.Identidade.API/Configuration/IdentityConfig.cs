﻿using IPS.Identidade.API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IPS.WebApi.Core.Identidade;
using IPS.Identidade.API.Extensions;

namespace IPS.Identidade.API.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services,
                                                                  IConfiguration Configuration)
        {
            //Configurando o DBContext para o Identity
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            //Configuração para o Suporte ao Identity
            services.AddDefaultIdentity<IdentityUser>()
               .AddRoles<IdentityRole>()
               .AddErrorDescriber<IdentityMensagensPortugues>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();

            services.AddJwtConfiguration(Configuration);


            return services;
        }

    }
}
