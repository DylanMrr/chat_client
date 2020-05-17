using System;
using System.Collections.Generic;
using System.Text;
using ClientChat_1.CommonTypes;
using ClientChat_1.Managers;
using ClientChat_1.Pages;

namespace ClientChat_1.Managers
{
    public class PageManager
    {
        public static Dictionary<PageTypes, Xamarin.Forms.ContentPage> Pages { get; private set; }

        public static void Configure(Managers managers)
        {
            Pages = new Dictionary<PageTypes, Xamarin.Forms.ContentPage>()
            {
                [PageTypes.Auth] = new AuthPage(managers.NetworkManager),
                [PageTypes.Register] = new RegisterPage(managers.NetworkManager),
                [PageTypes.Main] = new MainPage(managers.NetworkManager, managers.MessagesManager)
            };
        }
    }
}
