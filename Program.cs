using Lesson.DI.DomainEvents;
using MVC_study;
using MVC_study.DomainEvents;
using MVC_study.Middleware;
using MVC_study.Models;
using MVC_study.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ICatalog, Catalog>();

builder.Services.AddSingleton<IMetrics, Metrics>();

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection(nameof(MVC_study.MailSettings)));
builder.Services.AddSingleton<IMailService, MailService>();

builder.Services.AddHostedService<ProductAddedMailSender>();

builder.Services.AddHostedService<MyBackgroundService>();

builder.Services.AddHttpLogging(opt => opt.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestBody
                                                           | Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponseBody);


builder.Host.UseSerilog((ctx, conf) =>
{
    conf.ReadFrom.Configuration(ctx.Configuration);
});


var app = builder.Build();

app.UseMiddleware<RequestLogginMiddleware>();

app.UseHttpLogging();

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

app.MapRazorPages();

app.Run();
