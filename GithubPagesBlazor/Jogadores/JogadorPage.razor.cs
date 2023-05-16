using Microsoft.AspNetCore.Components;

namespace GithubPagesBlazor.Jogadores
{
    public partial class JogadorPage
    {
        [Inject]
        public JogadorService _jogadorService { get; set; }

        private List<Jogador> jogadores = new List<Jogador>();

        protected override async Task OnInitializedAsync()
        {
            await LoadJogadores();
            StateHasChanged();
        }

        public async Task LoadJogadores()
        {
            jogadores = (await _jogadorService.GetAll()).ToList();
        }
    }
}
