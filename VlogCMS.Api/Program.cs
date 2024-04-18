using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VlogCMS.Api.Data;
using VlogCMS.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("AppConnection"));
});

builder.Services.AddScoped<CategoryService>();

//builder.Services.AddDbContext<AuthDbContext>(options =>
//{
//    options.UseNpgsql(builder.Configuration.GetConnectionString("AuthConnection"));
//});

//builder.Services.AddIdentityCore<IdentityUser>()
//    .AddEntityFrameworkStores<AuthDbContext>()
//    .AddApiEndpoints();

//builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
//builder.Services.AddAuthorizationBuilder();

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
//app.MapIdentityApi<IdentityUser>();

app.Run();