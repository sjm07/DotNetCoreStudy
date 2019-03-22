using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class TestController:ControllerBase
    {
        [HttpGet]
        [Route("api/test/sjm")]
        public string sjm()
        {
            return "sjmsjm";
        }
    }
}