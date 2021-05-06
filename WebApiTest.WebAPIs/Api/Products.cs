using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApiTest.Models;
using WebApiTest.Services;

namespace WebApiTest.WebAPIs.Api
{
    public partial class ProductController
    {
        [HttpGet]
        [Route("GetAvailableProducts")]
        public ServiceResponse<IEnumerable<ProductsResponse>> GetAvailableProducts()
        {
            return this._productService.GetAvailableProducts();
        }

        [HttpGet]
        [Route("GetISOFormat")]
        public string GetISOFormat()
        {
            return DateTime.UtcNow.ToString("o");
        }

        [HttpGet]
        [Route("GetMinimaArrayOnly")]
        public async Task<List<MinimaResponse>> GetMinimaArrayOnly()
        {
            List<MinimaResponse> minimaResponses = new List<MinimaResponse>(); 
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
                string responseBody = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<List<MinimaResponse>>(responseBody);
                minimaResponses = model.Where(x => x.body.Contains("minima")).ToList();
            }
            return minimaResponses;
        }

        [HttpPost]
        [Route("CheckProductQuantity")]
        public ServiceResponse<ProductsResponse> CheckProductQuantity(string productID, int quantity)
        {
            return this._productService.CheckAvailableQuantity(productID, quantity);
        }

        [HttpPost]
        [Route("UpdateQuantity")]
        public ServiceResponse<ProductsResponse> UpdateQuantity(string productID, int quantity)
        {
            return this._productService.UpdateQuantity(productID, quantity);
        }
    }
}