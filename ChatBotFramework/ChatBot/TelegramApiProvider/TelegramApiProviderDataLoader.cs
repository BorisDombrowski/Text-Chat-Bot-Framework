using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.TelegramApiProvider
{
    internal class TelegramApiProviderDataLoader
    {
        private string _apiToken;
        private bool _loaded = false;

        private void LoadData()
        {
            var file = File.ReadAllLines("tg_api_data.txt");
            _apiToken = file[0];
        }

        public string GetApiToken()
        {
            if (!_loaded)
            {
                LoadData();
            }

            return _apiToken;
        }
    }
}
