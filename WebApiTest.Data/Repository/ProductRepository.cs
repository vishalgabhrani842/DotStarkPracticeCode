using System;
using System.Collections.Generic;
using System.Data;
using WebApiTest.Models;
using System.Linq;

namespace WebApiTest.Data
{
    public class ProductRepository : IProductRepository
    {
        PracticeTestEntities Entity = new PracticeTestEntities();

        public IEnumerable<ProductsResponse> GetAvailableProducts()
        {
            return Entity.Products.Where(x => x.StockAvailable > 0).Select(x => new ProductsResponse
            {
                ID = x.ID,
                ProductID = x.ProductID,
                ProductName = x.ProductName
            }).ToList();
        }

        public ProductAvailabilityResponse CheckAvailableQuantity(string productID, int quantity)
        {
            return Entity.Products.Where(x => x.ProductID == productID && x.StockAvailable >= quantity).Select(x => new ProductAvailabilityResponse
            {
                ID = x.ID,
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                Quantity = x.StockAvailable,
            }).FirstOrDefault();
        }

        public bool IsProductExists(string productID)
        {
            var product = Entity.Products.Where(x => x.ProductID == productID).FirstOrDefault();
            return product != null ? true : false;
        }

        public ProductAvailabilityResponse UpdateQuantity(string productID, int quantity)
        {
            ProductAvailabilityResponse product = new ProductAvailabilityResponse();
            var result = Entity.Products.SingleOrDefault(b => b.ProductID == productID);
                if (result != null)
                {
                    result.StockAvailable += quantity;
                    Entity.SaveChanges();
                }
            product.ID = result.ID;
            product.ProductID = productID;
            product.ProductName = result.ProductName;
            product.Quantity = result.StockAvailable;

            return product;
        }
    }
}
