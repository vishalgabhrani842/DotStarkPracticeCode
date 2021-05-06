using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest.Models
{
    public class ProductAvailabilityResponse : ProductsResponse
    {
        public int Quantity { get; set; }
    }
}
