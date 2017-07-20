using InstaFame.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InstaFame.Instagram.UserUtilities
{
    public class Search
    {
        private string Query { get; set; }
        public Search(string query)
        {
            Query = query;
        }

        public List<string> GetResults(string proxy = "")
        {
            if (!Helpers.Initialized || !Cookies.Authenticated) return null;

            List<string> results = new List<string>();

            HttpWebRequest request = WebRequest.Create($"https://www.instagram.com/web/search/topsearch/?context=blended&query={Query}&rank_token=0.19220890817980907") as HttpWebRequest;
            if (proxy != string.Empty)
            {
                request.SetRequestProxy(proxy);
            }
            request.Method = "GET";
            request.Host = "www.instagram.com";
            request.KeepAlive = true;
            request.Accept = "*/*";
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36";
            request.Referer = "https://www.instagram.com/explore/people/";
            request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
            request.Headers.Add("Cookie", $"mid=WVQlEwALAAHqb7X4T62PaIWpf6tO; sessionid={Cookies.SessionId}; ig_vw=1440; ig_pr=1; rur={Cookies.Rur}; csrftoken={Cookies.Csrf}; ds_user_id={Cookies.DsUserId}");

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string result = response.GetResponseString();

            dynamic json = JsonConvert.DeserializeObject(result);
            for (int i = 0; i < json.users.Count; i++)
            {
                results.Add(json.users[i].user.username.ToString());
            }

            return results;
        }
    }
}
