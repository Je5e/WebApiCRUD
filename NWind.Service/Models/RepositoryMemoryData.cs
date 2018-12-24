using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities;

namespace NWind.Service.Models
{
    public class RepositoryMemoryData : IRepositoryProduct
    {
        private List<Product> Products = new List<Product>();
        private static int NextID;

        public RepositoryMemoryData()
        {
            Products.Add(new Product
            { ProductID = 1, ProductName = "Tomato soup", CategoryID = 1, UnitPrice = 1.39m, UnitsInStock = 45 });
            Products.Add(new Product { ProductID = 2, ProductName = "YO-YO", CategoryID = 2, UnitPrice = 2.1M, UnitsInStock = 41 });
            Products.Add(new Product { ProductID = 3, ProductName = "Hammer", CategoryID = 3, UnitPrice = 1.1M, UnitsInStock = 60 });

        }
        public List<Product> GetAll()
        {

            return Products;
        }

        public Product GetProduct(int id)
        {

            return Products.Find(p => p.ProductID == id);
        }

        public Product CreateProduct(Product newProduct)
        {
            if (newProduct == null)
            {
                throw new ArgumentException("Product");
            }
            newProduct.ProductID = ++NextID;
            Products.Add(newProduct);
            return newProduct;
        }

        public bool RemoveProduct(int id)
        {
            bool Result = false;
           var pr = Products.RemoveAll(p => p.ProductID == id);
            if (pr >0 )
            {
                Result = true;
            }
            return Result;
        }

        public bool UpdateProduct(Product productToUpdate)
        {
            if (productToUpdate == null)
            {
                throw new ArgumentException("Product");
            }

            int index = Products.FindIndex(p => p.ProductID == productToUpdate.ProductID);
            if (index == -1)
            {
                return false;
            }
            Products.RemoveAt(index);
            Products.Add(productToUpdate);
            return true;
        }
    }
}