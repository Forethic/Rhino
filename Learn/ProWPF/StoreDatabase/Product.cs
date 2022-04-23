using Rhino.Mvvm;
using System;

namespace ProWPF.StoreDatabase
{
    public class Product : NotifyObject
    {
        private string _modelNumber;
        public string ModelNumber
        {
            get => _modelNumber;
            set => Update(ref _modelNumber, value);
        }

        private string _modelName;
        public string ModelName
        {
            get => _modelName;
            set => Update(ref _modelName, value);
        }

        private decimal _unitCost;
        public decimal UnitCost
        {
            get => _unitCost;
            set => Update(ref _unitCost, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => Update(ref _description, value);
        }

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

        private string _productImagePath;
        public string ProductImagePath
        {
            get => _productImagePath;
            set => Update(ref _productImagePath, value);
        }

        private DateTime DateAdded { get; set; } = DateTime.Today;

        public Product(string modelNumber, string modelName, decimal unitCost, string description)
        {
            ModelName = modelName;
            ModelNumber = modelNumber;
            UnitCost = unitCost;
            Description = description;
        }

        public Product(string modelNumber, string modelName, decimal unitCost, string description, int categoryID, string categoryName, string productImagePath)
            : this(modelNumber, modelName, unitCost, description)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
            ProductImagePath = productImagePath;
        }

        public override string ToString() => $"{ModelName} ({ModelNumber})";
    }
}