﻿using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using GithubPagesBlazor.Jogadores;
using GithubPagesBlazor.Jogos;

namespace GithubPagesBlazor.Startup
{
    public static class HttpDependencies
    {
        public static void RegisterHttpServices(this WebAssemblyHostBuilder builder)
        {
            var dbApi = builder.Configuration.GetSection("DbUrl").Value;
            var apiKey = builder.Configuration.GetSection("ApiKey").Value;

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient("HttpMessageHandlers", client => { client.BaseAddress = new Uri(dbApi); });

            builder.Services.AddHttpClient<JogadorService>("HttpMessageHandlers");
            builder.Services.AddHttpClient<JogoService>("HttpMessageHandlers");
        }
    }
}
