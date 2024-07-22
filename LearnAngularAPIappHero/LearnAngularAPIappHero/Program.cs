using BLL;
using DAL;
using DAL.SqlServer;
using LearnAngularAPIappHero.Code;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(
	builder =>
	{
		builder.AllowAnyOrigin()
		.AllowAnyHeader()
		.AllowAnyMethod();
	});
});

builder.Services.AddDbContext<DataContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inject Table
builder.Services.AddScoped<IDataHelper<Hero>, HeroEntity>();

// Inject Services
builder.Services.AddScoped<IUploadFileService, UploadFileService>();

// Configure FormOptions for file uploads
builder.Services.Configure<FormOptions>(options =>
{
	options.MultipartBodyLengthLimit = 52428800; // 50 MB
});

// Add logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
