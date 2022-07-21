using System.Linq;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Console.WriteLine("Test");

//comentando el codigo
app.MapGet("/", () => "Hello World2!");

// /hello?name=name
app.MapGet("/hello", (string name) => $"Hola {name}");

//le mandamos el dato por la url
app.MapGet("/hellowithname/{name}/{lastname}",
    (string name, string lastname) => $"Hola {name} {lastname}");
//
app.MapGet("/response", async () =>
{
    HttpClient client = new HttpClient();
    var response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos/");
    response.EnsureSuccessStatusCode();
    string responseBody = await response.Content.ReadAsStringAsync();
    return responseBody;
});

//traer pokemon por su id
app.MapGet("/pokemon/{id}", async (string id) =>
{
    HttpClient client = new HttpClient();
    var response = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
    response.EnsureSuccessStatusCode();
    string responseBody = await response.Content.ReadAsStringAsync();
    return responseBody;
});
//traer pokemons 
app.MapGet("/pokemon", async () =>
{
    HttpClient client = new HttpClient();
    var response = await client.GetAsync("https://pokeapi.co/api/v2/pokemon/");
    response.EnsureSuccessStatusCode();
    string responseBody = await response.Content.ReadAsStringAsync();
    return responseBody;
});



app.Run();
  