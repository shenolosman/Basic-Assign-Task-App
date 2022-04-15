using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SO.ToDo.Web.Models;

namespace SO.ToDo.Web.CustomFilters
{
    public class MyCustomFilters : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var dictinory = context.ActionArguments.Where(x => x.Key == "model").FirstOrDefault();
            var model = (UserRegisterViewModel)dictinory.Value;
            if (model.Name.ToLower() == "a")
                context.Result = new RedirectResult("\\Home\\Error");
        }
    }
}
