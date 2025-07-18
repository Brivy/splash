var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        // To preserve the default behavior, capture the original delegate to call later.
        var builtInFactory = options.InvalidModelStateResponseFactory;
        options.InvalidModelStateResponseFactory = context =>
        {
            var logger = context.HttpContext.RequestServices
                                .GetRequiredService<ILogger<Program>>();

            var errors = context.ModelState
                .Where(e => e.Value != null && e.Value.Errors.Count > 0)
                .Select(e => new
                {
                    Field = e.Key,
                    Errors = e.Value!.Errors.Select(er => er.ErrorMessage)
                });

            var errorLog = string.Join("; ", errors.Select(e => $"{e.Field}: {string.Join(", ", e.Errors)}"));
            logger.LogWarning("Model validation failed: {ValidationErrors}", errorLog);

            return builtInFactory(context);
        };
    });
builder.Services.AddOpenApi();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    _ = app.MapOpenApi();
    _ = app.UseDeveloperExceptionPage();
}
else
{
    _ = app.UseHttpsRedirection();
}

app.MapControllers();
app.Run();