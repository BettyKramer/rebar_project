using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDataAcsses.Models
{
    public class SaleModel
    {
        public int price { get; set; }
        public string name { get; set; }
        public DateTime endDate { get; set; }
        public DateTime startDate { get; set; }
    }
}
