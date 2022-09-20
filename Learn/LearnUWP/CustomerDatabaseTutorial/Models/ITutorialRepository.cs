namespace CustomerDatabaseTutorial.Models
{
    public interface ITutorialRepository
    {
        ICustomerRepository Customers { get; }
    }
}