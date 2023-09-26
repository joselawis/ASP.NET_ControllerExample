using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    [Route("bookstore")]
    public class BookstoreController : Controller
    {

        [Route("{id}")]
        public IActionResult Index()
        {
            int bookId = Convert.ToInt32(Request.RouteValues["id"]);
            return RedirectToActionPermanent("Books", "Store", new { id = bookId });

            // return LocalRedirectPermanent($"/store/books/{bookId}");

            // return RedirectPermanent($"store/books/{bookId}");
        }
    }
}