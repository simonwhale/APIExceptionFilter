using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExceptionFilter.UserDefinedExceptions;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionFilter.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public IActionResult GetAnException()
        {
            throw new UnauthorizedAccessException("Your names not found, so you aint coming in!!");
        }

        [HttpGet]
        public ActionResult<int> Sums()
        {
            return 1 + 2;
        }
    }
}
