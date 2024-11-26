using Sale.Api.Model;

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

app.MapGet("/sales", () => SaleWrapper.Sales)
    .WithName("GetSales")
    .WithOpenApi();

app.MapGet("/sales/{id}", (int id) => SaleWrapper.Sales.FirstOrDefault(f => f.Id == id))
    .WithName("GetSaleById")
    .WithOpenApi();

app.MapPost("/sales", (Sale.Api.Model.Sale sale) =>
    {
        SaleWrapper.Sales.Add(sale);
        return Results.Created($"/sales/{sale.Id}", sale);
    })
    .WithName("InsertSale")
    .WithOpenApi();

app.MapDelete("/sales/{id}", (int id) =>
    {
        var sale = SaleWrapper.Sales.FirstOrDefault(f => f.Id == id);
        
        if (sale is null) 
            return Results.NotFound();
        
        SaleWrapper.Sales.Remove(sale);
        return Results.NoContent();
    })
    .WithName("RemoveSale")
    .WithOpenApi();

app.Run();
