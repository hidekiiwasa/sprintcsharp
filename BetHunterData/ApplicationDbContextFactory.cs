using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using BetHunterData;

namespace BetHunterData
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseMySql("Server=localhost;Database=bethunter;Uid=root;Pwd=root",
                new MySqlServerVersion(new Version(8, 0, 42))); 

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
