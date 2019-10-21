using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KVSolution.PIM.Application.Blogs;
using KVSolution.PIM.Application.Blogs.Request;
using KVSolution.PIM.Application.Extentions;


namespace KVSolution.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptocurrencyController : ControllerBase
    {
        private IBlogService _blogService;


        public CryptocurrencyController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]CommonRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _blogService.Get(request);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("id is required.");
            }
            var res = await _blogService.GetById(id);
            return Ok(res);
        }

        [HttpGet("without-paging")]
        public async Task<ActionResult> GetBlogs()
        {
            var res = await _blogService.GetBlogs();
            return Ok(res);
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] BlogRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await _blogService.CreateAsync(request);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] BlogRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await _blogService.UpdateAsync(request);
            return Ok(res);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] string Id)
        {
            var res = await _blogService.DeleteAsync(Id);
            return Ok(res);
        }
    }
}