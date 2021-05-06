using System.Collections.Generic;
using WebApiTest.Models;
using WebApiTest.Data;
using WebApiTest.Core;
using System.Linq;
using System;
using Elmah;

namespace WebApiTest.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ServiceResponse<IEnumerable<ProductsResponse>> GetAvailableProducts()
        {
            try
            {
                var objReturn = new ServiceResponse<IEnumerable<ProductsResponse>>();
                var products = _productRepository.GetAvailableProducts();
                objReturn = SetResultStatus(products, MessageStatus.Success, true);
                return objReturn;
            }
            catch (Exception ex)
            {
                return SetResultStatus<IEnumerable<ProductsResponse>>(null, MessageStatus.Error, false);
            }
        }

        public ServiceResponse<ProductsResponse> CheckAvailableQuantity(string productID, int quantity)
        {
            try
            {
                var objReturn = new ServiceResponse<ProductsResponse>();
                ProductsResponse products = new ProductsResponse();
                string message = MessageStatus.ProductNotExist;
                if (_productRepository.IsProductExists(productID))
                {
                    products = _productRepository.CheckAvailableQuantity(productID, quantity);
                    message = products != null ? string.Format(MessageStatus.QuantityAvailable, productID) : string.Format(MessageStatus.QuantityNotAvailable, productID);
                    objReturn = SetResultStatus(products, message, true);
                }
                else
                {
                    objReturn = SetResultStatus<ProductsResponse>(null, message, true);
                }

                return objReturn;
            }
            catch (Exception ex)
            {
                return SetResultStatus<ProductsResponse>(null, MessageStatus.Error, false);
            }
        }

        public ServiceResponse<ProductsResponse> UpdateQuantity(string productID, int quantity)
        {
            try
            {
                var objReturn = new ServiceResponse<ProductsResponse>();
                ProductsResponse products = new ProductsResponse();
                string message = MessageStatus.ProductNotExist;
                if (_productRepository.IsProductExists(productID))
                {
                    products = _productRepository.UpdateQuantity(productID, quantity);
                    message = products != null ? string.Format(MessageStatus.QuantityAvailable, productID) : string.Format(MessageStatus.QuantityNotAvailable, productID);
                    objReturn = SetResultStatus(products, message, true);
                }
                else
                {
                    objReturn = SetResultStatus<ProductsResponse>(null, message, true);
                }

                return objReturn;
            }
            catch (Exception ex)
            {
                return SetResultStatus<ProductsResponse>(null, MessageStatus.Error, false);
            }
        }
    }
}
