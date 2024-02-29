using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Redis Configuration
builder.Services.AddDistributedMemoryCache();
builder.Services.AddMemoryCache();
if (Convert.ToBoolean(builder.Configuration["RedisConfiguration:RedisEnable"]))
{
    builder.Services.AddStackExchangeRedisCache(option =>
    {
        option.Configuration = builder.Configuration["RedisConfiguration:RedisConnection"];
        option.InstanceName = builder.Configuration["RedisConfiguration:RedisInstanceName"];
    });
}

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
