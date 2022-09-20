using CustomerDatabaseTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerDatabaseTutorial.Repository
{
    public class SqlTutorialRepository : ITutorialRepository
    {
        public ICustomerRepository Customers => new SqlCustomerRepository(new CustomerContext(_dbOptions));

        private DbContextOptions<CustomerContext> _dbOptions;

        public SqlTutorialRepository(DbContextOptionsBuilder<CustomerContext> dbOptionsBuilder)
        {
            _dbOptions = dbOptionsBuilder.Options;
            using (var db = new CustomerContext(_dbOptions))
            {
                db.Database.EnsureCreated();
            }
        }
    }
}