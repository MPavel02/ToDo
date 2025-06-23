using ToDo.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder
    .AddBearerAuthentication()
    .AddOptions()
    .AddSwagger()
    .AddDataAccess()
    .AddMediatr()
    .AddApplicationServices()
    .AddBackgroundServices();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();