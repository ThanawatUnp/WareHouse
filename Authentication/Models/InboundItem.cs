using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Models
{
    public class InboundItem
    {
        [Key]
        [Display(Name = "ID")]
        public Guid Id { get; set; }

        [Display(Name = "Line Number")]
        public string line_no { get; set; }

        [Display(Name = "Cost")]
        public double? cost { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Please Enter Quantity.")]
        [Remote("CheckQuantity", "InboundOrders")]
        public int qty { get; set; }

        [Display(Name = "Remain Quntity")]
        public int remain_qty { get; set; }

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

        public Guid InboundOrderId { get; set; }
        public virtual InboundOrder InboundOrder { get; set; }

        [Display(Name = "Item Name")]
        [Required(ErrorMessage = "Please Select Item.")]
        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }

        public virtual ICollection<ItemReceived> ItemReceived { get; set; }
    }
}
