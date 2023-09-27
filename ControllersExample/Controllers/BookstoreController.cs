using Microsoft.AspNetCore.Mvc;
using ControllersExample.Models;

namespace ControllersExample.Controllers
{
    [Route("bookstore")]
    public class BookstoreController : Controller
    {

        [Route("{bookId?}/{isLoggedIn?}")]
        public IActionResult Index([FromRoute] int? bookId, [FromQuery] bool? isLoggedIn, Book book)
        {
            if (bookId.HasValue == false)
            {
                return BadRequest("Book id is not supplied");
            }

            if (bookId <= 0)
            {
                return BadRequest("Book id can't be less than or equal to zero");
            }

            if (isLoggedIn == false)
            {
                return StatusCode(401);
            }

            return Content($"Book id: {bookId}, Book: {book}");

            // return RedirectToActionPermanent("Books", "Store", new { id = bookId });
        }
    }
}