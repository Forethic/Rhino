using CustomerDatabaseTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerDatabaseTutorial.Repository
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }
    }
}