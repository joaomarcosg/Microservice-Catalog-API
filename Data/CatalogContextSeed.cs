using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog_Microservice.Entities;
using MongoDB.Driver;

namespace Catalog_Microservice.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetMyProducts());
            }
        }

        private static IEnumerable<Product> GetMyProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "IPhone X",
                    Description = "IPhone X from Apple Inc",
                    Image = "product-1.png",
                    price = 950.00M,
                    Category = "Smart phone"
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Name = "Samsung Galaxy S21",
                    Description = "Samsung Galaxy S21 from Samsung Electronics",
                    Image = "product-2.png",
                    price = 799.99M,
                    Category = "Smart phone"
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Name = "Sony WH-1000XM4",
                    Description = "Sony WH-1000XM4 Wireless Noise-Cancelling Headphones",
                    Image = "product-3.png",
                    price = 349.90M,
                    Category = "Headphones"
                },

            };
        }
    }
}