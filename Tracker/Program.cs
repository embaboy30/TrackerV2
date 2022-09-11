using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tracker.Data;
using Tracker.Data.Model;
using Tracker.IRepository;
using Tracker.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<TrackerDbContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("HerokuDb"))
);


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<TrackerDbContext>()
    .AddDefaultTokenProviders();

// Repository
builder.Services.AddTransient<ITodoRepository, TodoRepository>();
builder.Services.AddTransient<INoteRepository, NoteRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(p => p.AddPolicy("corspolicy", build=>
{
    build.WithOrigins("http://localhost:4200", "https://trackerapp-37b9c.firebaseapp.com", "https://trackerapp-37b9c.web.app").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corspolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
