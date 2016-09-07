using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBillBoard.Models
{
    public class Authority
    {
        public string id { get; set; }
        public string accountid { get; set; }
        public string soldid { get; set; }
        public bool permission { get; set; }
    }
}
