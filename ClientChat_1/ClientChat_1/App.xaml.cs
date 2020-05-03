using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClientChat_1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var managers = new Managers.Managers();
            MainPage = new MainPage(managers.NetworkManager);
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
