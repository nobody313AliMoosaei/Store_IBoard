using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Store_IBoard.DL.ApplicationDbContext;
using Store_IBoard.DL.UnitOfWork;
using Store_IBoard.BL.ApplicationBusiness.SignUp;
using Store_IBoard.BL.Services.Session;
using Store_IBoard.Utlities.ExtentionHost;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

#region Session Manager
builder.Services.AddDistributedMemoryCache();
builder.Services.AddMemoryCache();
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(5);
});

#endregion

/*
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
*/

#region Sql server Configuration
builder.Services.AddDbContext<ApplicationDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration["StringConnection:SQLConnection"]);
});
#endregion

#region MongoDB Setting

#endregion

#region UserManagement
builder.Services
    .AddIdentity<Store_IBoard.DL.Entities.Users, Store_IBoard.DL.Entities.Roles>()
    .AddEntityFrameworkStores<ApplicationDBContext>()
    .AddDefaultTokenProviders()
    .AddRoles<Store_IBoard.DL.Entities.Roles>();


builder.Services.Configure<IdentityOptions>(options =>
{
    // Password Config
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 7;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    
    // User Config
    options.User.RequireUniqueEmail = false;

    // SignIn
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedAccount = false;

});
#endregion

#region IOC

builder.Services.AddTransient<Store_IBoard.BL.Services.JWT.IJWTTokenManager, Store_IBoard.BL.Services.JWT.JWTTokenManager>();
builder.Services.AddTransient<ISignUpService, SignUpService>();
builder.Services.AddSingleton<Store_IBoard.BL.Services.Eamil.IEmailService, Store_IBoard.BL.Services.Eamil.EmailService>();
builder.Services.AddSingleton< Store_IBoard.BL.Services.Session.ISessionService,Store_IBoard.BL.Services.Session.SessionManager>();
builder.Services.AddTransient(typeof(RepositoryGeneric<>));
builder.Services.AddTransient<Store_IBoard.BL.Services.General.IGeneralService, Store_IBoard.BL.Services.General.GeneralService>();
builder.Services.AddTransient<Store_IBoard.BL.Services.BackUpDatabase.IBackUpDatabase, Store_IBoard.BL.Services.BackUpDatabase.BackUpDatabase>();
builder.Services.AddTransient<Store_IBoard.BL.Services.SMS.ISMS, Store_IBoard.BL.Services.SMS.SMS>();
#endregion

#region JWT Authentication
builder.Services.AddAuthentication(t =>
{
    t.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    t.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    t.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = builder.Configuration["JWTConfiguration:issuer"],
        ValidAudience = builder.Configuration["JWTConfiguration:audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTConfiguration:key"])),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true
    };
});
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.CacheCategoryGroup();

app.MapControllers();

app.Run();
