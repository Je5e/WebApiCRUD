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
        public bool UpdateProduct(int ID, Product productToUpdate)
        {
           
            productToUpdate.ProductID = ID;
            if (!Repository.UpdateProduct(productToUpdate))
            {
                throw new HttpResponseException(
                    HttpStatusCode.NotFound);
            }
            return true;
            
        }
        
        // DELETE api/products/removeProduct?id={id}
        // api/products/removeproduct/id
        [HttpDelete]
        public bool RemoveProduct(int ID)
        {
            
            //Product ProductToDelete = Repository.GetProduct(ID);
          var Result  = Repository.RemoveProduct(ID);

            if (!Result)
            {
                Result = false;
                throw new HttpResponseException
                    (HttpStatusCode.NotFound);
            }
            return Result;
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
