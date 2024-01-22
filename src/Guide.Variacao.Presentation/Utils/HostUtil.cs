namespace Guide.Variacao.Presentation.Utils
{
    public static class HostUtil
    {
        public static WebApplicationBuilder Configure(this WebApplicationBuilder builder)
        {
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            builder.Configuration.AddConfiguration(configBuilder);

            builder.Services.AddServices(builder.Configuration);

            return builder;
        }


    }
}
