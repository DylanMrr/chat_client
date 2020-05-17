using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientChat_1.Managers;
using ClientChat_1.Messages.Responses;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClientChat_1.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthPage : ContentPage
    {
        private NetworkManager networkManager;

        public AuthPage(NetworkManager networkManager)
        {
            InitializeComponent();
            this.networkManager = networkManager;
        }

        private async void OnAuthButtonClick(object sender, EventArgs e)
        {
            //todo Проверить наличие полей

            //todo Вернуть это
            AuthResponse loginResponse = null;
            await Task.Run(async () =>
            {
                loginResponse = await networkManager.Login(
                  new Messages.AuthMessage
                  {
                      Login = loginEntry.Text,
                      Password = passwordEntry.Text
                  });
            });
            //todo если все норм
            await Navigation.PushAsync(PageManager.Pages[CommonTypes.PageTypes.Main]);
        }

        private async void OnRegisterButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(PageManager.Pages[CommonTypes.PageTypes.Register]);
        }
    }
}