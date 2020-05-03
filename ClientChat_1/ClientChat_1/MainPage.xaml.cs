using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ClientChat_1.Managers;

namespace ClientChat_1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private NetworkManager networkManager;

        public MainPage(NetworkManager networkManager)
        {
            InitializeComponent();
            this.networkManager = networkManager;
        }

        private void OnEnterButtonClick(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                networkManager.Authorize(
                  new Messages.AuthorizeMessage
                  {
                      Login = loginEntry.Text,
                      Password = passwordEntry.Text
                  });
            });
        }
    }
}
