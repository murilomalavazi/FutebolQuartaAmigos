using System.ComponentModel.DataAnnotations;

namespace GithubPagesBlazor.Jogos
{
    public class Jogo
    {
        public int id { get; set; }
        public DateTime Data { get; set; }
        public int Placar_Branco { get; set; }
        public int Placar_Preto { get; set; }
        public int Time_Vencedor { get; set; }
        public string formatedData { get; set; }
    }
}