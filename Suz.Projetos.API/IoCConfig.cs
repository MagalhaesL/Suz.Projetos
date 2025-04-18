﻿using Microsoft.EntityFrameworkCore;
using Suz.Projetos.Domain.Interfaces;
using Suz.Projetos.Persistence;
using Suz.Projetos.Respository;
using Suz.Projetos.Service;

namespace Suz.Projetos.API
{
    public static class IoCConfig
    {
        public static IServiceCollection ApplyIoC(this IServiceCollection services)
        {
            services.AddTransient<DbContext, ProjetosContext>();

            services.AddTransient<IProjetoRepository, ProjetoRepository>();

            services.AddTransient<IPessoaRepository, PessoaRepository>();
            services.AddTransient<IPessoaService, PessoaService>();

            return services;
        }
    }
}
