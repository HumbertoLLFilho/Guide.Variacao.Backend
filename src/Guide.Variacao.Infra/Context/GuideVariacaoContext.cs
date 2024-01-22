using Guide.Variacao.Core.Domain.Models;
using Guide.Variacao.Core.DataBase.Map;
using Microsoft.EntityFrameworkCore;

namespace Guide.Variacao.Infra.Context
{
    public class GuideVariacaoContext : DbContext
    {
        public GuideVariacaoContext(DbContextOptions<GuideVariacaoContext> options) : base(options)
        {
            Database.SetCommandTimeout(3000);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();

            modelBuilder.ApplyConfiguration(new StockMap());
            modelBuilder.ApplyConfiguration(new AuctionMap());
            modelBuilder.ApplyConfiguration(new TradingPeriodMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<TradingPeriod> TradingPeriods { get; set; }

    }
}
