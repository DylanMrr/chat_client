using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientChat_1.Managers;
using ClientChat_1.Models;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClientChat_1.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private NetworkManager networkManager;
        private MessagesManager messagesManager;

        public ObservableCollection<MessageView> MessagesObjects { get; set; }

        public MainPage(NetworkManager networkManager, MessagesManager messagesManager)
        {
            InitializeComponent();
            Application.Current.MainPage = this;
            NavigationPage.SetHasBackButton(this, false);

            this.messagesManager = messagesManager;
            this.networkManager = networkManager;

            GetMessageHistory();
        }

        private async void GetMessageHistory()
        {
            MessagesModel messages = await messagesManager.GetMessageHistory();
            MessagesObjects = new ObservableCollection<MessageView>();
            if (messages.Messages.Count == 0)
            {
                emptyHistory.IsEnabled = true;
                //todo убрать это, это для тестов
                for (int i = 0; i < 2; i++)
                {
                    MessagesObjects.Add(
                        new MessageView()
                        {
                            UserName = "ffff",
                            LastMessage = "HI"
                        }
                    );
                }
                messagesList.ItemsSource = MessagesObjects;
                //BindingContext = this;
            }
            else
            {
                foreach(var user in messages.Messages)
                {
                    MessagesObjects.Add(
                        new MessageView() 
                        { 
                            UserName = user[0], 
                            LastMessage = user.Last() 
                        }
                    );
                }
                BindingContext = this;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}