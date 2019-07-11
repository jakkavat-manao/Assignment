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
    public class ValidateGetByIdAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;

            if (descriptor != null)
            {
                var parameters = descriptor.MethodInfo.GetParameters();

                ValidateCustomerById(context, parameters);
            }

            base.OnActionExecuting(context);
        }

        private void ValidateCustomerById(ActionExecutingContext context, ParameterInfo[] parameters)
        {
            if (!context.ActionArguments.Any())
                context.ModelState.AddModelError("error", $"Please enter the Customer ID");

            if (context.ActionArguments.Select(x => x.Key).Contains("id"))
            {
                if (!ValidateExtension.IsValidCustomerId(context.ActionArguments.Select(x => (int)x.Value).SingleOrDefault()))
                    context.ModelState.AddModelError("error", $"Invalid Customer ID");
            }

            if (context.ModelState.ErrorCount != 0)
                context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }
}
