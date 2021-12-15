using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5_Gadgets.Models
{
    public class appointment
    {
        //Getters and Setters for appointment class properties
        public int appointmentID { get; set; }

        public DateTime appointmentDate { get; set; }


        public int salesRepID { get; set; }

        public virtual SalesRep salesRep { get; set; }

        public string salesRepFName { get; set; }

        public string salesRepLName { get; set; }

        public string fullname { get { return this.salesRepFName + " " + this.salesRepFName; } }

        public int customerID { get; set; }

        public virtual customer customer { get; set; }

    }
}

