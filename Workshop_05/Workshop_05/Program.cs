namespace Workshop_05
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // 🔽 Itt állítjuk be, hogy az InvoiceController legyen a kezdőpont
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Invoice}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
