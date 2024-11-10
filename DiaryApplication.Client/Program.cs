using DiaryApplication.Shared.Services;
using DiaryApplication.Shared.Services.Interface;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace DiaryApplication.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddScoped(http => new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
            });
            builder.Services.AddScoped<IDiaryContentService, ClientDiaryContentService>();

            await builder.Build().RunAsync();
        }
    }
}
