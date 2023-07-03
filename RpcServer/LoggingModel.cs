using Newtonsoft.Json;

namespace RPC.Model
{
    public class LoggingModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("dateoflog")]
        public DateTime DateOfLog { get; set; }
        [JsonProperty("ip")]
        public string? IP { get; set; }
        [JsonProperty("duration")]
        public double Duration { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("action")]
        public TaskType Action { get; set; }
    }
}
