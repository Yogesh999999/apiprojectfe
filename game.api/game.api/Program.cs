using game.api.dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<gamedto> games = [new(1, "streetfighter", "male", 90, new DateOnly(1992, 7, 15))];

app.MapGet("games",() => games);

app.MapGet("games/{id}",(int id) =>games.Find(game=>game.id == id));

app.Run();
