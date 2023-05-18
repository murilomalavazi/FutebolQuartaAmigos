using Microsoft.AspNetCore.Components;

namespace GithubPagesBlazor.Jogos
{
    public partial class JogoPage
    {
        [Inject]
        public JogoService _jogoService { get; set; }

        private List<Jogo> jogos = new List<Jogo>();

        protected override async Task OnInitializedAsync()
        {
            await LoadJogos();
            StateHasChanged();
        }

        public async Task LoadJogos()
        {
            jogos = (await _jogoService.GetAll()).ToList();

            foreach (var jogo in jogos)
            {
                jogo.formatedData = jogo.Data.ToString("dd/MM/yy");
            }
        }
    }
}