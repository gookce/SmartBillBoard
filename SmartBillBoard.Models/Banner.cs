using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBillBoard.Models
{
    public class Banner
    {
        public int PhotoId { get; set; }
        public static Binary Photo { get; set; }
        public static Binary PhotoPath { get; set; }        
    }
}
