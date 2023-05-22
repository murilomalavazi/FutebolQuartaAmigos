using GithubPagesBlazor;
using GithubPagesBlazor.Startup;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

internal class Program
{
    private static async Task Main(string[] args)
    {
        try
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped<DialogService>();

            builder.RegisterHttpServices();

            await builder.Build().RunAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERRO] Erro inesperado ao inicializar a aplicação! / {ex.Message}");
        }
    }
}