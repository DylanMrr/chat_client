using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.IO;
using System.Threading.Tasks;

[assembly: Dependency(typeof(ClientChat_1.Managers.FileManager))]
namespace ClientChat_1.Managers
{
    public class FileManager
    {
        public Task<bool> ExistsAsync(string fileName)
        {
            return Task<bool>.FromResult(File.Exists(GetFilePath(fileName)));
        }

        public Task DeleteAsync(string fileName)
        {
            File.Delete(GetFilePath(fileName));
            return Task.FromResult(true);
        }

        public async Task<string> LoadTextAsync(string fileName)
        {
            using (StreamReader reader = File.OpenText(GetFilePath(fileName)))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public async Task SaveTextAsync(string fileName, string text)
        {
            using (StreamWriter writer = File.CreateText(GetFilePath(fileName)))
            {
                await writer.WriteAsync(text);
            }
        }

        private string GetFilePath(string filename)
        {
            return Path.Combine(GetDocsPath(), filename);
        }

        private string GetDocsPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }
}
