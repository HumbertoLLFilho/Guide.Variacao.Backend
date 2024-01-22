namespace Guide.Variacao.Domain.Models
{
    public class Error(int code, string service)
    {
        public string? Message { get; set; }
        public int Code { get; set; } = code;
        public string Service { get; set; } = service;
    }
}
