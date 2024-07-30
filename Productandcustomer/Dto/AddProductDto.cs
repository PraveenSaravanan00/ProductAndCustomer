namespace Productandcustomer.Dto
{
    public class AddProductDto
    {

        public string? ProductName { get; set; }


        //Navigational Property

        public Guid Customerid { get; set; }
    }
}
