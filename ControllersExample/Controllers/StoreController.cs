using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    [Route("store")]
    public class StoreController : Controller
    {

        [Route("books/{id}")]
        public IActionResult Books()
        {
            int id = Convert.ToInt32(Request.RouteValues["id"]);
            return Content($"Book Store {id}");
        }
    }
}