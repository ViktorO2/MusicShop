using ApplicationService.Implemantations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI2.Controllers
{
    public class ProdController : ApiController
    {
        private ProductManagementService productService = new ProductManagementService();
        [HttpGet]
        // [Route("api/product")]
        public IHttpActionResult Get()
        {
            return Json(productService.Get());
        }

        [HttpGet]
        // [Route("api/product/{id}")]
        public IHttpActionResult Get(int id)
        {
            return Json(productService.GetById(id));
        }
    }
}
