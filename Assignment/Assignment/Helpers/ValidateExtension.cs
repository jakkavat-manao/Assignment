using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Helpers
{
    public static class ValidateExtension
    {
        public static bool IsValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email ?? string.Empty) && email.Length < 26;
        }

        public static bool IsValidCustomerId(int id)
        {
            return id >= 0 && id.ToString().Length <= 10;
        }

    }
}
