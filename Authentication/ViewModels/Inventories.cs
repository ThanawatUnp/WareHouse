using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.ViewModels
{
    public class Inventories
    {
        public Guid id { get; set; }
        public string itemCode { get; set; }
        public string itemName { get; set; }
        public string itemCategory { get; set; }
        public double? cost { get; set; }
        public int? unit { get; set; }
    }
}
