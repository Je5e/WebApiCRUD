using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace SLC
{
   public interface IService
    {
        Product CreateProduct(Product newProduct);
        Product RetrieveProductByID(int ID);
        bool UpdateProduct(int ID,Product productToUpdate);
        bool RemoveProduct(int ID);
        List<Product> FilterProductsByCategoryID(int categoryID);
        List<Product> RetrieveAllProduct();

    }
}
