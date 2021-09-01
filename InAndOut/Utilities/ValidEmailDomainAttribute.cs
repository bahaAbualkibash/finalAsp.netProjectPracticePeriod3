using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Utilities
{
    public class ValidEmailDomainAttribute : ValidationAttribute
    {
        private string[] emails = {"movieEzy.com", "gmail.com", "yahoo.com", "email.com", "Outlook.com", "aol.com", "hotmail.co.uk", "msn.com", "hotmail.fr", "mail.ru" };

        public string AllowedDomain { get; }

        public override bool IsValid(object value)
        {
           string[] strings =  value.ToString().Split('@');
            return checkIfEmailValid(strings[1]);

        }

        private bool checkIfEmailValid(string value)
        {
            foreach(var email in emails)
            {
                if (value.ToUpper().Equals(email.ToUpper()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
