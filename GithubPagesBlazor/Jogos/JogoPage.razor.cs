using GithubPagesBlazor.Jogos.Components;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using System.ComponentModel;

namespace GithubPagesBlazor.Jogos
{
    public partial class JogoPage
    {
        [Inject]
        public JogoService _jogoService { get; set; }
        [Inject]
        public DialogService _dialogService { get; set; }

        bool isLoading = false;
        private List<Jogo> jogos = new List<Jogo>();

        protected override async Task OnInitializedAsync()
        {
            await LoadJogos();
            StateHasChanged();
        }

        async Task ShowLoading()
        {
            isLoading = true;

            await Task.Yield();

            isLoading = false;
        }

        public async Task LoadJogos()
        {
            await ShowLoading();
            jogos = (await _jogoService.GetAllGames()).ToList();

            foreach (var jogo in jogos)
            {
                jogo.formatedData = jogo.Data.ToString("dd/MM/yy");
                jogo.formatedTime_Vencedor = CorDoTime(jogo.Time_Vencedor);
            }
        }

        async Task OpenDialogJogoPage(Jogo jogoData)
        {
            await _dialogService.OpenAsync<DialogJogoPage>($"Detalhes do jogo",
                  new Dictionary<string, object>() { { "jogoData", jogoData } },
                  new DialogOptions() { Width = "100%", Height = "100%" });
        }

        public string CorDoTime(int cor)
        {
            switch (cor)
            {
                case 1:
                    return "Branco";
                case 3:
                    return "Empate";
                case 2:
                    return "Azul";
                default:
                    return "Indefinido";
            }
        }
    }
}