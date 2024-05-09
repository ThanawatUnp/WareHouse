using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Models
{
    public class StatusInventory
    {
        [Key]
        [Display(Name = "ID")]
        public Guid Id { get; set; }

        [Display(Name = "Status")]
        public string status { get; set; }

        [Display(Name = "Create By")]
        public string create_by { get; set; }

        [Display(Name = "Create Date")]
        [DataType(DataType.DateTime)]
        public DateTime create_date { get; set; }

        public Guid InventoryId { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
