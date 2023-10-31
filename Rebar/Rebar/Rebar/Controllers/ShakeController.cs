using MongoDataAcsses.DataAccess;
using MongoDataAcsses.Models;
using System.Diagnostics;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Rebar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShakeController : ControllerBase
    {
        ShakeDataAccess myShaker = new ShakeDataAccess();


        // myShaker.GetAllShakes();
        [HttpPost(Name = "CreateShake")]
        public async void createShake(ShakeModel shake)
        {
            await myShaker.CreatShake(shake);
        }

    }
}
