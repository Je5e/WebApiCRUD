﻿using System.Collections.Generic;
using Entities;

namespace NWind.Service.Models
{
    public interface IRepositoryProduct
    {
        Product CreateProduct(Product newProduct);
        List<Product> GetAll();
        Product GetProduct(int id);
        void RemoveProduct(int id);
        bool UpdateProduct(Product productToUpdate);
    }
}