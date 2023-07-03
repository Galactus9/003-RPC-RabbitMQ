using DbContext;
using RPC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpcServer
{
    internal class Logging
    {
        private readonly ICosmosContext _context;

        public Logging(ICosmosContext context)
        {
            _context = context;
        }
        internal async Task Log(MessageModel mModel, string message)
        {
            var log = new LoggingModel
            {
                Id = Guid.NewGuid().ToString(),
                IP = mModel.Ip,
                UserName = mModel.UserName,
                DateOfLog = DateTime.Now,
                Duration = (DateTime.Now - mModel.intialTime).TotalMilliseconds,
                Message = message,
                Action = mModel.Task
            };
            await _context.logContainer.CreateItemAsync(log);           
        }
    }
}
