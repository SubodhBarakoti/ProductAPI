using DemoAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DemoAPI.Services.Product
{
    public class ProductService : IProductService
    {
        public static readonly Dictionary<Guid, ProductClass> _products = new();

        
        public void CreateProduct(ProductClass product)
        {
            _products.Add(product.Id, product);
        }

        public void DeleteProduct(Guid id)
        {
            _products.Remove(id);
        }

        public ProductClass GetProduct(Guid id)
        {
            if(_products.TryGetValue(id, value: out ProductClass product))
            {
                return product;
            }
            return null;
        }

        public UpsertedProduct Upsert(ProductClass product)
        {
            var isNewlyCreated = !_products.ContainsKey(product.Id);
            _products[product.Id] = product;
            return new UpsertedProduct(isNewlyCreated);
        }
    }
}
