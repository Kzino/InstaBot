using System.IO;
using System.Net;
using System.Linq;

namespace InstaFame.Extensions
{
    public static class WebExtension
    {
        public static string GetCookie(this HttpWebResponse response, string key)
        {
            string value = response.Headers.GetValues("Set-Cookie").First(x => x.StartsWith(key));
            return value.Split(';')[0].Replace($"{key}=", string.Empty);
        }

        public static string GetHeader(this HttpWebResponse response, string key)
        {
            return response.Headers[key];
        }

        public static string GetResponseString(this HttpWebResponse response)
        {
            string responseString = string.Empty;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                responseString = reader.ReadToEnd();
            }
            return responseString;
        }

        public static void SetClientProxy(this WebClient client, string proxy)
        {
            WebProxy prox = new WebProxy(proxy.Split(':')[0], int.Parse(proxy.Split(':')[1]));
            prox.BypassProxyOnLocal = true;
            client.Proxy = prox;
        }

        public static void SetRequestProxy(this HttpWebRequest request, string proxy)
        {
            WebProxy prox = new WebProxy(proxy.Split(':')[0], int.Parse(proxy.Split(':')[1]));
            prox.BypassProxyOnLocal = true;
            request.Proxy = prox;
        }
    }
}
