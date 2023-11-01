using MongoDataAcsses.DataAccess;
using MongoDataAcsses.Models;
using System.Diagnostics;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Rebar.Controllers
{
   [ Route("api/shakes")]
    [ApiController]

    public class ShakeController : ControllerBase
    {
        ShakeDataAccess myShaker = new ShakeDataAccess();

        [HttpGet(Name = "GetShake")]
        public void GetShakes()
        {
            myShaker.GetAllShakes();
        }
        

        [HttpPost(Name = "CreateShake")]
        public async void createShake(ShakeModel shake)
        {
            await myShaker.CreatShake(shake);
        }

    }
}
