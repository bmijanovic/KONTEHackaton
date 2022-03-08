using KONTEHackaton.Data.Context;
using KONTEHackaton.Domain.Services;
using KONTEHackaton.Domain.Interfaces;
using KONTEHackaton.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("FacultyConnection");
builder.Services.AddDbContext<FacultyContext>(x => x.UseSqlServer(connectionString));


builder.Services.AddTransient<IFacultyRepository, FacultiesRepository>();
builder.Services.AddTransient<IRoomsRepository, RoomsRepository>();
builder.Services.AddTransient<IDesksRepository, DeskRepository>();

builder.Services.AddTransient<IFacultyService, FacultyService>();
builder.Services.AddTransient<IRoomService, RoomService>();
builder.Services.AddTransient<IDeskService, DeskService>();

//builder.Services.AddCors(options => {
//    options.AddPolicy("CorsPolicy",
//        corsBuilder => corsBuilder.WithOrigins("http://localhost:3000")
//            .AllowAnyMethod()
//            .AllowAnyHeader()
//            .AllowCredentials());
//});

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
