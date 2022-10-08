using Inventory.ViewModels;
using System;
using Windows.UI.Xaml.Media.Imaging;

namespace Inventory.Models
{
    public class CustomerModel : ModelBase
    {
        public static CustomerModel CreateEmpty() => new CustomerModel { IsEmpty = true, CustomerID = -1 };

        public long CustomerID { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Suffix { get; set; }

        public string Gender { get; set; }

        public string EmailAddress { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string Region { get; set; }
        public string CountryCode { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }

        public DateTimeOffset? BirthDate { get; set; }
        public string Education { get; set; }
        public string Occupation { get; set; }
        public decimal? YearlyIncome { get; set; }
        public string MaritalStatus { get; set; }
        public int? TotalChildren { get; set; }
        public int? ChildrenAtHome { get; set; }
        public bool? IsHouseOwner { get; set; }
        public int? NumberCarsOwned { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }

        public byte[] Picture { get; set; }
        public BitmapImage PictureBitmap { get; set; }
        public byte[] Thumbnail { get; set; }
        public BitmapImage ThumbBitmap { get; set; }

        public bool IsNew => CustomerID <= 0;
        public string FullName => $"{FirstName} {LastName}";
        public string Initials => $"{FirstName[0]}{LastName[0]}".Trim().ToUpper();
        public string CountryName { get; set; }


        public override string ToString() => IsEmpty ? "Empty" : FullName;
    }
}