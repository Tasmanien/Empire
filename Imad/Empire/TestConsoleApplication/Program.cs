using Empire;
using Empire.Models;
using Empire.Repositories;
using Empire.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started");

            ProductService service = new ProductService();
            var t = service.GetById(27);
            var list = service.GetAll();
            var listOfJohn = service.GetList(x => x.Name == "John");

            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }
    }
}
