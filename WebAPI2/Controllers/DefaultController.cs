using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebAPI2.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: Default
        [HttpGet]
        public IHttpActionResult Index()
        {
            return Json("Web API version 1.0");
            
        }
    }
}