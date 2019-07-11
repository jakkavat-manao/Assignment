using Assignment.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Assignment.ActionFilters.Customer
{
    public class ValidateGetByEmailAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;

            if (descriptor != null)
            {
                var parameters = descriptor.MethodInfo.GetParameters();

                ValidateCustomerByEmail(context, parameters);
            }

            base.OnActionExecuting(context);
        }

        private void ValidateCustomerByEmail(ActionExecutingContext context, ParameterInfo[] parameters)
        {
            if (!context.ActionArguments.Any())
                context.ModelState.AddModelError("error", $"Please enter the email");
            
            if (context.ActionArguments.Select(x => x.Key).Contains("email"))
            {
                if (!context.ActionArguments.Select(x => (string)x.Value).SingleOrDefault().IsValidEmail())
                    context.ModelState.AddModelError("error", $"Invalid Email");
            }

            if (context.ModelState.ErrorCount != 0)
                context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }
}
