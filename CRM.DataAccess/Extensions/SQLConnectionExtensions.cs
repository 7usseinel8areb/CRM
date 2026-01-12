using CRM.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Extensions
{
    public static class SQLConnectionExtensions
    {
        public static IServiceCollection AddSQLServerConnection(this IServiceCollection service, string connectionString)
        {
            service.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return service;
        }
    }
}
