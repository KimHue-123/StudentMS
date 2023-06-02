using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace StudentMS.Data.EF
{
    public class StudentMSDbContextFactory : IDesignTimeDbContextFactory<StudentMSDbContext>
    {
        public StudentMSDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("StudentDatabase");

            var optionBuilder = new DbContextOptionsBuilder<StudentMSDbContext>();
            optionBuilder.UseSqlServer(connectionString);

            return new StudentMSDbContext(optionBuilder.Options);
        }
    }
}
