using ControllersExample.CustomModelBinders;
using ControllersExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        [Route("register")]
        public IActionResult Index([FromBody]
        // [ModelBinder(BinderType =typeof(PersonModelBinder))]
        UserPerson user)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n",
                    ModelState.Values
                        .SelectMany(value => value.Errors)
                        .Select(err => err.ErrorMessage));
                return BadRequest(errors);
            }
            return Content($"{user}");
        }
    }
}