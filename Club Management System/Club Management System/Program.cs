using Club_Management_System.Data;
using Club_Management_System.Mapper;
using Club_Management_System.Repos.Implementation;
using Club_Management_System.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

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
