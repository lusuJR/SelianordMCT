using Blazored.LocalStorage;

namespace SelianordMCT.Web.Services;

public class AuthService
{
    private readonly ILocalStorageService _localStorage;

    public AuthService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task LoginAsync(string token)
    {
        await _localStorage.SetItemAsync("authToken", token);
    }

    public async Task LogoutAsync()
    {
        await _localStorage.RemoveItemAsync("authToken");
    }

    public async Task<bool> IsAuthenticatedAsync()
    {
        var token = await _localStorage.GetItemAsync<string>("authToken");

        return !string.IsNullOrEmpty(token);
    }
}