using NWind.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;
using SLC;

namespace NWind.Service.Controllers
{
    public class ProductsController : ApiController, IService
    {
      static IRepositoryProduct  Repository =
            new RepositoryMemoryData();
        
        
        // POST api/products/createproduct
        [HttpPost] // Create product
        public Product CreateProduct(Product newProduct)
        {
            // TODO
            var Product =
                 Repository.CreateProduct(newProduct);
            return Product;
        }

        
        // GET api/products/RetrieveProductByID/id
        //[ActionName("RetrieveProductByID")]
        [HttpGet]
        public Product RetrieveProductByID(int id)
        {

            return Repository.GetProduct(id);
        }

        // PUT api/products/id
        [HttpPut]
        public void UpdateProduct(int ID, Product productToUpdate)
        {
           
            productToUpdate.ProductID = ID;
            if (!Repository.UpdateProduct(productToUpdate))
            {
                throw new HttpResponseException(
                    HttpStatusCode.NotFound);
            }
            
        }
        
        // DELETE api/products/removeProduct?id={id}
        // api/products/removeproduct/id
        [HttpDelete]
        public void RemoveProduct(int ID)
        {
            Product ProductToDelete = Repository.GetProduct(ID);
            if (ProductToDelete ==null)
            {
                throw new HttpResponseException
                    (HttpStatusCode.NotFound);
            }
            Repository.RemoveProduct(ProductToDelete.ProductID);
        }

        [HttpGet]
        public List<Product> FilterProductsByCategoryID(int categoryID)
        {
            return Repository.GetAll().Where(p => p.CategoryID == categoryID)
                .ToList();
        }

        // GET api/products
        [HttpGet]
        public List<Product> RetrieveAllProduct()
        {
            return Repository.GetAll();
        }
    }
}
