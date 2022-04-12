using Microsoft.AspNetCore.Mvc;
using SO.ToDo.Web.Models;

namespace SO.ToDo.Web.ViewComponents
{
    public class Products : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("New", new List<CustomerViewModel>()
            {
                new (){Name = "Test 1"},
                new (){Name = "Test 2"},
                new (){Name = "Test 3"},
                new (){Name = "Test 4"},
                new (){Name = "Test 5"},
                new (){Name = "Test 6"},
            });
        }
    }
}
