using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace VFSolution.PIM.Persistence.Migrations
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<VFDbContext>
    {
        public VFDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<VFDbContext>();
            var connectionString = "Server=localhost;port=5432;Database=vfdb;UserId=admin;Password=Aa123456";
            builder.UseNpgsql(connectionString);
            return new VFDbContext(builder.Options);
        }
    }
}
