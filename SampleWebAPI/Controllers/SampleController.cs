using Microsoft.AspNetCore.Mvc;

namespace SampleWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        private static List<string> _myList = new SampleData().MyList;

        /// <summary>
        /// 全件取得
        /// GET
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-data")]
        public IActionResult GetData()
        {
            // jsonをリターン
            return Ok(_myList);
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
            if (id < 0 || id >= _myList.Count)
            {
                return NotFound("データが見つからないです");
            }
            return Ok(_myList[id]);
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
                return NotFound("追加するデータが空です");
            }
            _myList.Add(newItem);
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
            if (id < 0 || id >= _myList.Count)
            {
                return NotFound("データが見つからないです");
            }
            if (string.IsNullOrEmpty(newItem))
            {
                return NotFound("更新するデータが空です");
            }
            if (string.IsNullOrWhiteSpace(newItem))
            {
                return BadRequest("更新するデータが無効です");
            }
            _myList[id] = newItem;
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
            if (id < 0 || id >= _myList.Count)
            {
                return NotFound("データが見つからないです");
            }
            _myList.RemoveAt(id);
            return Ok($"データ {id} が削除されました");
        }
    }
}
