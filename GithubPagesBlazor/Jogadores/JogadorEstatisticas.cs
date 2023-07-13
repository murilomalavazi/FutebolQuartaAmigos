using GithubPagesBlazor.Jogos;

namespace GithubPagesBlazor.Jogadores
{
    public class JogadorEstatisticas
    {
        public string Nome { get; set; }
        public int Jogos { get; set; }
        public int Pontos { get; set; }
        public int Vitorias { get; set; }
        public int Derrotas { get; set; }
        public int Empates { get; set; }
        public int Gols { get; set; }
        public float MediaGols { get; set; }
        public float MediaAproveitamento { get; set; }

        public JogadorEstatisticas()
        {
            this.Nome = string.Empty;
            this.Jogos = 0;
            this.Pontos = 0;
            this.Vitorias = 0;
            this.Derrotas = 0;
            this.Empates = 0;
            this.Gols = 0;
            this.MediaGols = 0;
            this.MediaAproveitamento = 0;
        }
    }
}