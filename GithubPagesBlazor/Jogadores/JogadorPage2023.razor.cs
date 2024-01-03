using GithubPagesBlazor.Jogadores.Components;
using GithubPagesBlazor.Jogos.Components;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace GithubPagesBlazor.Jogadores
{
    public partial class JogadorPage2023
    {
        [Inject]
        public JogadorService _jogadorService { get; set; }
        [Inject]
        public DialogService _dialogService { get; set; }

        bool isLoading = false;
        private List<JogadorEstatisticas> jogadores = new List<JogadorEstatisticas>();

        protected override async Task OnInitializedAsync()
        {
            await LoadJogadores();
            StateHasChanged();
        }

        async Task ShowLoading()
        {
            isLoading = true;

            await Task.Yield();

            isLoading = false;
        }

        public async Task LoadJogadores()
        {
            await ShowLoading();
            jogadores = (await _jogadorService.GetAllPlayers2023()).ToList();
        }

        async Task OpenDialogJogadorPage(JogadorEstatisticas estatistica)
        {
            await _dialogService.OpenAsync<DialogJogadorPage>($"Detalhes do jogador",
                  new Dictionary<string, object>() { { "jogadorEstatistica", estatistica } },
                  new DialogOptions() { Width = "100%", Height = "100%" });
        }
    }
}
