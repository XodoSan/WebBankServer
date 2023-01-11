using Microsoft.EntityFrameworkCore;
using WebBank.Context;
using WebBank.Repositories;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddTransient<BankRepository>();
        builder.Services.AddTransient<BankAccountRepository>();
        builder.Services.AddTransient<ContributorRepository>();
        builder.Services.AddTransient<RateRepository>();
        builder.Services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        IConfiguration config = GetConfig();
        string connectionString = config.GetConnectionString("BankConnectionString")!;
        builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

        var app = builder.Build();

        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Run();
    }

    private static IConfiguration GetConfig()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        return builder.Build();
    }
}