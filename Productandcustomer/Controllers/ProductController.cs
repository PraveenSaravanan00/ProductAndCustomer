using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Productandcustomer.Data;
using Productandcustomer.Dto;
using Productandcustomer.Models;

namespace Productandcustomer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductCustomerDbContent productCustomerDbContent;

        public ProductController(ProductCustomerDbContent productCustomerDbContent )
        {
            this.productCustomerDbContent = productCustomerDbContent;
        }

        [HttpGet]

        public async Task<List<Product>> GetAll()
        {
            return await productCustomerDbContent.products.ToListAsync();
        }

        [HttpGet("Get By Id")]

        public async Task<IActionResult> GetById(Guid id)
        {
            var IdExist = await productCustomerDbContent.products.FindAsync(id);
            if(IdExist == null) {

                return NotFound("id not found");
                    
                    }

            return Ok(IdExist);
        }

        [HttpPost]

        public async Task<IActionResult> AddProduct([FromBody] AddProductDto addProductDto)
        {
            var Addproduct = new Product()
            {
                ProductName = addProductDto.ProductName,
                Customerid= addProductDto.Customerid
            };

            await productCustomerDbContent.AddRangeAsync( Addproduct );
            await productCustomerDbContent.SaveChangesAsync();

            return Ok("Product Added Successfully");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] Product product)
        {
            var IdExist= await productCustomerDbContent.products.FindAsync(id);

            if( IdExist== null ) {

                ModelState.AddModelError("Id","There is no Such Id Exist");
            
            }

            IdExist.ProductName = product.ProductName;
            IdExist.Customerid = product.Customerid;

            await productCustomerDbContent.SaveChangesAsync();

            return Ok("Updated Successfully");

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var IdExist = await productCustomerDbContent.products.FindAsync(id);
            if( IdExist== null )
            {

                ModelState.AddModelError("", "There is no such id exist");
            }

            productCustomerDbContent.Remove(IdExist);
            await productCustomerDbContent.SaveChangesAsync();

            return Ok("Deleted Successfully");
        }
    }
}
