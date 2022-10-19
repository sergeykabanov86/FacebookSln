using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMySDKCore.Data
{
    public interface IFacebookClient
    {
        Task<T> GetAsync<T>(string accessToken, string endpoint, string args = null);
        Task PostAsync(string accessToken, string endpoint, object data, string args = null);
    }

    public class FacebookClient : IFacebookClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;
        private readonly System.Threading.CancellationTokenSource _cts;

        public FacebookClient(int timeoutSec)
        {
            var handler = new System.Net.Http.HttpClientHandler();
            handler.MaxConnectionsPerServer = 1;

            _httpClient = new System.Net.Http.HttpClient()
            {
                //BaseAddress = new Uri("https://graph.facebook.com/"),
                     
            };

            //_httpClient.DefaultRequestHeaders.ConnectionClose = true;

            //_httpClient.DefaultRequestHeaders
            //            .Accept
            //            .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //_httpClient.Timeout = TimeSpan.FromSeconds(timeoutSec);

            _cts = new System.Threading.CancellationTokenSource();
        }

        public async Task<T> GetAsync<T>(string accessToken, string endpoint, string args = null)
        {
            string result = string.Empty;
            try
            {
                //var response = await _httpClient.GetAsync($"{endpoint}?access_token={accessToken}&{args}", _cts.Token);
                var response = await _httpClient.GetAsync($"https://www.google.ru/", HttpCompletionOption.ResponseHeadersRead,_cts.Token);
                if (!response.IsSuccessStatusCode)
                    return default(T);

                result = await response.Content.ReadAsStringAsync();
            }
            catch (WebException ex)
            {
                // handle web exception
            }
            catch (TaskCanceledException ex)
            {
                if (ex.CancellationToken == _cts.Token)
                {
                    // a real cancellation, triggered by the caller
                }
                else
                {
                    // a web request timeout (possibly other things!?)
                }
            }

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(result);

        }


        public async Task PostAsync(string accessToken, string endpoint, object data, string args = null)
        {
            var payload = GetPayloadData(data);
            await _httpClient.PostAsync($"{endpoint}?access_token={accessToken}&{args}", payload);
        }

        private System.Net.Http.StringContent GetPayloadData(object data)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
