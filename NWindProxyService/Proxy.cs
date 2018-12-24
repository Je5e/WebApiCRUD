using Entities;
using SLC;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace NWindProxyService
{
    public class Proxy : IService
    {
        string BaseAddress = "http://localhost:57694/";

        #region Peticiones POST AND GET
        // api/products/createproduct
        public async Task<T> SendPost<T, PostData>(string requestURI, PostData data)
        {
            T Result = default(T);
            using (var Client = new HttpClient())
            {
                try
                {
                    // URI Absoluto
                    requestURI = BaseAddress + requestURI; // http://localhost:785/api/products/cretepro
                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    var JsonData = JsonConvert.SerializeObject(data);
                    HttpResponseMessage Response =
                        await Client.PostAsync(requestURI,
                        new StringContent(JsonData.ToString(),
                        Encoding.UTF8, "application/json"));
                    var ResultWebAPI = await Response.Content.ReadAsStringAsync();
                    Result = JsonConvert.DeserializeObject<T>(ResultWebAPI);

                }
                catch (Exception)
                {

                    throw;
                }
            }
            return Result;
        }

        // Peticiones GET
        public async Task<T> SendGet<T>(string requesURI)
        {
            T Result = default(T);
            using (var Client = new HttpClient())
            {
                try
                {
                    requesURI = BaseAddress + requesURI;

                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    var ResultJSON = await Client.GetStringAsync(requesURI);
                    Result = JsonConvert.DeserializeObject<T>(ResultJSON);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return Result;
        }
        #endregion

        public async Task<Product> CreateProductAsync(Product newProduct)
        {
            return await SendPost<Product,Product>
                ("/api/products/createproduct", newProduct);
        }
        public Product CreateProduct(Product newProduct)
        {
            Product Result = null;
            Task.Run(async () => Result = await CreateProductAsync(newProduct)).Wait();
            return Result;
        }

        public async Task<List<Product>> FilterProductsByCategoryIDAsync(int ID)
        {
            return await SendGet<List<Product>>
                ($"/api/products/FilterProductsByCategoryID/{ID}");
        }
        public List<Product> FilterProductsByCategoryID(int categoryID)
        {
            List<Product> Result = null;
            Task.Run(async () => Result = await FilterProductsByCategoryIDAsync(categoryID)).Wait();
            return Result;
        }

        // TODO
        public async Task<bool> RemoveProductAsync(int ID)
        {
            return await SendGet<bool>($"/api/products/removeproduct/{ID}");
        }
        public bool RemoveProduct(int ID)
        {
            bool Result = false;
             Task.Run(async () => Result =
         await RemoveProductAsync(ID)).Wait();
            return Result;
        }

        public async Task<List<Product>> RetrieveAllProductAsync()
        {
            return await SendGet<List<Product>>(
                "/api/products/RetrieveAllProduct");
        }
        public List<Product> RetrieveAllProduct()
        {
            List<Product> Result = null;
            Task.Run(async () => Result = await RetrieveAllProductAsync()).Wait();
            return Result;
        }

        public async Task<Product> RetrieveProductByIDAsync(int ID)
        {
            return await SendGet<Product>
                ($"/api/products/RetrieveProductByID/{ID}");
        }
        public Product RetrieveProductByID(int ID)
        {
            Product Result = null;
            Task.Run(async () => Result = await 
            RetrieveProductByIDAsync(ID)).Wait();
            return Result;
        }

        public async Task<bool> UpdateProductAsync(Product productToUpdate)
        {
            return await SendPost<bool, Product>
                ("/api/products/UpdateProduct", productToUpdate);
        }
        public bool UpdateProduct(int ID, Product productToUpdate)
        {
            bool Result = false;
            Task.Run(async () => Result =
            await UpdateProductAsync(productToUpdate)).Wait();
            return Result;
        }
    }
}
