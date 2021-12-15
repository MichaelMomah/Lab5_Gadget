using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5_Gadgets.Models
{
    public class SalesRep
    {
        //getters and setters for the salesRep properties
        public int salesRepID { get; set; }

        public string salesRepFName { get; set; }

        public string salesRepLName { get; set; }

        public string salesRepExt { get; set; }

        public string fullname { get { return this.salesRepFName + " " + this.salesRepLName; } }

        //class function used for validating the salesRep inputs
        public bool vaildatesalesrep(string salesRepFName, string salesRepLName, string salesRepExt)
        {
            if (string.IsNullOrEmpty(salesRepFName) || string.IsNullOrEmpty(salesRepLName) || string.IsNullOrEmpty(salesRepExt))
            {

                return false;
            }
            else
            {
                long num = 0;
                if (salesRepExt.Length == 3 && Int64.TryParse(salesRepExt, out num) && salesRepFName.Length > 1 && salesRepLName.Length > 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }




    }
}
