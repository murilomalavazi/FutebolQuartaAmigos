using GithubPagesBlazor.Jogos;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace GithubPagesBlazor.Jogadores.Components
{
    public partial class DialogJogadorPage
    {
        [Inject]
        protected DialogService dialogService { get; set; }

        [Inject]
        public JogoService _jogadorService { get; set; }

        [Parameter]
        public JogadorEstatisticas jogadorEstatistica { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadDialogJogador();
        }

        public async Task LoadDialogJogador()
        {
            //mostrar dados ja formatados na tela
        }
    }
}
