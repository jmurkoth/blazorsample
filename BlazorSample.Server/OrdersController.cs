using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorSample.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorSample.Server
{
    [Route("/orders")]
    [ApiController]
    public class OrdersController : Controller
    {
        // GET: api/<controller>
        // DO NOT USE IN PROD.. JUST TESTING
       public static List<Order> _Orders = new List<Order>();

        public async Task<ActionResult> PlaceOrder(Order order)
        {
            order.CreatedTime = DateTime.Now;
            order.DeliveryLocation = new LatLong(51.5001, -0.1239);
            order.OrderId = _Orders.Count + 1;
            // order.UserId = GetUserId();

            _Orders.Add(order);
            return NoContent();
        }
        [HttpGet]
        public async Task<List<OrderWithStatus>> GetOrders()
        {
            return await Task.FromResult<List<OrderWithStatus>>(_Orders.Select(o => OrderWithStatus.FromOrder(o)).ToList());
        }

        [HttpGet]
        [Route("/orders/{orderId:int}")]
        public async Task<ActionResult<OrderWithStatus>> GetOrderbyId(int orderId)
        {
            var matchingOrder = _Orders.FirstOrDefault(o => o.OrderId == orderId);
            if(matchingOrder!=null)
            {
                return await Task.FromResult<OrderWithStatus>(OrderWithStatus.FromOrder(matchingOrder));
            }
            else
            {
                return NotFound();
            }
          
        }

    }
}
