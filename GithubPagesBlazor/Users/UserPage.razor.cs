using Microsoft.AspNetCore.Components;

namespace GithubPagesBlazor.Users
{
    public partial class UserPage
    {
        [Inject]
        public UserService _userService { get; set; }

        private List<User> users = new List<User>();

        protected override async Task OnInitializedAsync()
        {
            await LoadUsers();
            StateHasChanged();
        }

        public async Task LoadUsers()
        {
            users = (await _userService.GetAll()).ToList();
        }
    }
}
