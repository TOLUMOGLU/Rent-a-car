var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

// app.MapGet("/", () => "Hello World!");
app.MapControllerRoute("/Anasayfa","{controller=Anasayfa}/{action=Index}/{id?}");

app.Run();
//Araçlarýn plaka, marka, model ve renk bilgisi tutulmalýdýr. Her bir aracýn dahil olduðu sýnýfa 
//iliþkin ID, sýnýf ve kiralama bedeli bilgisi tutulmalýdýr. Bir müþteri ayný anda birçok araç 
//kiralayabilir. Müþterilerin TCK numarasý, adý, adresi ve telefon numarasý tutulmalýdýr. Her bir 
//kiralama iþlemine iliþkin ise tarih ve ücret bilgisi tutulmalýdýr.