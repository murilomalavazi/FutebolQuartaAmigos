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

        public async Task<List<JogadorEstatisticas>> GetAllPlayers()
        {
            List<JogadorEstatisticas> listaJogadorEstatistica = new List<JogadorEstatisticas>();

            IEnumerable<Jogador> Jogadores = await _httpClient.GetFromJsonAsync<IEnumerable<Jogador>>($"Jogador?select=*"); //get all players

            foreach (Jogador jogador in Jogadores) //for each player
            {
                IEnumerable<Jogador_x_Jogos> jogador_x_jogos = await _httpClient.GetFromJsonAsync<IEnumerable<Jogador_x_Jogos>>($"Jogo_x_Jogador?id_Jogador=eq.{jogador.id}&select=Gols,Jogo(Data,Time_Vencedor),Jogador(Nome),Time(id)"); //get all infos about player and game

                JogadorEstatisticas jogadorEstatistica = new JogadorEstatisticas();
                jogadorEstatistica.Nome = jogador.Nome;

                foreach (Jogador_x_Jogos allInfos in jogador_x_jogos) //for each game/player
                {
                    jogadorEstatistica.Gols += allInfos.Gols;
                    jogadorEstatistica.Jogos++;
                    jogadorEstatistica.Vitorias += (allInfos.Jogo.Time_Vencedor == allInfos.Time.id ? 1 : 0);
                    jogadorEstatistica.Derrotas += (allInfos.Jogo.Time_Vencedor != allInfos.Time.id && allInfos.Jogo.Time_Vencedor != 3 ? 1 : 0);
                    jogadorEstatistica.Empates += (allInfos.Jogo.Time_Vencedor != allInfos.Time.id && allInfos.Jogo.Time_Vencedor == 3 ? 1 : 0);
                }

                jogadorEstatistica.Pontos = (jogadorEstatistica.Vitorias * 3) + (jogadorEstatistica.Empates * 1);
                jogadorEstatistica.MediaGols = jogadorEstatistica.Gols == 0 ? 0 : (float)jogadorEstatistica.Gols / jogadorEstatistica.Jogos;
                jogadorEstatistica.MediaAproveitamento = jogadorEstatistica.Pontos == 0 ? 0 : ((float)jogadorEstatistica.Pontos / (jogadorEstatistica.Jogos * 3)) * 100;

                listaJogadorEstatistica.Add(jogadorEstatistica);
            }

            return listaJogadorEstatistica;
        }
    }
}

