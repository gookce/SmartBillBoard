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
        public string id { get; set; }
        public Byte[] photo { get; set; }
        public string photopath { get; set; }        
    }
}
