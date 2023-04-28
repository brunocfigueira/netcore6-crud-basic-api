using Microsoft.AspNetCore.Mvc;

namespace NetcoreCrudBaseApi.Controllers.Base
{
    public interface ICrudController<C, U, R> where C : class where U : class where R : class
    {
        [HttpPost]
        IActionResult Create([FromBody] C resquest);
        [HttpGet("{id}")]
        IActionResult Read(long id);
        [HttpPut("{id}")]
        IActionResult Update(long id, [FromBody] U resquest);
        [HttpGet("search")]
        IEnumerable<R> Search([FromQuery] int skip = 0, [FromQuery] int take = 10);
        [HttpDelete("{id}")]
        IActionResult Delete(long id);
    }
}
