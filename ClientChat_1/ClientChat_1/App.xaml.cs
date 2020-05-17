using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ClientChat_1.Pages;

namespace ClientChat_1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var managers = new Managers.Managers();
            Managers.PageManager.Configure(managers);
            MainPage = new NavigationPage(Managers.PageManager.Pages[CommonTypes.PageTypes.Auth]);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
