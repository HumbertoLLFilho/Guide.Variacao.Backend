namespace Guide.Variacao.Domain.Models
{
    public class StockVariation
    {
        public string Symbol { get; set; }
        public DateTime StartDate { get; set; }
        public double DayOnePrice { get; set; }
        public List<Variation> Variations { get; set; } = [];

    }

}
