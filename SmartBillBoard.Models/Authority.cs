using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBillBoard.Models
{
    public class Authority
    {
        public Accounts User { get; set; }
        public BoardLocation Sold { get; set; }
        public bool Permission { get; set; }
    }
}
