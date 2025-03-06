using GithubPagesBlazor.Jogadores;
using System.Net.Http.Json;

namespace GithubPagesBlazor.Jogos
{
    public class JogoService
    {
        private readonly HttpClient _httpClient;

        public JogoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("apikey", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImptYXF0Y2Jra2dmeWdxbHFic3h4Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDEyNjg1NTcsImV4cCI6MjA1Njg0NDU1N30.nx_JQrbsfjXfccGcWXLnZ0E9BEJfAh3LG_AREbCnIBU");
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImptYXF0Y2Jra2dmeWdxbHFic3h4Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDEyNjg1NTcsImV4cCI6MjA1Njg0NDU1N30.nx_JQrbsfjXfccGcWXLnZ0E9BEJfAh3LG_AREbCnIBU");
        }

        public async Task<IEnumerable<Jogo>> GetAllGames()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Jogo>>($"Jogo?select=*");
        }

        public async Task GetAllGameInfosById(int idJogo)
        {
            IEnumerable<Jogador_x_Jogos> jogador_x_jogos = await _httpClient.GetFromJsonAsync<IEnumerable<Jogador_x_Jogos>>($"Jogo_x_Jogador?id_Jogo=eq.{idJogo}&select=Gols,Jogo(Data),Jogador(Nome),Time(Cor)");
            //colocar na tela os jogadores e os gols naquele jogo
        }
    }
}