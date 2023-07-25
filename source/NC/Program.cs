using PIMTool;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using NHibernate;
using ISession = NHibernate.ISession;
using ServiceLayer.Middlewares;
using ServiceLayer.ServiceLifeCycleExtension;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddLocalization(options => { options.ResourcesPath = "Resources"; });
// Add services to the container.
builder.Services.AddRazorPages().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();


builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
                    new CultureInfo("en"),
                    new CultureInfo("fr")   
                };

    options.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");
    options.SupportedUICultures = supportedCultures;
    options.SupportedCultures = supportedCultures;
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddNhibernate();
builder.Services.AddDataAccessServices();
builder.Services.AddServices();
builder.Services.AddGlobalResourceFile();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/UnexpectedError");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/Home/UnexpectedError";
        await next();
    }
});

// 4. 
var supportedCultures = new[] { "en", "fr" };
// 5. 
// Culture from the HttpRequest
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
