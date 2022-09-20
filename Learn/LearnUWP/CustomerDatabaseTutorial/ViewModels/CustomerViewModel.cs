using CustomerDatabaseTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatabaseTutorial.ViewModels
{
    public class CustomerViewModel
    {
        internal Customer Model { get; set; }

        internal bool IsModified { get; set; }

        public string FirstName
        {
            get => Model.FirstName;
            set
            {
                if (Model.FirstName != value)
                {
                    Model.FirstName = value;
                    IsModified = true;
                }
            }
        }

        public string LastName
        {
            get => Model.LastName;
            set
            {
                if (Model.LastName != value)
                {
                    Model.LastName = value;
                    IsModified = true;
                }
            }
        }

        public string Address
        {
            get => Model.Address;
            set
            {
                if (Model.Address != value) { }
                Model.Address = value;
                IsModified = true;
            }
        }

        public string Company
        {
            get => Model.Company;
            set
            {
                if (Model.Company != value)
                {
                    Model.Company = value;
                    IsModified = true;
                }
            }
        }

        public CustomerViewModel(Customer model)
        {
            Model = model ?? new Customer();
        }
    }
}