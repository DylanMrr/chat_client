using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClientChat_1.Managers;
using ClientChat_1.Messages;
using ClientChat_1.Messages.Responses;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClientChat_1.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        private NetworkManager networkManager;

        public RegisterPage(NetworkManager networkManager)
        {
            InitializeComponent();
            this.networkManager = networkManager;
        }

        private async void OnRegisterButtonClick(object sender, EventArgs e)
        {
            if (passwordEntry.Text != repeatPassword.Text)
            {
                errorLabel.Text = "Пароли не совпадают";
                errorLabel.IsEnabled = true;
            }
            //todo Проверить наличие полей
            RegisterResponse registerResponse = null;
            await Task.Run(async () =>
            {
                registerResponse = await networkManager.Register(
                  new RegisterMessage
                  {
                      Login = loginEntry.Text,
                      Password = passwordEntry.Text
                  });
            });

            await Navigation.PopAsync();
        }
    }
} 