using Rhino.Mvvm;
using System.Collections.ObjectModel;

namespace ProWPF.StoreDatabase
{
    public class Category : NotifyObject
    {
        private string _categoryName;
        public string CategoryName
        {
            get => _categoryName;
            set => Update(ref _categoryName, value);
        }

        private int _categoryID;
        public int CategoryID
        {
            get => _categoryID;
            set => Update(ref _categoryID, value);
        }

        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get => _products;
            set => Update(ref _products, value);
        }

        public Category(string categoryName, ObservableCollection<Product> products)
        {
            CategoryName = categoryName;
            Products = products;
        }

        public Category(string categoryName, int categoryID)
        {
            CategoryName = categoryName;
            CategoryID = categoryID;
        }
    }
}