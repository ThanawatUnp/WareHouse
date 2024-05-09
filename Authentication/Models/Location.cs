using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Models
{
    public class Location
    {
        [Key]
        [Display(Name = "ID")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please Enter Location Code.")]
        [Remote("checkLocationCode", "Locations", ErrorMessage = "Location Code is Already Exist.")]
        [Display(Name = "Location Code")]
        public string location_code { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Mix Expire")]
        public bool mix_expire { get; set; }

        [Display(Name = "Mix Item")]
        public bool mix_item { get; set; }

        [Display(Name = "Mix Lot")]
        public bool mix_lot { get; set; }

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

        [Required(ErrorMessage = "Please Select Category.")]
        [Display(Name = "Location Category")]
        public Guid LocationCategoryId { get; set; }
        //[ForeignKey("Province_Id")]
        public virtual LocationCategory LocationCategory { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
