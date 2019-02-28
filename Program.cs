using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApiQuiz.Models;

namespace WebApiQuiz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        // public static IWebHost Migrate(this IWebHost webhost)
        // {
        //     using (var scope = webhost.Services.GetService<IServiceScopeFactory>().CreateScope())
        //     {
        //         using (var dbContext = scope.ServiceProvider.GetRequiredService<DBContext>()) 
        //         {
        //             dbContext.Database.Migrate();
        //         }
        //     }
        //     return webhost;
        // }
    }
}
