using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Models
{
    public class Item
    {
        [Key]
        [Display(Name = "ID")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please Enter Item Code.")]
        [Remote("checkItemCode", "Items", ErrorMessage = "Item Code is Already Exist.")]
        [Display(Name = "Item Code")]
        public string item_code { get; set; }

        [Required(ErrorMessage = "Please Enter Item Name.")]
        [Remote("checkItemName", "Items")]
        [Display(Name = "Item Name")]
        public string item_name { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Cost")]
        public double? cost { get; set; }


        [Display(Name = "Unit")]
        public int? unit { get; set; }

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

        [Display(Name = "Select Image")]
        public string file_name { get; set; }

        public string user_define1 { get; set; }

        public string user_define2 { get; set; }

        public string user_define3 { get; set; }

        [Display(Name = "Item Category")]
        public Guid ItemCategoryId { get; set; }
        //[ForeignKey("Province_Id")]
        public virtual ItemCategory ItemCategory { get; set; }

        [Display(Name = "Queue Category")]
        public int? QueueTypeId { get; set; }
        public virtual QueueType QueueType { get; set; }

        public virtual ICollection<InboundItem> InboundItem { get; set; }

        public virtual ICollection<OutboundItem> OutboundItem { get; set; }
    }
}
