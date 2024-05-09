using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Models
{
    public class OrderType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Order Type")]
        public string order_type { get; set; }

        [Required]
        public string type { get; set; }

        public virtual ICollection<InboundOrder> InboundOrder { get; set; }

        public virtual ICollection<OutboundOrder> OutboundOrder { get; set; }
    }
}
