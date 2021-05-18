using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesigningAndCreatingRestAPI.Controllers
{   //api/product
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //api/ProductID
        [HttpGet("ProductID")]
        public List<Product> ProductsToShip(int productID)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                List<Product> result = context.Products.ToList().Where(o => o.ProductId == productID).ToList();
                return result;
            }

        }

        //api/order/ProductName
        [HttpGet("ProductName")]
        public List<Product> SearchByShipName(string productName)
        {

            using (NorthwindContext context = new NorthwindContext())
            {
                List<Product> result = context.Products.ToList().Where(o => o.ProductName.ToLower() == productName.ToLower()).ToList();
                return result;
            }

        }
        [HttpPost("AddProduct")]
        public Product AddProduct(int productID, string productName)
        {
            Product product = new Product();
            product.ProductId = productID;
            product.ProductName = productName;

            using (NorthwindContext context = new NorthwindContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }

            return product;
        }

    }
}
