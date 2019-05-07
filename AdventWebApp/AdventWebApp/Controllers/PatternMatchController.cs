using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AdventWebApp
{
    [Route("api/[controller]")]
    public class PatternMatchController : Controller
    {
        // GET api/values
        [HttpGet]
        public ActionResult<int> Get(string input)
        {
            return DataLayer.FindMatchGroupCount(input);
        }
    }
}