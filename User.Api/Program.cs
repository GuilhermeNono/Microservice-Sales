using User.Api.Model;

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

app.MapGet("/users", () => UserWrapper.Users)
    .WithName("GetUsers")
    .WithOpenApi();

app.MapGet("/users/{id}", (int id) => UserWrapper.Users.FirstOrDefault(f => f.Id == id))
    .WithName("GetUserById")
    .WithOpenApi();

app.MapPost("/users", (User.Api.Model.User user) =>
    {
        UserWrapper.Users.Add(user);
        return Results.Created($"/users/{user.Id}", user);
    })
    .WithName("InsertUser")
    .WithOpenApi();

app.MapDelete("/users/{id}", (int id) =>
    {
        var user = UserWrapper.Users.FirstOrDefault(f => f.Id == id);
        
        if (user is null) 
            return Results.NotFound();
        
        UserWrapper.Users.Remove(user);
        return Results.NoContent();
    })
    .WithName("RemoveUser")
    .WithOpenApi();

app.Run();
