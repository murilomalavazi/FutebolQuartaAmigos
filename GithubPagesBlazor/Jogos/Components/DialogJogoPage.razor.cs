﻿using GithubPagesBlazor.Jogadores;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace GithubPagesBlazor.Jogos.Components
{
    public partial class DialogJogoPage
    {
        [Inject]
        protected DialogService dialogService { get; set; }

        [Inject]
        public JogoService _jogoService { get; set; }

        [Parameter]
        public Jogo jogoData { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadDialogJogo();
        }

        public async Task LoadDialogJogo()
        {
            //formatar dados do objeto(a criar) e manda pra tela
        }
    }
}
