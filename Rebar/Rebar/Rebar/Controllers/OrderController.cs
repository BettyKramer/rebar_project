using Microsoft.AspNetCore.Mvc;
using MongoDataAcsses.DataAccess;
using MongoDataAcsses.Models;
using Rebar.Models;

namespace Rebar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        OrderDataAccess myOrders = new OrderDataAccess();
        [HttpPost(Name = "CreateOrder")]
        public async void CreateOrder(OrderModel order)
        {
            await myOrders.CreatOrder(order);
        }
        [HttpPost(Name = "CreateNewOrder")]
        public async void GetNewOrder(List<Guid> shakes, string CustomerName, DateTime orderStart)
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
            OrderDataAccess orders = new OrderDataAccess();
            //3 validate size 
            foreach (var shake in shakes) { 
            {
                    if (!orders.isSizeVlide(shake))
                    {
                        await Console.Out.WriteLineAsync("size is not valied");
                        return;
                    }
            }
            }

            

            if (!orders.IsNameValied(CustomerName))
            {
                await Console.Out.WriteLineAsync("name is not valied!!!");
                return;
            }
            try {
                CreateOrder(new OrderModel() { shakes = shakes, CustomerName = "betty", SumPrices = 10, startOrder = orderStart, endOrder = DateTime.Now });
                await Console.Out.WriteLineAsync("we got your order");
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync("something went wrong with your order....");
            }
        }

        [HttpGet(Name = "CloseCashier")]
        public void CloseCashier()
        {
            OrderDataAccess orders = new OrderDataAccess();
            Console.WriteLine("number of orders: " + orders.GetNumberOfOrders());

        }
    }
}


