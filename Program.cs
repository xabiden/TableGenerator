using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGenerator.DataFolder;

namespace TableGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ProductContext())
            {
                var product = new Product()
                {
                    Id = 1,
                    Name = "Samsung",
                    Price = 35000
                };

                context.Products.Add(product);

                context.SaveChanges();
            }
        }
    }
}
