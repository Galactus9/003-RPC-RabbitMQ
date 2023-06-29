using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPC.Model;
using RpcClient;

namespace RPC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {


        [HttpPost]
        public async Task<ActionResult> Index(TestModel model)
        {
            var _rpcClient = new RpcClient.RpcClient();
            var response = await _rpcClient.SendAsync(model);
            return Ok(response);

        }
    }
}
