using Microsoft.AspNetCore.Mvc;

namespace ProductsApi.Demo;

public class DemoController : ControllerBase
{
    [HttpGet("/demo")]
    public async Task<ActionResult> GetTheDemo()
    {
        return Ok();
    }
}
