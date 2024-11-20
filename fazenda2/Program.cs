using System.Globalization;
using Microsoft.AspNetCore.Localization;
using fazenda2.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Configura o DbContext para usar SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DbPath")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // O valor padrao do HSTS � 30 dias. Voc� pode querer alterar isso para cen�rios de produ��o.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Configura��o de cultura
var defaultCulture = new CultureInfo("pt-BR");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(defaultCulture),
    SupportedCultures = new List<CultureInfo> { defaultCulture },
    SupportedUICultures = new List<CultureInfo> { defaultCulture }
};

// Adiciona a configura��o de localiza��o ao pipeline de middleware
app.UseRequestLocalization(localizationOptions);

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
