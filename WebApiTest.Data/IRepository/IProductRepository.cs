using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTest.Models;

namespace WebApiTest.Data
{
    public interface IProductRepository
    {
        /// <summary>
        /// To get available products
        /// </summary>
        /// <returns>ProductsResponse</returns>
        IEnumerable<ProductsResponse> GetAvailableProducts();


        /// <summary>
        /// To check quantity
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="quantity"></param>
        /// <returns>ProductsResponse</returns>
        ProductAvailabilityResponse CheckAvailableQuantity(string productID, int quantity);

        /// <summary>
        /// To check product exists
        /// </summary>
        /// <param name="productID"></param>
        /// <returns>ProductsResponse</returns>
        bool IsProductExists(string productID);

        /// <summary>
        /// To check quantity
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="quantity"></param>
        /// <returns>ProductsResponse</returns>
        ProductAvailabilityResponse UpdateQuantity(string productID, int quantity);
    }
}
