using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.VkApiProvider
{
    internal class VkApiProviderDataLoader
    {
        private string _apiToken;
        private string _groupUrl;
        private bool _loaded = false;

        private void LoadData()
        {
            var file = File.ReadAllLines("vk_api_data.txt");
            _apiToken = file[0];
            _groupUrl = file[1];
        }

        public string GetApiToken()
        {
            if (!_loaded)
            {
                LoadData();
            }

            return _apiToken;
        }

        public string GetGroupUrl()
        {
            if (!_loaded)
            {
                LoadData();
            }

            return _groupUrl;
        }
    }
}
