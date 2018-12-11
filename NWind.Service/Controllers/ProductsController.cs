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
        IRepositoryProduct Repository = new RepositoryMemoryData();


        // Métodos de acción, a las peteciones para CRUD.
        public ProductsController()
        {
            RepositoryMemoryData RMD = new RepositoryMemoryData(); // Le regalo un libro de IIS, quien responda esta pregunta.
            IRepositoryProduct IRP = RMD;
      
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
            // TODO
            return Repository.GetAll();
        }

        // GET api/products/RetrieveProductByID/id
        [ActionName("RetrieveProductByID")]
        public Product RetrieveProductByID(int id)
        {
            // TODO
            return null;
        }

        // PUT api/products/id
        [HttpPut]
        public void UpdateProduct(int id, Product productToUpdate)
        {
            // TODO
        }

        // DELETE
        public void RemoveProduct(int id)
        {

        }
    }
}
