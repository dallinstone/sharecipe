using api;
using api.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyCORSPolicy", builder => builder.WithOrigins("http://localhost:3000")
    .SetIsOriginAllowedToAllowWildcardSubdomains().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddDbContext<SharecipedevContext>(options => options.UseMySQL(builder.Configuration["ConnectionStrings:localhostMySql"]));

var mapperConfig = new MapperConfiguration(mc => 
{
    mc.AddProfile(new EntityToDtoMappingProfile());
    mc.AddProfile(new DtoToEntityMappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("MyCORSEPolicy");
//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
