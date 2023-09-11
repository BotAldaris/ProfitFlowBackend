using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProfitFlowBackend.Data;
using ProfitFlowBackend.Models;
using ProfitFlowBackend.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration["ConnectionStrings:UsuarioConnection"];
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin() // Substitua com a URL real do seu aplicativo Expo.
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
builder.Services.AddDbContext<ProfitFlowDbContext>
    (opts =>
    {
        opts.UseLazyLoadingProxies().UseMySql(connString, ServerVersion.AutoDetect(connString));
    });
builder.Services.AddIdentity<Usuario, IdentityRole>().AddEntityFrameworkStores<ProfitFlowDbContext>().AddDefaultTokenProviders();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SymmetricSecurityKey"])),
    ValidateAudience = false,
    ValidateIssuer = false,
    ClockSkew = TimeSpan.Zero
}); ;
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TokenService>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();
