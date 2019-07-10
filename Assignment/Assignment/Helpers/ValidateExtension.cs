using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Helpers
{
    public static class ValidateExtension
    {
        public static bool IsValidEmail(this string email)
        {
            return new EmailAddressAttribute().IsValid(email) && email.Length < 26;
        }

        public static bool IsValidCustomerId(this int id)
        {
            return id > 0 && id.ToString().Length < 11;
        }
    }
}
