using Microsoft.AspNetCore.Components;
using Radzen;
using TechnicalProofWork.Models;
using TechnicalProofWork.Services;

namespace TechnicalProofWork.Pages
{
    public partial class LoginPage
    {
        [Inject]
        private UserLogInService UserLogInService { get; set; }
        [Inject]
        private NotificationService NotificationService { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        private string username;
        private string password;
        private bool rememberMe;


        private void HandleLogin()
        {
            UserModel user = LoginService.Login(username, password);
            if (user != null)
            {
                UserLogInService.userLogged = user;
                NotificationService?.Notify(NotificationSeverity.Success, "Success", "Welcome " + user.Person.FullName);
                NavigationManager.NavigateTo("/app/dashboard");
            }
            else
            {
                NotificationService.Notify(NotificationSeverity.Error, "Error", "Invalid credentials");
            }
        }
    }
}