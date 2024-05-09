using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Models
{
    public class StatusInboundOrder
    {
        [Key]
        [Display(Name = "ID")]
        public Guid Id { get; set; }

        [Display(Name = "Status")]
        public string status { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Create By")]
        public string create_by { get; set; }

        [Display(Name = "Create Date")]
        [DataType(DataType.DateTime)]
        public DateTime create_date { get; set; }

        public Guid InboundOrderId { get; set; }
        public virtual ICollection<InboundOrder> InboundOrder { get; set; }
    }
}
