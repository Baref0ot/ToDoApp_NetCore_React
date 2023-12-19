using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var allowedOrigins = "_allowedOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// JSON Serializer
builder.Services.AddControllers()
    .AddNewtonsoftJson(options => 
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());


// Configure custom CORS policy Whitelisted host
builder.Services.AddCors(options => {
    options.AddPolicy(name: allowedOrigins, policy => {
        policy.WithOrigins("http://localhost:3000/").AllowAnyOrigin();
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

// Enable CORS
app.UseCors(allowedOrigins);

app.MapControllers();

app.Run();
