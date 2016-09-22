using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBillBoard.Models
{
    public class Board
    {
        public string id { get; set; }
        public string boardname { get; set; }
        public int price { get; set; }
        public DateTime firstdayforsale { get; set; }
        public DateTime lastdayforsale { get; set; }
        public string username { get; set; }
        public string userid { get; set; }
    }
}
