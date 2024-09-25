using dataaccess;
using Microsoft.EntityFrameworkCore;

namespace Api;

public class Program
{
    public static void Main(string[] args)
    {
        
        //copy paste from older project might need to change some things so it imports db
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<DmContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("DbConn"));
        });
        
        builder.Services.AddControllers();
        
        var app = builder.Build();

        using (var serviceScope = app.Services.CreateScope())
        {
            serviceScope.ServiceProvider.GetService<DmContext>()
                .Database.EnsureCreated();
        }
        
        app.MapControllers();
        app.Run();       
    }
}