using System.Net.Http.Json;

namespace GithubPagesBlazor.Jogadores
{
    public class JogadorService
    {
        private readonly HttpClient _httpClient;

        public JogadorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("apikey", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Inh5cXZsZ3l1bWpnZHhueHR3a29vIiwicm9sZSI6ImFub24iLCJpYXQiOjE2ODQyNDcwNTYsImV4cCI6MTk5OTgyMzA1Nn0.kCeg3YQJnQBxCYGr3YIZDGJ1g0jwOJm9LIw9GwP48YI");
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Inh5cXZsZ3l1bWpnZHhueHR3a29vIiwicm9sZSI6ImFub24iLCJpYXQiOjE2ODQyNDcwNTYsImV4cCI6MTk5OTgyMzA1Nn0.kCeg3YQJnQBxCYGr3YIZDGJ1g0jwOJm9LIw9GwP48YI");
        }

        public async Task<IEnumerable<Jogador>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Jogador>>($"Jogadores?select=*");
        }
    }
}
