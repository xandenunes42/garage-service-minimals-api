using domain.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapPost("/login", (LoginDTO loginDTO) =>
{
    if (loginDTO.Email == "adm@teste.com" && loginDTO.Password == "123456")
    {
        return Results.Ok("Sucesso!");
    }
    else
    {
        return Results.Unauthorized();
    }
});
