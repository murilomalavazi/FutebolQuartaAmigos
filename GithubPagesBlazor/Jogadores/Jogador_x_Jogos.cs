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

    public class Jogador_x_Jogos_2023
    {
        public int Gols { get; set; }
        public Jogo_2023 Jogo_2023 { get; set; }
        public Jogador Jogador { get; set; }
        public Time Time { get; set; }
    }

    public class Jogo
    {
        public DateTime Data { get; set; }
        public int Time_Vencedor { get; set; }
    }

    public class Jogo_2023
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