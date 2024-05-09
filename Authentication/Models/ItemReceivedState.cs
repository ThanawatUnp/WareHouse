using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Models
{
    public class ItemReceivedState
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "State")]
        public string state { get; set; }

        public virtual ICollection<ItemReceived> ItemReceived { get; set; }

        public virtual ICollection<OutboundItem> OutboundItem { get; set; }
    }
}
