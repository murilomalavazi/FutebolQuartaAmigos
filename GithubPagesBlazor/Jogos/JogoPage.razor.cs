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

        private List<Jogo> jogos = new List<Jogo>();

        protected override async Task OnInitializedAsync()
        {
            await LoadJogos();
            StateHasChanged();
        }

        public async Task LoadJogos()
        {
            jogos = (await _jogoService.GetAllGames()).ToList();

            foreach (var jogo in jogos)
            {
                jogo.formatedData = jogo.Data.ToString("dd/MM/yy");
                jogo.formatedTime_Vencedor = CorDoTime(jogo.Time_Vencedor);
            }
        }

        async Task OpenDialogJogoPage(int orderId)
        {
            await _dialogService.OpenAsync<DialogJogoPage>($"DialogJogo ",
                  new Dictionary<string, object>() { { "DataId", orderId } },
                  new DialogOptions() { Width = "100px", Height = "100px" });
        }

        public string CorDoTime(int cor)
        {
            switch (cor)
            {
                case 1:
                    return "Branco";
                case 2:
                    return "Preto";
                case 3:
                    return "Empate";
                default:
                    return "Indefinido";
            }
        }
    }
}