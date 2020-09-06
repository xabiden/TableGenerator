using System;
using System.ComponentModel.DataAnnotations;

namespace TableGenerator.DataFolder
{
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double Price { get; set; }
    }
}
