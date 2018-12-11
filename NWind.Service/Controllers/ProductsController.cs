using NWind.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NWind.Service.Controllers
{
    public class ProductsController : ApiController
    {
      static IRepositoryProduct  Repository =
            new RepositoryMemoryData();


        // Métodos de acción, a las peteciones para CRUD.
        public ProductsController()
        {
           
      
        }
        // POST api/products
        [HttpPost] // Create product
        public Product CreateProduct(Product newProduct)
        {
            // TODO
            var Product =
                 Repository.CreateProduct(newProduct);
            return Product;
        }

        // GET api/products
        [HttpGet]
        public List<Product> GetAllProducts()
        {
            
            return Repository.GetAll();
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
        public void UpdateProduct(int id, Product productToUpdate)
        {
           
            productToUpdate.ProductID = id;
            if (!Repository.UpdateProduct(productToUpdate))
            {
                throw new HttpResponseException(
                    HttpStatusCode.NotFound);
            }
            
        }

        // DELETE
        [HttpDelete]
        public void RemoveProduct(int id)
        {
            Product ProductToDelete = Repository.GetProduct(id);
            if (ProductToDelete ==null)
            {
                throw new HttpResponseException
                    (HttpStatusCode.NotFound);
            }
            Repository.RemoveProduct(ProductToDelete.ProductID);
        }
    }
}
