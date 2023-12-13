using MiniBank.Api.Data;
using MiniBank.Api.Endpoints;
using MiniBank.Api.Repository;
using MiniBank.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<BankDb>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<TransactionRepository>();
builder.Services.AddScoped<TransactionServices>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.StartUserEndpoints();
app.StartTransactionsEndpoints();

app.Run();

