using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Models
{
    public class SubDistrict
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int Id { get; set; }

        //[Remote("IsCustomerAvailble", "Customers", ErrorMessage = "Customer Code is Already Exist.")]
        [Display(Name = "SubDistrict Code")]
        public string SubDistrict_Code { get; set; }

        [Display(Name = "SubDistrict Thai")]
        public string SubDistrict_Thai { get; set; }

        [Display(Name = "SubDistrict Eng")]
        public string SubDistrict_Eng { get; set; }

        [Display(Name = "Zipcode")]
        public string zipcode { get; set; }

        public int? DistrictId { get; set; }
        //[ForeignKey("District_Id")]
        public virtual District District { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }

        public virtual ICollection<Supplier> Supplier { get; set; }
    }
}
