using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBillBoard.Models
{
    public class SaleInfo
    {
        public string boardid { get; set; }
        public string accountid { get; set; }
        public string id { get; set; }
        public string soldfirstday
        {
            get { return soldfirstday; }

            set { soldfirstday = DateTime.Now.ToString(); }
        }
        public string soldlastday
        {
            get { return soldlastday; }

            set { soldlastday = (howmanydayissold - Convert.ToInt64(soldfirstday)).ToString(); }
        }
        public int howmanydayissold { get; set; }
    }
}
