using ToDo.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder
    .AddBearerAuthentication()
    .AddOptions()
    .AddSwagger()
    .AddDataAccess()
    .AddMediatr()
    .AddApplicationServices()
    .AddBackgroundServices()
    .AddCors();

var app = builder.Build();

app.UseCors("AllowLocalhost");
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();