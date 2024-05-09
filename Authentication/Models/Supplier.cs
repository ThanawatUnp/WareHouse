using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Models
{
    public class Supplier
    {
        [Key]
        [Display(Name = "ID")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please Enter Supplier Code.")]
        [Remote("checkSupplierCode", "Suppliers", ErrorMessage = "Supplier Code is Already Exist.")]
        [Display(Name = "Supplier Code")]
        public string supplier_code { get; set; }

        [Required(ErrorMessage = "Please Enter Supplier Name.")]
        [Remote("checkSupplierName", "Suppliers")]
        [Display(Name = "Supplier Name")]
        public string supplier_name { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Category")]
        public string category { get; set; }

        [Display(Name = "Priority")]
        public string priority { get; set; }

        [Display(Name = "Address1")]
        public string address1 { get; set; }

        [Display(Name = "Address2")]
        public string address2 { get; set; }

        [Display(Name = "Address3")]
        public string address3 { get; set; }

        [Display(Name = "Zipcode")]
        public string zipcode { get; set; }

        [Remote("checkPhoneNumber", "Suppliers")]
        [Display(Name = "Phone")]
        public string phone_no { get; set; }

        [Remote("checkMobileNumber", "Suppliers")]
        [Display(Name = "Mobile")]
        public string mobile_no { get; set; }

        [Display(Name = "Fax")]
        public string fax_no { get; set; }

        [Display(Name = "E-mail")]
        public string email { get; set; }

        [Display(Name = "Contact")]
        public string contact { get; set; }

        [Display(Name = "Active")]
        public bool active { get; set; }

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

        [Display(Name = "Select Image")]
        public string file_name { get; set; }

        [Display(Name = "Province")]
        public int? ProvinceId { get; set; }
        //[ForeignKey("Province_Id")]
        public virtual Province Province { get; set; }

        [Display(Name = "District")]
        public int? DistrictId { get; set; }
        //[ForeignKey("District_Id")]
        public virtual District District { get; set; }

        [Display(Name = "Sub-District")]
        public int? SubDistrictId { get; set; }
        //[ForeignKey("SubDistrict_Id")]
        public virtual SubDistrict SubDistrict { get; set; }

        public virtual ICollection<InboundOrder> InboundOrder { get; set; }
    }
}
