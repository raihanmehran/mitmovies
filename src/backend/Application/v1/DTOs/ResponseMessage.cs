namespace Application.v1.DTOs
{
    public class ResponseMessage
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }
    }
}