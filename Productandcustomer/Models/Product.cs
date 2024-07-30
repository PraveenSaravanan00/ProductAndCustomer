using System.ComponentModel.DataAnnotations;

namespace Productandcustomer.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        public string? ProductName { get; set; }


        //Navigational Property

        public Guid Customerid { get; set; }

        public Customer Customer { get; set; }
    }
}
