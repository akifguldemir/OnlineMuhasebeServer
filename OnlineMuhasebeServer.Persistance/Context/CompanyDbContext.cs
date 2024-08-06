using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.AppEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Persistance.Context
{
    public sealed class CompanyDbContext : DbContext
    {
        private string ConnectionString = "";
        private readonly AppDbContext _appDbContext;

        public CompanyDbContext(string CompanyId, AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            Company company = _appDbContext.Companies.Find(CompanyId);
            if(company.UserId == "")
                ConnectionString = $"" +
                    $"Data Source={company.ServerName};" +
                    $"Initial Catalog={company.DatabaseName};" +
                    $"Integrated Security=True;" +
                    $"Connect Timeout=30;" +
                    $"Encrypt=True;Trust Server Certificate=True;" +
                    $"Application Intent=ReadWrite" +
                    $";Multi Subnet Failover=False";
            else
                ConnectionString = $"" +
                    $"Data Source={company.ServerName};" +
                    $"Initial Catalog={company.DatabaseName};" +
                    $"User Id={company.UserId}; " +
                    $"Password={company.Password} Integrated Security=True;" +
                    $"Connect Timeout=30;" +
                    $"Encrypt=True;Trust Server Certificate=True;" +
                    $"Application Intent=ReadWrite;" +
                    $"Multi Subnet Failover=False";

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
