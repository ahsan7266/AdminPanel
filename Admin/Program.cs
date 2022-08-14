using Microsoft.AspNetCore.Http.Features;
using System.ServiceModel;
using System.Text;
using System.Web.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<FormOptions>(options =>
{
    // Set the limit to 128 MB
    options.MultipartBodyLengthLimit = 509715200;
    options.BufferBodyLengthLimit = 509715200;
    options.ValueLengthLimit = 509715200;
});


var customBinding = new WSHttpBinding(SecurityMode.Transport, false);


customBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
customBinding.ReaderQuotas.MaxDepth = 509715200;
customBinding.ReaderQuotas.MaxStringContentLength = 509715200;
customBinding.ReaderQuotas.MaxArrayLength = 509715200;
customBinding.ReaderQuotas.MaxBytesPerRead = 509715200;
customBinding.ReaderQuotas.MaxNameTableCharCount = 509715200;

customBinding.CloseTimeout = new TimeSpan(1, 10, 0);
customBinding.OpenTimeout = new TimeSpan(1, 10, 0);
customBinding.ReceiveTimeout = new TimeSpan(1, 10, 0);
customBinding.SendTimeout = new TimeSpan(1, 10, 0);
customBinding.BypassProxyOnLocal = false;
customBinding.TransactionFlow = false;
customBinding.MaxBufferPoolSize = 509715200;
customBinding.MaxReceivedMessageSize = 509715200;
customBinding.TextEncoding = Encoding.UTF8;
customBinding.UseDefaultWebProxy = true;
customBinding.AllowCookies = false;


customBinding.ReliableSession.Ordered = true;
customBinding.ReliableSession.InactivityTimeout = new TimeSpan(1, 10, 0);



builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromSeconds(1000);
    x.Cookie.HttpOnly = true;
    x.Cookie.IsEssential = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;

    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Dashboard}/{id?}");

app.Run();
