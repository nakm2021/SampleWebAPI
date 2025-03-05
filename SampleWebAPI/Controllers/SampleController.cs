using Microsoft.AspNetCore.Mvc;

namespace SampleWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly ISampleService _service;

        /// <summary>
        /// 依存性注入
        /// </summary>
        /// <param name="service"></param>
        public SampleController(ISampleService service)
        {
            _service = service;
        }

        /// <summary>
        /// 全件取得
        /// GET
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-data")]
        public IActionResult GetData()
        {
            return Ok(_service.GetData());
        }

        /// <summary>
        /// ID指定で取得
        /// GET
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-data/{id}")]
        public IActionResult GetDataById(int id)
        {
            if (id < 0 || id >= _service.MyList.Count)
            {
                return NotFound("データが見つからないです");
            }
            return Ok(_service.GetDataById(id));
        }

        /// <summary>
        /// データ追加
        /// POST
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns></returns>
        [HttpPost("add-data")]
        public IActionResult AddData([FromBody] string newItem)
        {
            if (string.IsNullOrEmpty(newItem))
            {
                return BadRequest("追加するデータが空です");
            }
            _service.AddData(newItem);
            return Ok($"データ {newItem} が追加されました");
        }

        /// <summary>
        /// データを更新
        /// PUT
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newItem"></param>
        /// <returns></returns>
        [HttpPut("update-data/{id}")]
        public IActionResult UpdateData(int id, [FromBody] string newItem)
        {
            if (id < 0 || id >= _service.MyList.Count)
            {
                return NotFound("データが見つからないです");
            }
            if (string.IsNullOrEmpty(newItem))
            {
                return BadRequest("更新するデータが空です");
            }
            if (string.IsNullOrWhiteSpace(newItem))
            {
                return BadRequest("更新するデータが無効です");
            }
            _service.UpdateData(id, newItem);
            return Ok($"データ {newItem} が更新されました");
        }

        /// <summary>
        /// データを削除
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete-data/{id}")]
        public IActionResult DeleteData(int id)
        {
            if (id < 0 || id >= _service.MyList.Count)
            {
                return NotFound("データが見つからないです");
            }
            _service.DeleteData(id);
            return Ok($"データ {id} が削除されました");
        }
    }
}
