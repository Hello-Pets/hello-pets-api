using System.Text.Json.Serialization;
using HelloPets.Application.Services;
using HelloPets.Application.Services.Interfaces;
using HelloPets.Data.Context;
using HelloPets.Data.Repositories;
using HelloPets.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseInMemoryDatabase("BancoDeDadosEmMemoria"));

builder.Services.AddTransient<IPasswordService, PasswordService>();
builder.Services.AddTransient<ITutorRepository, TutorRepository>();
builder.Services.AddTransient<IPetRepository, PetRepository>();

var app = builder.Build();

if(app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();