using Microsoft.EntityFrameworkCore;
using PlantCare.Persistencia;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "User Id=;Password=;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=orcl)));";


builder.Services.AddDbContext<PlantCareContext>(options =>
    options.UseOracle(connectionString));


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "detalhesPlanta",
    pattern: "planta/detalhes/{id}",
    defaults: new { controller = "Planta", action = "DetalharPlanta" });

app.MapControllerRoute(
    name: "novaPlanta",
    pattern: "planta/nova",
    defaults: new { controller = "Planta", action = "CadastrarPlanta" });

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Planta}/{action=ListarPlantas}/{id?}");

app.Run();
