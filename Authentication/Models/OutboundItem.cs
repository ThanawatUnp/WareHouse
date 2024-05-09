using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Models
{
    public class OutboundItem
    {
        [Key]
        [Display(Name = "ID")]
        public Guid Id { get; set; }

        [Display(Name = "Cost")]
        public double? cost { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Please Enter Quantity.")]
        [Remote("CheckQuantity", "OutboundOrders")]
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

        public Guid OutboundOrderId { get; set; }
        public virtual OutboundOrder OutboundOrder { get; set; }

        [Display(Name = "Item Name")]
        [Required(ErrorMessage = "Please Select Item.")]
        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }

        [Display(Name = "State")]
        public int? ItemReceivedStateId { get; set; }
        public virtual ItemReceivedState ItemReceivedState { get; set; }
    }
}
