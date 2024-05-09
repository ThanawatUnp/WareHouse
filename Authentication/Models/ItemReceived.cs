using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Models
{
    public class ItemReceived
    {
        [Key]
        [Display(Name = "ID")]
        public Guid Id { get; set; }

        [Display(Name = "Cost")]
        public double? cost { get; set; }

        [Required(ErrorMessage = "Please Enter Receive Quantity.")]
        [Remote("checkRcvQty", "InboundOrders", AdditionalFields = "Id,InboundItemId")]
        [Display(Name = "Receive Quantity")]
        public int receive_qty { get; set; }

        [Display(Name = "Remain Put Away")]
        public int remain_putaway { get; set; }

        [Display(Name = "Lot Number")]
        public string lot_no { get; set; }

        [Remote("checkExpireDate", "InboundOrders", AdditionalFields = "InboundItemId")]
        [Display(Name = "Expire Date")]
        [DataType(DataType.DateTime)]
        public DateTime? expire_date { get; set; }

        [Display(Name = "Receive Date")]
        [DataType(DataType.DateTime)]
        public DateTime receive_date { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "status")]
        public string status { get; set; }

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

        public Guid InboundItemId { get; set; }
        public virtual InboundItem InboundItem { get; set; }

        [Required(ErrorMessage = "Please Select State.")]
        [Display(Name = "State")]
        public int ItemReceivedStateId { get; set; }
        public virtual ItemReceivedState ItemReceivedState { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }

    }
}
