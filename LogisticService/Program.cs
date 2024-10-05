using LogisticService.Data;
using LogisticService.Mapper;
using LogisticService.Middlewares;
using LogisticService.Models.Cars;
using LogisticService.Responses;
using LogisticService.Services;
using LogisticService.Services.CalculationServices;
using LogisticService.Services.CarTypeServices;
using LogisticService.Services.ContainerServices;
using LogisticService.Services.CrushedServices;
using LogisticService.Services.DirectionServices;
using LogisticService.Services.LogisticServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
	var conn = builder.Configuration["ConnectionStrings:SqlServer"];//builder.Configuration.GetConnectionString("SqlServer");
	options.UseSqlServer(conn);
	options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddTransient<LogisticService.Services.IAuthenticationService, UserService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ICarModelService, CarService>();
builder.Services.AddTransient<ICarBrandService, CarService>();
builder.Services.AddTransient<ICalculationService, CalculationService>();
builder.Services.AddTransient<IDirectionService, DirectionService>();
builder.Services.AddTransient<ICarTypeService, CarTypeService>();
builder.Services.AddTransient<ILogisticService, LogisticService.Services.LogisticServices.LogisticService>();
builder.Services.AddTransient<IContainerService, ContainerService>();
builder.Services.AddTransient<ICarCrushedService, CarCrushedService>();
builder.Services.AddTransient<IMapper<CarBrand, CarBrandEntity>, CarBrandMapper>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddTransient<IMapper<CarModel, CarModelEntity>, CarModelMapper>();

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
	options.TokenValidationParameters = new TokenValidationParameters
	{
		// Other validation parameters
		ValidateIssuer = true,
		ValidateAudience = false,
		ValidateIssuerSigningKey = true,
		ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Secret"])),
		ClockSkew = TimeSpan.Zero
	};
});


builder.Services.AddSingleton<CustomTokenMiddleware>();
//builder.Services.AddDefaultCorsPolicy();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseMiddleware<CustomTokenMiddleware>();

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
