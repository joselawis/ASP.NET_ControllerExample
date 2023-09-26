using Microsoft.AspNetCore.Mvc;
using ControllersExample.Models;

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
            return Json(person);
        }

        [Route("file-download")]
        public VirtualFileResult FileDownload()
        {
            return File("/header.jpeg", "image/jpeg");
        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownload2()
        {
            return PhysicalFile(@"/Users/joseluiscontreras/aspnetcore/ControllersExample/ControllersExample/wwwroot/header.jpeg", "image/jpeg");
        }

        [Route("file-download3")]
        public IActionResult FileDownload3()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"/Users/joseluiscontreras/aspnetcore/ControllersExample/ControllersExample/wwwroot/header.jpeg");
            return File(bytes, "image/jpeg");
        }
    }
}

