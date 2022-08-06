namespace Admin.Models
{
    public class Response<T>
    {
        public string? Message { get; set; }
        public bool Status { get; set; }
        public System.Net.HttpStatusCode StatusCode { get; set; }
        public IEnumerable<string>? Errors { get; set; }
        public DateTime? Expiredate { get; set; }
        public T? Data { get; set; }
        public List<T>? List { get; set; }

    }
}
