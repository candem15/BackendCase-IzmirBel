using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Attributes
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context == null)
                return Task.CompletedTask;
            else if (next == null)
                return Task.CompletedTask;
            else if (context.HttpContext == null)
                return Task.CompletedTask;
            else if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(x=>x.Value.Errors.Any())
                    .ToDictionary(x=>x.Key, x => x.Value.Errors.Select(x=>x.ErrorMessage));

                context.Result = new BadRequestObjectResult(errors);

                return Task.FromResult(context);
            }

            return next();
        }
    }
}
