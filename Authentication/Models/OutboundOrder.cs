using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Models
{
    public class OutboundOrder
    {
        [Key]
        [Display(Name = "ID")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please Enter Order Number.")]
        [Remote("checkOrderNo", "OutboundOrders", ErrorMessage = "Order No is Already Exist.")]
        [Display(Name = "Order Number")]
        public string order_no { get; set; }

        [Display(Name = "Plan Ship Date")]
        [DataType(DataType.DateTime)]
        public DateTime? plan_ship_date { get; set; }

        [Display(Name = "Invoice Number")]
        public string invoice_no { get; set; }

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

        [Display(Name = "Cancel By")]
        public string cancel_by { get; set; }

        [Display(Name = "Cancel Date")]
        [DataType(DataType.DateTime)]
        public DateTime? cancel_date { get; set; }

        [Display(Name = "Cancel Remark")]
        public string cancel_remark { get; set; }

        public string user_define1 { get; set; }

        public string user_define2 { get; set; }

        public string user_define3 { get; set; }

        [Required(ErrorMessage = "Please Select Type.")]
        [Display(Name = "Order Type")]
        public int? OrderTypeId { get; set; }
        public virtual OrderType OrderType { get; set; }

        [Display(Name = "Status")]
        public Guid StatusOutboundOrderId { get; set; }
        public virtual StatusOutboundOrder StatusOutboundOrder { get; set; }

        [Display(Name = "Customer")]
        public Guid? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<OutboundItem> OutboundItem { get; set; }
    }
}
