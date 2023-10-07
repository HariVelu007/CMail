using CMail.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMail.Controllers
{
    //[AuthFilter(User ="hari@in.com")]
    public class HomeController : BaseController
    {
      

        [HttpGet]
        [Route("View")]
        public IActionResult GetMail(string id)
        {
            return Ok("Welcome");
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult CreateMail()
        {
            return Ok("Welcome");
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateMail()
        {
            return Ok("Welcome");
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteMail(string id)
        {
            return Ok("Welcome");
        }
    }
}
