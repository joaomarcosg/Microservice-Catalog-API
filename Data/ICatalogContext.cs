using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog_Microservice.Entities;
using MongoDB.Driver;

namespace Catalog_Microservice.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}