using Microsoft.AspNetCore.Mvc;

namespace JobMSWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Swagger is working!");
        }

        [HttpPost]
        public IActionResult CreateOrEdit()
        {
            return Ok("Swagger is working!");
        }
    }

}