using Microsoft.EntityFrameworkCore;
namespace MyCoreApplication.Models
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> Person { get; set; }

        public PersonContext(DbContextOptions<PersonContext> options) :
            base(options)
        {
        }
    }
}