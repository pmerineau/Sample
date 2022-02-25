using Sample.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// ca c'est pour que les API puissent etre appeles via un client web d'une autre addresse/port
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", b =>
        b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// DI pour la couche repo
builder.Services.ConfigureRepository();
// DI pour la couche services
builder.Services.ConfigureService();
// config Sql Server
builder.Services.ConfigureSqlContext(builder.Configuration);
// config Automapper
builder.Services.ConfigureAutoMapper();

// Pour Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
    
// TODO a remettre si sous https
// app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

// pour les migrations EF:
// a partir du repertoire \Sample.Repo
// >dotnet ef migrations add XXXXXX --startup-project ../Sample.API/Sample.API.csproj
// >dotnet ef database update --startup-project ../Sample.API/Sample.API.csproj
