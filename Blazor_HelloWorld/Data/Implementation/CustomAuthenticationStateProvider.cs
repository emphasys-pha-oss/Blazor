using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blazor_HelloWorld.Data.Implementation
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ISessionStorageService _sessionStorage;
        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        /// <summary>
        /// This fuction gets loaded when the app starts to authenticate requests.
        /// </summary>
        /// <returns></returns>
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            var userEmail = await _sessionStorage.GetItemAsync<string>("emailAddress");
            if (!string.IsNullOrWhiteSpace(userEmail))
            {
                identity = new ClaimsIdentity(new[]{
                new Claim(ClaimTypes.Name, userEmail)
                }, "apiauth_type");
            }

            var user = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(user));
        }

        public void MarkUserAsAuthenticated(string userEmail)
        {
            var isValiduser = RetrieveUser();
            if (isValiduser)
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userEmail)
                }, "apiauth_type");

                var user = new ClaimsPrincipal(identity);
                NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
            }
        }

        public void LogoutUser()
        {
            _sessionStorage.RemoveItemAsync("emailAddress");

            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));            
        }

        private bool RetrieveUser()
        {
            return true;
        }
    }
}
