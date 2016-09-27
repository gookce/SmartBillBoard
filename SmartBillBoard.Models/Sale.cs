using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBillBoard.Models
{
    public class Sale
    {
        public string id { get; set; }
        public string boardname { get; set; }
        public int price { get; set; }
        public string firstdayforsale { get; set; }
        public string lastdayforsale { get; set; }
        public string username { get; set; }
    }
}
