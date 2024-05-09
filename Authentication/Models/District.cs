using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Models
{
    public class District
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int Id { get; set; }

        //[Remote("IsCustomerAvailble", "Customers", ErrorMessage = "Customer Code is Already Exist.")]
        [Display(Name = "District Code")]
        public string District_Code { get; set; }

        [Display(Name = "District Thai")]
        public string District_Thai { get; set; }

        [Display(Name = "District Eng")]
        public string District_Eng { get; set; }

        public int? ProvinceId { get; set; }
        //[ForeignKey("Province_Id")]
        public virtual Province Province { get; set; }

        public virtual ICollection<SubDistrict> SubDistrict { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }

        public virtual ICollection<Supplier> Supplier { get; set; }
    }
}
