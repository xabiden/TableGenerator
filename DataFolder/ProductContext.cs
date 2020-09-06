namespace TableGenerator.DataFolder
{
    using System.Data.Entity;

    public class ProductContext : DbContext
    {
        public ProductContext()
            : base("name=ProductContext")
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}