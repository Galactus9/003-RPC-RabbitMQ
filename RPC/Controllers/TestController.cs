using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPC.Model;
using RPC.Services;
using RpcClient;

namespace RPC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TestController(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Create(UserModel model)
        {
            var response = await _userService.UserCreate(model);
            return Ok(response);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Login(UserModel model)
        {
            var response = await _userService.UserLoggin(model);
            return Ok(response);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Calculator(TestModel model)
        {
            //string ipAddress = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
            var clientIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress;
            var ipv4Address = clientIpAddress.MapToIPv4().ToString();

            //string ipAddress = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();

            //// Check for X-Forwarded-For header
            //string forwardedHeader = _httpContextAccessor.HttpContext?.Request.Headers["X-Forwarded-For"];
            //if (!string.IsNullOrEmpty(forwardedHeader))
            //{
            //    // Get the first IP address from the comma-separated list
            //    ipAddress = forwardedHeader.Split(',')[0].Trim();
            //}
            var messageData = new MessageModel 
            { 
                UserName = model.userName, 
                //Ip = ipv4Address,
                Number1 = model.Number1,
                Number2 = model.Number2,
                Task = model.Task,
                intialTime = DateTime.Now
            };
            var _rpcClient = new RpcClient.RpcClient();
            var response = await _rpcClient.SendAsync(messageData);
            return Ok(response);
        }

        //var _rpcClient = new RpcClient.RpcClient();
        //var response = await _rpcClient.SendAsync(model);
        //return Ok(response);
    }
}
