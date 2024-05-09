using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Models
{
    public class InboundOrder
    {
        [Key]
        [Display(Name = "ID")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please Enter Order Number.")]
        [Remote("checkOrderNo", "InboundOrders", ErrorMessage = "Order No is Already Exist.", AdditionalFields ="Id")]
        [Display(Name = "Order Number")]
        public string order_no { get; set; }

        [Required(ErrorMessage = "Please Select Date.")]
        [Display(Name = "Expect Date")]
        [DataType(DataType.DateTime)]
        public DateTime expect_date { get; set; }

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

        [Display(Name = "Close By")]
        public string close_by { get; set; }

        [Display(Name = "Close Date")]
        [DataType(DataType.DateTime)]
        public DateTime? close_date { get; set; }

        [Display(Name = "Close Remark")]
        public string close_remark { get; set; }

        public string user_define1 { get; set; }

        public string user_define2 { get; set; }

        public string user_define3 { get; set; }

        [Required(ErrorMessage = "Please Select Type.")]
        [Display(Name = "Order Type")]
        public int? OrderTypeId { get; set; }
        public virtual OrderType OrderType { get; set; }

        [Display(Name = "Status")]
        public Guid StatusInboundOrderId { get; set; }
        public virtual StatusInboundOrder StatusInboundOrder { get; set; }

        [Display(Name = "Supplier")]
        public Guid? SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        [Display(Name = "Customer")]
        public Guid? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<InboundItem> InboundItem { get; set; }
    }
}
