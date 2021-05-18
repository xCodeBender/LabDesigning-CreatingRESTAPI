using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesigningAndCreatingRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        [HttpGet("Shipper")]
        public List<Shipper> Shipping(int shipperID)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                List<Shipper> result = context.Shippers.ToList().Where(o => o.ShipperId == shipperID).ToList();
                return result;
            }

        }

        //api/order/CompanyName
        [HttpGet("CompanyName")]
        public List<Shipper> ShipperCompany(string companyName)
        {

            using (NorthwindContext context = new NorthwindContext())
            {
                List<Shipper> result = context.Shippers.ToList().Where(o => o.CompanyName.ToLower() == companyName.ToLower()).ToList();
                return result;
            }

        }
    }
}
