using Core_MVC_Example.Areas.BackEnd.Interface;
using Core_MVC_Example.Models;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// 注入 OBizCommom.Basic
builder.Services.AddSingleton<OBizCommonClass.Basic>(con => {
    // db_ConnectionString預設帶入值(appsettings.json裡ConnectionStrings的DBConnectionString設定值)
    OBizCommonClass.Basic basic = new OBizCommonClass.Basic
    {
        appName = builder.Configuration.GetConnectionString("AppName"),
        db_ConnectionString = builder.Configuration.GetConnectionString("DBConnectionString")
    };

    return basic;
});

// Route Mapping START
builder.Services.Configure<RazorViewEngineOptions>(options => {
    options.ViewLocationFormats.Clear();

    options.ViewLocationFormats.Add("/Areas/BackEnd/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
    options.ViewLocationFormats.Add("/Areas/BackEnd/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
    options.ViewLocationFormats.Add("/Areas/BackEnd/Views/Shared/{0}" + RazorViewEngine.ViewExtension);

    options.ViewLocationFormats.Add("/FrontEnd/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
    options.ViewLocationFormats.Add("/FrontEnd/Views/Shared/{0}" + RazorViewEngine.ViewExtension);
});
// Route Mapping END


builder.Services.AddDbContext<CoreMvcExampleContext>();


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

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller}/{action=Index}/{id?}/");

app.MapControllerRoute(
    name: "front",
    pattern: "/{controller=Default}/{action=Index}/{id?}/");

app.Run();
