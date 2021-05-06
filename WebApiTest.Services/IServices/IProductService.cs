using System;
using System.Collections.Generic;
using WebApiTest.Models;

namespace WebApiTest.Services
{
    public interface IProductService
    {
        /// <summary>
        /// To get available products
        /// </summary>
        /// <returns>ProductsResponse</returns>
        ServiceResponse<IEnumerable<ProductsResponse>> GetAvailableProducts();

        /// <summary>
        /// To check quantity
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="quantity"></param>
        /// <returns>ProductsResponse</returns>
        ServiceResponse<ProductsResponse> CheckAvailableQuantity(string productID, int quantity);

        /// <summary>
        /// To check quantity
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="quantity"></param>
        /// <returns>ProductsResponse</returns>
        ServiceResponse<ProductsResponse> UpdateQuantity(string productID, int quantity);
    }
}
