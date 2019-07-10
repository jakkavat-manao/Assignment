using Microsoft.AspNetCore.Mvc;
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
            return new EmailAddressAttribute().IsValid(email ?? string.Empty) && email.Length < 26;
        }

        public static bool IsValidCustomerId(this int id)
        {
            return id > 0 && id.ToString().Length < 11;
        }
        public static BadRequestObjectResult ValidateCustomer(int id)
        {
            if (!id.IsValidCustomerId())
                return new BadRequestObjectResult("Invalid Customer ID");

            return null;
        }

        public static BadRequestObjectResult ValidateCustomer(string email)
        {
            if (!email.IsValidEmail())
                return new BadRequestObjectResult("Invalid Email");

            return null;
        }

        public static BadRequestObjectResult ValidateCustomer(int id, string email)
        {
            if (id == 0 && email == null)
                return new BadRequestObjectResult("No inquiry criteria");

            if (ValidateCustomer(id) != null)
                return ValidateCustomer(id);

            if (ValidateCustomer(email) != null)
                return ValidateCustomer(email);

            return null;

        }


    }
}
