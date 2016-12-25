using Empire;
using Empire.Models;
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
            using(var ctx = new EmpireDBContext())
            {
                ctx.Products.RemoveRange(ctx.Products);

                //for (int i = 0; i < 25; i++)
                //{
                //    ctx.Products.Add(new Product() { Id = i, Name = "Product " + i, Description = "Description numero " + i });
                //}

                ctx.SaveChanges();
            }
        }
    }
}
