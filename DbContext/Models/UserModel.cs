using Newtonsoft.Json;

namespace RPC.Model
{
    public class UserModel
    {
        [JsonProperty("id")]
        public string? Id { get; set; }
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
