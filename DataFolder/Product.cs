using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
