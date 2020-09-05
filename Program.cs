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
            try
            {
                var products = GenerateProducts();

                CreateProductsTable();

                FillProductTable(products);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static Product[] GenerateProducts()
        {
            try
            {
                var rnd = new Random();

                var products = new Product[1000];

                for (int i = 0; i < products.Length; i++)
                {
                    var price = rnd.NextDouble() * 999 + 1;

                    var name = $"Продукт {rnd.Next()}";

                    products[i] = new Product(name, price);
                }

                return products;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return null;
            }
        }

        public static void CreateProductsTable()
        {
            try
            {
                var query =
                    "CREATE TABLE 'Products'(" +
                    "'Id'    INTEGER NOT NULL UNIQUE," +
                    "'Name'  TEXT NOT NULL," +
                    "'Price' REAL NOT NULL," +
                    "PRIMARY KEY('Id' AUTOINCREMENT));";

                using (var context = new ProductContext())
                {
                    context.Database.ExecuteSqlCommand(query);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void FillProductTable(Product[] products)
        {
            try
            {
                if (products == null)
                {
                    Console.WriteLine("Нет данных для заполнения таблицы");

                    return;
                }

                using ( var context = new ProductContext())
                {
                    context.Products.AddRange(products);

                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
