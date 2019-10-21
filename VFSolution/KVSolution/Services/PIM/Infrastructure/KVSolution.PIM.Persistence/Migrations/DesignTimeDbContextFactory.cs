using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace KVSolution.PIM.Persistence.Migrations
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<KVDbContext>
    {
        public KVDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<KVDbContext>();
            var connectionString = "Server=localhost;port=5432;Database=kvdb;UserId=admin;Password=Aa123456";
            builder.UseNpgsql(connectionString);
            return new KVDbContext(builder.Options);
        }
    }
}
