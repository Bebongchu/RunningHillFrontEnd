using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd
{
    public interface ImyHttpClient
    {
        HttpClient gethttpclient();
    }

    /// <summary>
    /// Generates aan http client
    /// </summary>
    class MyHttpClient : ImyHttpClient
    {
        HttpClient client;

        public MyHttpClient()
        {

            client = new HttpClient();
        }
        public HttpClient gethttpclient()
        {
            return client;
        }
    }
    public class Program
    {
       
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
