using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiTest.Models;
using WebApiTest.Services;

namespace WebApiTest.WebAPIs.Api
{
    [RoutePrefix("Api/Product")]
    public partial class ProductController : ApiController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        
    }
}
