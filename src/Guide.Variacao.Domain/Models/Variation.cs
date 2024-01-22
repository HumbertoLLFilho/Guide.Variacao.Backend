namespace Guide.Variacao.Domain.Models
{
    public class Variation(double dayOnePrice)
    {
        private readonly double _dayOnePrice = dayOnePrice;

        public DateTime Date { get; set; }
        public double TodayPrice { get; set; }
        public double YestardayPrice { get; set; }

        public int DayOneVariation =>
            (int)Math.Ceiling(CalcVariation(TodayPrice, _dayOnePrice));

        public double YesterdayVariation =>
            CalcVariation(TodayPrice, YestardayPrice);

        private double CalcVariation(double firstValue, double secondValue) =>
            firstValue == 0 ? 0 : Math.Round(((firstValue - secondValue) / firstValue) * 100, 2);
    }
}
