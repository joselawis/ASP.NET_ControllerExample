using Microsoft.AspNetCore.Mvc;
using ControllersExample.Models
    ;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ControllersExample.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public ContentResult Index()
        {
            return Content("<h1>Welcome</h1> <h2>Hello from Index</h2>", "text/html");
        }

        [Route("person")]
        public JsonResult Person()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "James",
                LastName = "Smith",
                Age = 25
            };
            return new JsonResult(person);
        }

        [Route("contact-us/{mobile:regex(^\\d{{9}}$)}")]
        public string Contact()
        {
            return "Hello from Contact";
        }
    }
}

