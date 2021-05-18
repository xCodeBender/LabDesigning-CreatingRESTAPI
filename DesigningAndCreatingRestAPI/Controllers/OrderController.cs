using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesigningAndCreatingRestAPI.Controllers
{
    //api/order
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        //api/order
        //https://localhost:44304/api/order
        [HttpGet()]
        public List<Order> ShipToCountry()
        {
            using(NorthwindContext context = new NorthwindContext())
            {
                return context.Orders.ToList();
            }
            
        }

        //api/order/ShipName
        //https://localhost:44304/api/order?shipName=HanariCarnes
        [HttpGet("ShipName")]
        public List<Order> SearchByShipName(string shipName)
        {
           
            using (NorthwindContext context = new NorthwindContext())
            {
                List<Order> result = context.Orders.ToList().Where(o => o.ShipName.ToLower() == shipName.ToLower()).ToList();
                return result;
            }

        }
    
        [HttpPost("AddTo")]
        public Order AddTo(string shipCountry,string shipName)
        {
            Order order = new Order();
            order.ShipCountry = shipCountry;
            order.ShipName = shipName;

            using (NorthwindContext context = new NorthwindContext())
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }

            return order;
        }
    }
}
