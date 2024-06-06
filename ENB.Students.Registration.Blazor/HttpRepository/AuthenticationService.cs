using ENB.Students.Registration.Blazor.AuthProviders;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using ENB.Students.Registration.Blazor.DTO.AppUser;
using System.Net.Http.Json;

namespace ENB.Students.Registration.Blazor.HttpRepository
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthenticationService(HttpClient client, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
        }

        public async Task<RegistrationResponse> RegisterUser(UserRegistrationModel userRegistrationModel)
        {
            var content = JsonSerializer.Serialize(userRegistrationModel);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var registrationResult = await _client.PostAsJsonAsync("Auth/Register", userRegistrationModel);
            var registrationContent = await registrationResult.Content.ReadAsStringAsync();

            if (!registrationResult.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<RegistrationResponse>(registrationContent, _options);
                return result!;
            }

            return new RegistrationResponse { IsSuccessfulRegistration = true };
        }

        public async Task<AuthenticatedResponse> Login(UserLoginModel userLoginModel)
        {
            var content = JsonSerializer.Serialize(userLoginModel);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var authResult = await _client.PostAsync("auth/login", bodyContent);
            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<AuthenticatedResponse>(authContent, _options);

            if (!authResult.IsSuccessStatusCode)
                return result!;

            await _localStorage.SetItemAsync("authToken", result.Token);
            ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(userLoginModel.Email!);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);

            return new AuthenticatedResponse { IsAuthSuccessful = true };
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
            _client.DefaultRequestHeaders.Authorization = null;
        }
    }
}
