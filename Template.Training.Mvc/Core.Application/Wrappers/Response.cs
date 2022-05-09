using System.Text.Json.Serialization;

namespace Core.Application.Wrappers
{
    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data, string message = null, int statusCode = 200)
        {
            this.Succeeded = true;
            this.Message = message;
            this.Data = data;
            this.StatusCode = statusCode;
        }
        public Response(string message, int statusCode = 200)
        {
            this.Succeeded = false;
            this.Message = message;
            this.StatusCode = statusCode;
        }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }
    }
}
