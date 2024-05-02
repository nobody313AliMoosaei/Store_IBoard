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
using Microsoft.AspNetCore.ResponseCompression;
using Store_IBoard.DL.ToolsBLU;
using Store_IBoard.BL.Services.BackUpDatabase;
using Microsoft.AspNetCore.Mvc;
using System.Buffers.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Store_IBoard.Utlities.Attributes;
using Store_IBoard.Utlities.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

#region GZip
builder.Services.Configure<GzipCompressionProviderOptions>(config =>
{
    config.Level = System.IO.Compression.CompressionLevel.Optimal;
});
builder.Services.AddResponseCompression(option =>
{
    option.Providers.Add<GzipCompressionProvider>();
    option.EnableForHttps = true;
});
#endregion

#region Session Manager
builder.Services.AddDistributedMemoryCache();
builder.Services.AddMemoryCache();
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(5);
});

#endregion

SystemConsts.SettingConfiguration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("SettingConfiguration.json").Build();
SystemConsts.PrivateKey = builder.Configuration["Security:PrivateKey"];
#region Sql server Configuration
SystemConsts.ConnectionString = builder.Configuration["StringConnection:SQLConnection"];
builder.Services.AddDbContext<ApplicationDBContext>(option =>
{
    option.UseSqlServer(SystemConsts.ConnectionString);
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
builder.Services.AddSingleton<Store_IBoard.BL.Services.Session.ISessionService, Store_IBoard.BL.Services.Session.SessionManager>();
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
    //option.SecurityTokenValidators.Clear();
    //option.SecurityTokenValidators.Add(new CustomSecurityJWTToken());

    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = builder.Configuration["JWTConfiguration:issuer"],
        ValidAudience = builder.Configuration["JWTConfiguration:audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTConfiguration:key"])),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateActor = true,
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

//using (var scop = app.Services.CreateScope())
//{
//    var BackUpService = scop.ServiceProvider.GetRequiredService<IBackUpDatabase>();
//    await BackUpService.BackUpDatabase();

//}

app.UseHttpsRedirection();
app.UseSession();

app.UseMiddleware<DecodeTokenMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.UseResponseCompression();
app.UseCors(cors =>
{
    cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

//app.CacheCategoryGroup();

app.MapControllers();

app.Run();
