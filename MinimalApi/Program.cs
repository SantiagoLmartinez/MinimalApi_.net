var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


//comentando el codigo
app.MapGet("/", () => "Hello World!1");

app.Run();
