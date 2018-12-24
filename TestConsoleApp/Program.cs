using NWindProxyService;
using System;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Proxy ProxyService = new Proxy();
            var Datos = ProxyService.RetrieveAllProduct();

            foreach (var product in Datos)
            {
                Console.WriteLine
                    ($"Name: " +
                    $"{product.ProductName}, ID: {product.ProductID}");
            }
            Console.ReadLine();
        }
    }
}
