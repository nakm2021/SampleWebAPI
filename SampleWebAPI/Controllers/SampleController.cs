using Microsoft.AspNetCore.Mvc;

namespace SampleWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        [HttpGet("get-data")]
        public IActionResult GetData()
        {
            // 返すデータのサンプル
            var list = new SampleData().MyList;

            // JSONとしてデータを返す
            return Ok(list);
        }
    }
}
