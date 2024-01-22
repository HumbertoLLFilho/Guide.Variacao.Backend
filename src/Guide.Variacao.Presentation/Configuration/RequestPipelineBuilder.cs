namespace Guide.Variacao.Presentation.Configuration
{
    public static class RequestPipelineBuilder
    {
        public static void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStatusCodePages(async statusCodeContext
                => await Results.Problem(statusCode: statusCodeContext.HttpContext.Response.StatusCode)
                    .ExecuteAsync(statusCodeContext.HttpContext));


            app.UseHttpsRedirection();

            app.UseAuthorization();

        }
    }
}
