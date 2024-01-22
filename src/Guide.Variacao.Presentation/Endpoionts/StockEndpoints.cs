using Guide.Variacao.Core.DataBase.Repository;
using Guide.Variacao.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Guide.Variacao.Domain.Models;
using AutoMapper;
using Guide.Variacao.Core.Domain.ViewModels;

namespace Guide.Variacao.Presentation.Endpoionts
{
    public static class StockEndpoints
    {
        public static void RegisterStockEndpoints(this IEndpointRouteBuilder endpoint)
        {
            // GET
            endpoint.MapGet("/stocks", (IRepository<Stock> repository, IMapper mapper) =>
            {
                List<Stock> stocks = repository.Get().ToList();

                var stocksViewModel = mapper.Map<List<StockViewModel>>(stocks);

                return Results.Ok(stocksViewModel);
            })
                .WithName("GetStocks");

            // GET BY ID
            endpoint.MapGet("/stocks/{id}", (IRepository<Stock> repository, IMapper mapper, Guid id) =>
            {
                var stock = repository.Get(s => s.Id == id)
                    .Include(s => s.Auctions)
                    .Include(s => s.TradingPeriods)
                    .FirstOrDefault();

                var stockViewModel = mapper.Map<StockViewModel>(stock);

                return stockViewModel is not null? Results.Ok(stockViewModel) : Results.NotFound();
            })
                .WithName("GetStocksById");

            // GET
            endpoint.MapGet("/stocks/{id}/variation", (IRepository<Stock> repository, IMapper mapper, Guid id, string? startDate = null) =>
            {
                var parsedStartDate = startDate is null ? DateTime.UtcNow.AddMonths(-1) : DateTime.ParseExact(startDate, "dd-MM-yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);

                if (repository.Get(s => s.Id == id)
                    .Include(s => s.Auctions.Where(a => a.TimeStamp.ToUniversalTime() > parsedStartDate.AddMonths(-1)))
                    .Include(s => s.TradingPeriods)
                    .FirstOrDefault() is not Stock stock)
                    return Results.Problem(statusCode: 404);

                var stockViewModel = mapper.Map<StockViewModel>(stock);

                double dayOnePrice = stockViewModel.AuctionsViewModel[0].Open;

                StockVariation stockVar = new()
                {
                    
                    StartDate = parsedStartDate,
                    DayOnePrice = dayOnePrice
                };

                double yesterdayPrice = 0;
                foreach (var auction in stockViewModel.AuctionsViewModel)
                {
                    stockVar.Variations.Add(new Variation(dayOnePrice)
                    {
                        Date = auction.TimeStamp,
                        TodayPrice = auction.Open,
                        YestardayPrice = yesterdayPrice,
                    });

                    yesterdayPrice = auction.Open;
                }

                return Results.Ok(stockVar);
            })
                .WithName("GetStocksVariation")
                .WithOpenApi();
        }
    }
}
