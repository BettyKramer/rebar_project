using Microsoft.AspNetCore.Mvc;
using MongoDataAcsses.DataAccess;
using MongoDataAcsses.Models;
using Rebar.Models;

namespace Rebar.Controllers
{
    [Route("api/order")]
    [ApiController]

    public class OrderController : ControllerBase
    {
        OrderDataAccess myOrders = new OrderDataAccess();
        [HttpPost(Name ="CreateOrder")]
        public async void CreateOrder(OrderModel order)
        {
            await myOrders.(order);
        }

        [HttpPost(Name = "CreateNewOrder")]
        public async void GetNewOrder(List<Guid> shakes,string CustomerName, DateTime orderStart)
        {
            if (shakes.Count > 10)
            {
                await Console.Out.WriteLineAsync("too much shakes!!!");
                return;
            }
            ShakeDataAccess myShake = new ShakeDataAccess();
            foreach (var shake in shakes)
            {
                if (!myShake.isShakeExists(shake))
                {
                    await Console.Out.WriteLineAsync("shake doesnt exist");
                    return;
                }
            } 
                //3 validate size 

             OrderDataAccess orders = new OrderDataAccess();
            //4 validate name (between 3-12)
            if (!orders.IsNameValied(CustomerName))
            {
                await Console.Out.WriteLineAsync("name is not valied!!!");
                return;
            }
            CreateOrder(new OrderModel() { shakes = shakes, CustomerName = "betty", SumPrices = 10, startOrder = orderStart, endOrder = DateTime.Now });
            //6 return to client orderid 
            
        }
    }
}
