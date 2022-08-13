using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http.Features;
using System.ServiceModel;
using System.Text;
using System.Web.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<FormOptions>(options =>
{
    // Set the limit to 128 MB
    options.MultipartBodyLengthLimit = 209715200;
    options.BufferBodyLengthLimit = 209715200;
    options.ValueLengthLimit = 209715200;
});


var customBinding = new WSHttpBinding(SecurityMode.Transport, false);


customBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
customBinding.ReaderQuotas.MaxDepth = 2147483647;
customBinding.ReaderQuotas.MaxStringContentLength = 2147483647;
customBinding.ReaderQuotas.MaxArrayLength = 2147483647;
customBinding.ReaderQuotas.MaxBytesPerRead = 2147483647;
customBinding.ReaderQuotas.MaxNameTableCharCount = 2147483647;

customBinding.CloseTimeout = new TimeSpan(0, 10, 0);
customBinding.OpenTimeout = new TimeSpan(0, 10, 0);
customBinding.ReceiveTimeout = new TimeSpan(0, 10, 0);
customBinding.SendTimeout = new TimeSpan(0, 10, 0);
customBinding.BypassProxyOnLocal = false;
customBinding.TransactionFlow = false;
customBinding.MaxBufferPoolSize = 2147483647;
customBinding.MaxReceivedMessageSize = 2147483647;
customBinding.TextEncoding = Encoding.UTF8;
customBinding.UseDefaultWebProxy = true;
customBinding.AllowCookies = false;


customBinding.ReliableSession.Ordered = true;
customBinding.ReliableSession.InactivityTimeout = new TimeSpan(0, 10, 0);



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
