using Microsoft.EntityFrameworkCore;

namespace BlogDemo.API.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.; database=BlogDemoApiDB; integrated security=true;");
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
