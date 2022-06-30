using ContabilidadHogar.Database;
using ContabilidadHogar.Interfaces;
using ContabilidadHogar.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Con esto instancio el archivo de configuracion
builder.Configuration.AddJsonFile(AppDomain.CurrentDomain.BaseDirectory + "\\appsettings.db.json",
            optional: false,
            reloadOnChange: true);
//con esto obtengo la cadena de conexion

var connectionString = builder.Configuration.GetConnectionString("ApiBd");

//Inyecta dependencias
//Inyeccion de dependencias de BASE DE DATOS
builder.Services.AddDbContext<ContextMoney>(x => x.UseSqlServer(connectionString), ServiceLifetime.Scoped);
//Inyectas la dependencia del REPOSITORIO
builder.Services.AddScoped<IMoneyControlDatabaseTransactions, MoneyControlRepository>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
