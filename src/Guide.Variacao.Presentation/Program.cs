using Guide.Variacao.Presentation.Configuration;
using Guide.Variacao.Presentation.Endpoionts;

// Get WebApplication instance
var app = AppBuilder.GetApp(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure Request Pipeline
RequestPipelineBuilder.Configure(app);

// Configure APIs 
StockEndPoint.RegisterEndpoints(app);

// Start the app
app.Run();