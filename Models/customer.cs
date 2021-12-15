using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5_Gadgets.Models
{
    public class customer
    {
        //Getters and setters for customer class properties 
        public int customerID { get; set; }

        public string customerFName { get; set; }

        public string customerLName { get; set; }

        public string customerPhonenumber { get; set; }

        public string customerEmail { get; set; }

        //class function used to validate inputted data
        public bool vaildateInfo(string customerFName, string customerLName, string customerPhonenumber, string customerEmail)
        {

            if (string.IsNullOrEmpty(customerFName) || string.IsNullOrEmpty(customerLName) || string.IsNullOrEmpty(customerPhonenumber) || string.IsNullOrEmpty(customerEmail))
            {

                return false;
            }
            else
            {
                long num = 0;
                if (customerPhonenumber.Length == 10 && Int64.TryParse(customerPhonenumber, out num) && customerFName.Length > 1 && customerLName.Length > 1 && IsValidEmail(customerEmail))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //class function used to validate emails
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
