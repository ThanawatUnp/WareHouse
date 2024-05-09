using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Models
{
    public class LocationCategory
    {
        [Key]
        [Display(Name = "ID")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please Enter Category Name.")]
        [Remote("checkLocationCategory", "LocationCategories")]
        [Display(Name = "Category Name")]
        public string category_name { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Create By")]
        public string create_by { get; set; }

        [Display(Name = "Create Date")]
        [DataType(DataType.DateTime)]
        public DateTime create_date { get; set; }

        [Display(Name = "Edit By")]
        public string edit_by { get; set; }

        [Display(Name = "Edit Date")]
        [DataType(DataType.DateTime)]
        public DateTime? edit_date { get; set; }

        public string user_define1 { get; set; }

        public string user_define2 { get; set; }

        public string user_define3 { get; set; }

        public virtual ICollection<Location> Location { get; set; }
    }
}
