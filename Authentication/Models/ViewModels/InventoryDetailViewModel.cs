using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Models
{
    public class InventoryDetailViewModel
    {
        public string orderNo { get; set; }
        public string lotNo { get; set; }
        public string itemCode { get; set; }
        public string itemName { get; set; }
        public string itemCategory { get; set; }
        public double? cost { get; set; }
        public int unit { get; set; }
        public DateTime receiveDate { get; set; }
        public string locationCode { get; set; }
        public string locationName { get; set; }
        public string status { get; set; }
    }
}
