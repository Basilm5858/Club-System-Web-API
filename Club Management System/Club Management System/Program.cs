using Club_Management_System.Data;
using Club_Management_System.Mapper;
using Club_Management_System.Repos.Implementation;
using Club_Management_System.Repos.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<My_AppContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("conn"))
    );

builder.Services.AddScoped<MemberCustomRepo>();
builder.Services.AddScoped<BookingCustomRepo>();
builder.Services.AddScoped<FacilityCustomRepo>();
builder.Services.AddScoped<PaymentCustomRepo>();
builder.Services.AddScoped<AuthRepoCustomRepo>();
builder.Services.AddScoped<MemberShipCustomRepo>();



builder.Services.AddScoped<IMember, MemberCustomRepo>();
builder.Services.AddScoped<IBooking, BookingCustomRepo>();
builder.Services.AddScoped<IFacility, FacilityCustomRepo>();
builder.Services.AddScoped<IPayment, PaymentCustomRepo>();
builder.Services.AddScoped<IMemberShip, MemberShipCustomRepo>();
builder.Services.AddScoped<IAuthRepo, AuthRepoCustomRepo>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(
    x => x.AddProfile<MappingProfile>()
    );

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]));
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(opt =>
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Iss"],

        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Aud"],

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = key
    });


var app = builder.Build();
app.UseCors("AllowFrontend");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
