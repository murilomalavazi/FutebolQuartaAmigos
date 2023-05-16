using System.Net.Http.Json;

namespace GithubPagesBlazor.Users
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("apikey", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImtrcnNvaXJ2d2FsanRyYXZlYWV6Iiwicm9sZSI6ImFub24iLCJpYXQiOjE2ODQxNzA0MjksImV4cCI6MTk5OTc0NjQyOX0.WTDFwJkcz3tTPtoj1fWjgPlAeizOh5b5npxkQqpRmoE");
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImtrcnNvaXJ2d2FsanRyYXZlYWV6Iiwicm9sZSI6ImFub24iLCJpYXQiOjE2ODQxNzA0MjksImV4cCI6MTk5OTc0NjQyOX0.WTDFwJkcz3tTPtoj1fWjgPlAeizOh5b5npxkQqpRmoE");
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<User>>($"users?select=*");
        }
    }
}
