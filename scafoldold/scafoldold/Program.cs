using Microsoft.EntityFrameworkCore;
using scafoldold.Mapping;
using scafoldold.Models;
using scafoldold.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

// ✅ Register AutoMapper HERE
builder.Services.AddAutoMapper(typeof(MappingProfile));


// Add services to the container.
builder.Services.AddDbContext<DatasContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.Parse("8.0.44-mysql")
    )
);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        builder => builder
            .WithOrigins("https://localhost:44309")
            //.WithOrigins("https://localhost:44386")
            .AllowAnyHeader()
            .AllowAnyMethod()
    );
});

builder.Services.AddScoped<IDeleteservice, UserDeleteService>();
builder.Services.AddScoped<IPostUserService, PostUserService>();
builder.Services.AddScoped<Ipatchservice, PatchUserService>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthorization();
app.MapControllers();

app.Run();
