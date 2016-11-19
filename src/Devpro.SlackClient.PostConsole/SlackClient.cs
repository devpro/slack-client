using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Devpro.SlackClient.PostConsole
{
    /// <summary>
    /// A simple class to post messages to a Slack channel.
    /// </summary>
    public class SlackClient
    {
        private readonly Uri _uri;
        private readonly Encoding _encoding = new UTF8Encoding();

        public SlackClient(string urlWithAccessToken)
        {
            _uri = new Uri(urlWithAccessToken);
        }

        //Post a message using simple strings  
        public void PostMessage(string text, string username = null, string channel = null)
        {
            var payload = new Payload()
            {
                Channel  = channel,
                Username = username,
                Text     = text
            };

            PostMessage(payload);
        }

        //Post a message using a Payload object  
        public void PostMessage(Payload payload)
        {
            var payloadJson = JsonConvert.SerializeObject(payload);

            using (var client = new WebClient())
            {
                var data = new NameValueCollection();
                data["payload"] = payloadJson;

                var response = client.UploadValues(_uri, "POST", data);

                var responseText = _encoding.GetString(response);
                //TODO: check/log the response
            }
        }
    }

    public class Payload
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
