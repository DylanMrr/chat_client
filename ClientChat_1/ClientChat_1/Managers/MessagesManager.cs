using System;
using System.Collections.Generic;
using System.Text;
using ClientChat_1.Models;
using System.Threading.Tasks;

namespace ClientChat_1.Managers
{
    public class MessagesManager
    {
        private FileManager fileManager;
        private Network.JsonDecoder jsonDecoder;
        private string messageFileName;

        public MessagesManager(FileManager fileManager, Network.JsonDecoder jsonDecoder)
        {
            this.jsonDecoder = jsonDecoder;
            this.fileManager = fileManager;
            messageFileName = Configs.SecureConfig.MessagesFile;
        }

        public async Task<MessagesModel> GetMessageHistory()
        {
            MessagesModel messages;
            //не первый раз заходит или не удалял историю
            if (await fileManager.ExistsAsync(messageFileName))
            {
                string hashMessageText = await fileManager.LoadTextAsync(messageFileName);
                string messageText = EncryptionService.Decrypt(hashMessageText);
                messages = jsonDecoder.Deserialize<MessagesModel>(messageText, Messages.MessagesTypes.MessagesModel);
            }
            //первый раз или удалил историю
            else
            {
                messages = new MessagesModel()
                {
                    Messages = new List<List<string>>()
                };
            }
            return messages;
        }

        public async void SaveMessageHistory()
        {

        }
    }
}
