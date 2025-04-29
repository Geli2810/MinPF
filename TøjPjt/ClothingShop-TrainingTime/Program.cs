using ClothingShop_TrainingTime.Data;
using ClothingShop_TrainingTime.Pages.Services.Produkt_Services;
using ClothingShop_TrainingTime.Pages.TheSearchProduct;
using ClothingShop_TrainingTime.Pages.UserSider.ProduktSide;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddScoped<ProduktServices>();
builder.Services.AddScoped<TheProductsModel>();
builder.Services.AddScoped<VidersendeProduktModel>();

builder.Services.AddSqlServer<ClothDBContext>(
    builder.Configuration.GetConnectionString("ClothingShopContext"));

var app = builder.Build();
StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

app.UseRouting();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Betaling}/{action=Index}/{id?}");


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
