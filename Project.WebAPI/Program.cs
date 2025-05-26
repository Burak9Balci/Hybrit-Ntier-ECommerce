
using Project.BusinessLogicLayer.DependencyResolvers;
using Project.WebAPI.Models.MappingService;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();




builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromMinutes(60);
    x.Cookie.HttpOnly = true;
    x.Cookie.IsEssential = true;
});
builder.Services.AddCorsService();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddDbContextService();
builder.Services.AddIdentityService();
builder.Services.AddManagerService();
builder.Services.AddRepositoryService();
builder.Services.AddMapperService();
builder.Services.AddRequestResponseMapperService();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors("AllowReactApp");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllers();

app.Run();
