using Api.Common;
using Api.Common.Models;
using web_api.Middleware;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMongo();
builder.Services.AddRepositry<Customer>("customers");

builder.Services.AddTransient<MyMiddleware>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MyMiddleware();
//app.UseWhen(context => context.Request.Query.ContainsKey("IsAuthorized") && context.Request.Query["IsAuthorized"] == "true",

//   app =>
//   {
//       app.Use(async (context, next) =>
//       {
//           await context.Response.WriteAsync("Conditional middleware");
//           await next(context);
//       });

//   });
app.MapControllers();

//app.UseMiddleware<MyMiddleware>();
////app.MyMiddleware();
//app.UseWhen(context => context.Request.Query.ContainsKey("IsAuthorized") && context.Request.Query["IsAuthorized"]==true,

//   app =>
//   {
//      app.Use(async (context, next) =>
//      {
//         await context.Response.WriteAsync("Conditional middleware");
//         await next(context);
//      });

//   });
app.Run();
