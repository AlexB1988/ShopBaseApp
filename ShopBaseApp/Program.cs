using Microsoft.EntityFrameworkCore;
using ShopBaseApp.Domain;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("Db");
builder.Services.AddDbContext<DataContext>(options=>options.UseNpgsql(connection),ServiceLifetime.Singleton);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
