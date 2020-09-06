using System;
using TableGenerator.DataFolder;

namespace TableGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = GenerateProducts();

            CreateProductTable();

            FillProductTable(products);
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

        public static void CreateProductTable()
        {
            try
            {
                var query =
                    "CREATE TABLE IF NOT EXISTS 'Products'(" +
                    "'Id'    INTEGER NOT NULL UNIQUE," +
                    "'Name'  TEXT NOT NULL," +
                    "'Price' REAL NOT NULL," +
                    "PRIMARY KEY('Id' AUTOINCREMENT));";

                using (var context = new ProductContext())
                {
                    context.Database.ExecuteSqlCommand(query);

                    var name = context.Database.Connection.Database;

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
                    if(context.Products == null)
                    {
                        Console.WriteLine("Таблицы не существует");

                        return;
                    }

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
