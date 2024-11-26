using Product.Api.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/products", () => ProductWrapper.Products)
    .WithName("GetProducts")
    .WithOpenApi();

app.MapGet("/products/{id}", (int id) => ProductWrapper.Products.FirstOrDefault(f => f.Id == id))
    .WithName("GetProductById")
    .WithOpenApi();

app.MapPost("/products", (Product.Api.Model.Product product) =>
    {
        ProductWrapper.Products.Add(product);
        return Results.Created($"/products/{product.Id}", product);
    })
    .WithName("InsertProduct")
    .WithOpenApi();

app.MapDelete("/products/{id}", (int id) =>
    {
        var product = ProductWrapper.Products.FirstOrDefault(f => f.Id == id);
        
        if (product is null) 
            return Results.NotFound();
        
        ProductWrapper.Products.Remove(product);
        return Results.NoContent();
    })
    .WithName("RemoveProduct")
    .WithOpenApi();


app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
