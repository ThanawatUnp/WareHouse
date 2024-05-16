using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Models
{
    public class Inventory
    {
        [Key]
        [Display(Name = "ID")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please Enter Quantity.")]
        [Display(Name = "Quantity")]
        public int qty { get; set; }

        public string user_define1 { get; set; }

        public string user_define2 { get; set; }

        public string user_define3 { get; set; }

        [Display(Name = "Create By")]
        public string create_by { get; set; }

        [Display(Name = "Create Date")]
        [DataType(DataType.DateTime)]
        public DateTime create_date { get; set; }

        [Required(ErrorMessage = "Please Select Location.")]
        [Display(Name = "Location")]
        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }

        [Display(Name = "Item Received")]
        public Guid ItemReceivedId { get; set; }
        public virtual ItemReceived ItemReceived { get; set; }

        [Display(Name = "Status")]
        public Guid StatusInventoryId { get; set; }
        public virtual StatusInventory StatusInventory { get; set; }

        public int reserve { get; set; }
    }
}
