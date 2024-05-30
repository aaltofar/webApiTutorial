using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using webApiTutorial.Data;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    EnvironmentName = Environments.Development
});
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.WebHost.UseStaticWebAssets();

var app = builder.Build();
app.UseAntiforgery();
// Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
app.UseExceptionHandler("/Error");
// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
app.UseHsts();
app.UseSwagger();
app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
// }

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthorization();
app.UseRouting();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
