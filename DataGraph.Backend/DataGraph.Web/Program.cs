using DataGraph.Data;
using DataGraph.Web.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddOptions();
builder.Services.AddHttpsRedirection(options => 
{
    options.HttpsPort = 5001;
});

// Add services to the container.

builder.AddDataContext();
builder.AddNonDataService();

builder.Services.AddControllers();
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

app.UseCors(cpb => cpb.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseRequestTimeLogMiddleware();

app.MapControllers();

app.MigrateDbContext<DataContext>();

app.Run();
