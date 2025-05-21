using Railway.Infrastructure;
using Railway.Application;

var builder = WebApplication.CreateBuilder(args);

// ƒобавл€ем политику CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", policy =>
    {
        policy.WithOrigins("https://localhost:7033") // адрес и порт клиента Blazor WASM
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
/*builder.Services.AddSwaggerGen();
*/
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();


var app = builder.Build();

/*await app.UseMigrationAsync().ConfigureAwait(false);
*/
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/
app.UseCors("AllowBlazorClient");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();