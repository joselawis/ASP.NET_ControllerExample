using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ControllersExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ControllersExample.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {   
        [Route("register")]
        public IActionResult Index(User user)
        {
            return Content($"{user}");
        }
    }
}