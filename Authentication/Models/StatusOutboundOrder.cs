using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Models
{
    public class StatusOutboundOrder
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

        public Guid OutboundOrderId { get; set; }
        public virtual ICollection<OutboundOrder> OutboundOrder { get; set; }
    }
}
