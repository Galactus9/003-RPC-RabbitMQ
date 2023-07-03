using DbContext;
using Microsoft.Azure.Cosmos.Linq;
using RPC.Model;

namespace RPC.Services
{
    public class UserService : IUserService
    {
        private readonly ICosmosContext _context;
        public UserService(ICosmosContext context)
        {
            _context = context;
        }
        public async Task<bool> UserCreate(UserModel user)
        {
            //check if user name exists
            try
            {
                //var responce = _context.userContainer.GetItemLinqQueryable<UserModel>()
                //                         .Single(x => x.UserName == user.UserName);
                if (1 == 0)
                {
                    throw new Exception("The Users allready exists");
                }
                else 
                {
                    user.Id = new Guid().ToString();
                    await _context.userContainer.CreateItemAsync<UserModel>(user);
                    return true; 
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UserLoggin(UserModel user)
        {
            //check if user name exists
            try
            {
                var query = _context.userContainer.GetItemLinqQueryable<UserModel>()
                    .Where(x => x.UserName == user.UserName)
                    .ToFeedIterator();

                //query.AllowSynchronousQueryExecution = false; // Ensure allowSynchronousQueryExecution is set to false (optional)

                var response = await query.ReadNextAsync();
                var result = response.SingleOrDefault();

                if (result.Password != user.Password)
                {
                    throw new Exception("Incorect Password");
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
