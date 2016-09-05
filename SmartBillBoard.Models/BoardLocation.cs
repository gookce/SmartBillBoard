using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBillBoard.Models
{
    public class BoardLocation
    {
        public string LocationName { get; set; }
        public Accounts WhoIsBought
        {
            get { return WhoIsBought; }

            set
            {
                if (!IsSold)
                {
                    WhoIsBought.UserName = null;
                    WhoIsBought.Password = 0;
                }
            }
        }
        public bool IsSold { get; set; }
        public string SoldFirstDay
        {
            get { return SoldFirstDay; }

            set
            {
                if (IsSold)
                    SoldFirstDay = DateTime.Now.ToString();
            }
        }
        public string SoldLastDay
        {
            get { return SoldLastDay; }

            set
            {
                if (IsSold)
                    SoldLastDay = (HowManyDayIsSold-Convert.ToInt64(SoldFirstDay)).ToString();
            }
        }

        public int HowManyDayIsSold
        {
            get { return HowManyDayIsSold; }

            set
            {
                if (IsSold)
                    HowManyDayIsSold = value;
            }
        }
    }
}
