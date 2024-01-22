namespace Guide.Variacao.Domain.Models
{
    public class Response<T>
    {
        public Response(T value)
        {
            Values.Add(value);
        }
        public Response(IEnumerable<T> values)
        {
            Values.AddRange(values);
        }

        public Response(Error error)
        {
            Errors.Add(error);
        }
        public Response(IEnumerable<Error> errors)
        {
            Errors.AddRange(errors);
        }

        public List<T> Values { get; set; } = [];

        public List<Error> Errors { get; set; } = [];

        public bool IsSuccess => !Errors.Any();

    }
}
