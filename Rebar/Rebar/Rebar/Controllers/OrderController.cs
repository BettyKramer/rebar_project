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

        [HttpPost(Name = "GetNewOrder")]
        public async void GetNewOrder(List<Guid> shakes,string name,char size, DateTime orderStart)
        {
            //0 validate list size
            //1 get shake item by guid
            //2 return error if not exists
            //3 validate size 
            //4 validate name (between 3-12)
            //5 insert new shakeorder
            //6 return to client orderid 
            await myOrders.CreatOrder(order);
        }


    }
}
