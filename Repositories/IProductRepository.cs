using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog_Microservice.Entities;

namespace Catalog_Microservice.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(string id);
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task<IEnumerable<Product>> GetProductByCategory(string categoryName);
        Task CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string id);
    }
}