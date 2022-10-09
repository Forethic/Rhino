using Inventory.ViewModels;
using System;

namespace Inventory.Models
{
    public class OrderModel : ModelBase
    {
        public static OrderModel CreateEmpty() => new OrderModel { OrderID = -1, CustomerID = -1, IsEmpty = true };

        public long OrderID { get; set; }

        public long CustomerID { get; set; }

        public DateTimeOffset OrderDate { get; set; }
    }
}