using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EFDbFirstApproach.Models
{
    public class Product
    {
        [Key]
        [Display(Name ="Product ID")]
        public long ProductID { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Product Price")]
        public Nullable<decimal> Price { get; set; }

        [Display(Name = "Date Of Purchase")]
        public Nullable<System.DateTime> DateOfPurchase { get; set; }

        [Display(Name = "Avaliability Status")]
        public string AvailabilityStatus { get; set; }

        [Display(Name = "Category ID")]
        public Nullable<long> CategoryID { get; set; }

        [Display(Name = "Brand ID")]
        public Nullable<long> BrandID { get; set; }

        [Display(Name = "Active")]
        public Nullable<bool> Active { get; set; }

        [Display(Name = "Quantity")]
        public Nullable<decimal> Quantity { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}