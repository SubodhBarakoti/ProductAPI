using DemoAPI.Models;
namespace DemoAPI.Services.Product
{
    public interface IProductService
    {
        void CreateProduct(ProductClass product);
        void DeleteProduct(Guid id);
        ProductClass GetProduct(Guid id);
        UpsertedProduct Upsert(ProductClass product);
    }
}
