using GithubPagesBlazor;
using GithubPagesBlazor.Startup;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

internal class Program
{
    private static async Task Main(string[] args)
    {
        try
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.RegisterHttpServices();

            await builder.Build().RunAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERRO] Erro inesperado ao inicializar a aplica��o! / {ex.Message}");
        }
    }
}