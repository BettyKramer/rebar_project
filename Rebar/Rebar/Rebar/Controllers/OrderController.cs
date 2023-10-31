using Microsoft.AspNetCore.Mvc;
using MongoDataAcsses.DataAccess;
using MongoDataAcsses.Models;

namespace Rebar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        OrderDataAccess myOrders = new OrderDataAccess();
        [HttpPost(Name ="CreateOrder")]
        public async void CreateOrder(OrderModel order)
        {
            await myOrders.CreatOrder(order);
        }

    }
}
