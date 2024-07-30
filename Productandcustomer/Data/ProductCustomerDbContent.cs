using Microsoft.EntityFrameworkCore;
using Productandcustomer.Models;

namespace Productandcustomer.Data
{
    public class ProductCustomerDbContent: DbContext
    {
        public ProductCustomerDbContent(DbContextOptions<ProductCustomerDbContent> options):base(options)
        {
                
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Customer> customers { get; set; }
    }
}
