using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Models
{
    public class Province
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int Id { get; set; }

        //[Remote("IsCustomerAvailble", "Customers", ErrorMessage = "Customer Code is Already Exist.")]
        [Display(Name = "Province Code")]
        public string Province_Code { get; set; }

        [Display(Name = "Province Thai")]
        public string Province_Thai { get; set; }

        [Display(Name = "Province Eng")]
        public string Province_Eng { get; set; }

        public virtual ICollection<District> District { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }

        public virtual ICollection<Supplier> Supplier { get; set; }
    }
}
