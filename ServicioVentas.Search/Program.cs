using ServicioVentas.Search.Interfaces;
using ServicioVentas.Search.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICustomersService, CustomersService>();
builder.Services.AddSingleton<IProductsService, ProductsService>();
builder.Services.AddSingleton<ISalesServices, SalesService>();


builder.Services.AddHttpClient("customersService", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["Services:Customers"]);
});

builder.Services.AddHttpClient("productsService", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["Services:Products"]);
});

builder.Services.AddHttpClient("salesService", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["Services:Sales"]);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
