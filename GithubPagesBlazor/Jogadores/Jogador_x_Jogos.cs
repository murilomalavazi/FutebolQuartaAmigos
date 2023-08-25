using GithubPagesBlazor.Jogos;

namespace GithubPagesBlazor.Jogadores
{
    public class Jogador_x_Jogos
    {
        public int Gols { get; set; }
        public Jogo Jogo { get; set; }
        public Jogador Jogador { get; set; }
        public Time Time { get; set; }
    }

    public class Jogo
    {
        public DateTime Data { get; set; }
        public int Time_Vencedor { get; set; }
    }

    public class Time
    {
        public int id { get; set; }
        public string Cor { get; set; }
    }
}