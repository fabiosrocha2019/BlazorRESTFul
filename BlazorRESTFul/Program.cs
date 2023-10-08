using BlazorProject.Repository;
using BlazorRESTFul.Data;
using BlazorRESTFul.Handlers;
using BlazorRESTFul.Repository;
using BlazorRESTFul.Service;
using BlazorRESTFul.Services;
using BlazorRESTFul.Validations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri("https://localhost:7238/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IDapperService, DapperService>();
builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<ITurmaService, TurmaService>();
builder.Services.AddScoped<IAlunoRepository,AlunoRepository>();

builder.Services.AddScoped<ITurmaRepository,TurmaRepository>();
builder.Services.AddScoped<IAlunoTurmaService, AlunoTurmaService>();
builder.Services.AddScoped<IAlunoTurmaRepository, AlunoTurmaRepository>();
builder.Services.AddScoped<IHashService, HashService>();
builder.Services.AddScoped<IValidationsAlunoTurma, ValidationsAlunoTurma>();

builder.Services.AddHttpClient();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
    endpoints.MapControllers(); 
});

app.Run();
