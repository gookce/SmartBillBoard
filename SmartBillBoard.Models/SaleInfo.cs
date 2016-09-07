using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBillBoard.Models
{
    public class SaleInfo
    {
        public static int BoardId { get; set; }
        public static int AccountId { get; set; }
        public static int SoldId { get; set; }
        public static string SoldFirstDay
        {
            get { return SoldFirstDay; }

            set { SoldFirstDay = DateTime.Now.ToString(); }
        }
        public static string SoldLastDay
        {
            get { return SoldLastDay; }

            set { SoldLastDay = (HowManyDayIsSold - Convert.ToInt64(SoldFirstDay)).ToString(); }
        }
        public static int HowManyDayIsSold { get; set; }
    }
}
