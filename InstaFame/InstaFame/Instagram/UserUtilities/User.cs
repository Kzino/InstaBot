using InstaFame.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstaFame.Instagram.UserUtilities
{
    public class User
    {
        private string Username { get; set; }
        public User(string username)
        {
            Username = username;
        }

        public bool Follow(string proxy = "")
        {
            if (!Helpers.Initialized || !Cookies.Authenticated) return false;

            string post = string.Empty;
            string userId = Helpers.GetUserId(Username, proxy);
            HttpWebRequest request = WebRequest.Create($"https://www.instagram.com/web/friendships/{userId}/follow/") as HttpWebRequest;
            if (proxy != string.Empty)
            {
                request.SetRequestProxy(proxy);
            }
            request.Method = "POST";
            request.Host = "www.instagram.com";
            request.KeepAlive = true;
            request.ContentLength = 0;
            request.Headers.Add("Origin", "https://www.instagram.com");
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36";
            request.Headers.Add("X-CSRFToken", Cookies.Csrf);
            request.Referer = $"https://www.instagram.com/{Username}/";
            request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
            request.Headers.Add("Cookie", $"mid=WVQlEwALAAHqb7X4T62PaIWpf6tO; sessionid={Cookies.SessionId}; ig_vw=1440; ig_pr=1; csrftoken={Cookies.Csrf}; rur={Cookies.Rur}; ds_user_id={Cookies.DsUserId}");

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string responseString = response.GetResponseString();

            if (responseString.Contains("following") || responseString.Contains("requested"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Unfollow(string proxy = "")
        {
            if (!Helpers.Initialized || !Cookies.Authenticated) return false;

            string userId = Helpers.GetUserId(Username, proxy);
            HttpWebRequest request = WebRequest.Create($"https://www.instagram.com/web/friendships/{userId}/unfollow/") as HttpWebRequest;
            if (proxy != string.Empty)
            {
                request.SetRequestProxy(proxy);
            }
            request.Method = "POST";
            request.Host = "www.instagram.com";
            request.KeepAlive = true;
            request.ContentLength = 0;
            request.Headers.Add("Origin", "https://www.instagram.com");
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36";
            request.Headers.Add("X-CSRFToken", Cookies.Csrf);
            request.Referer = $"https://www.instagram.com/{Username}/";
            request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
            request.Headers.Add("Cookie", $"mid=WVQlEwALAAHqb7X4T62PaIWpf6tO; sessionid={Cookies.SessionId}; ig_vw=1440; ig_pr=1; csrftoken={Cookies.Csrf}; rur={Cookies.Rur}; ds_user_id={Cookies.DsUserId}");

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string responseString = response.GetResponseString();
            return responseString.Contains("{\"status\": \"ok\"}");
        }

        public List<string> GetRecentPosts(int count = 3, string proxy = "")
        {
            int c = Helpers.GetPostCount(Username);
            if (count > c)
            {
                count = c;
            }

            List<string> posts = new List<string>();

            if (!Helpers.Initialized || !Cookies.Authenticated) return null;

            HttpWebRequest request = WebRequest.Create($"https://www.instagram.com/{Username}/") as HttpWebRequest;
            if (proxy != string.Empty)
            {
                request.SetRequestProxy(proxy);
            }
            request.Method = "GET";
            request.KeepAlive = true;
            request.Headers.Add("Upgrade-Insecure-Requests", "1");
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
            request.Headers.Add("Cookie", $"mid=WVQlEwALAAHqb7X4T62PaIWpf6tO; sessionid={Cookies.SessionId}; csrftoken={Cookies.Csrf}; ds_user_id={Cookies.DsUserId}; rur={Cookies.Rur}");

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string responseString = response.GetResponseString();
            string pattern = "\"code\": \"(.*?)\"";
            foreach (Match item in (new Regex(pattern).Matches(responseString)))
            {
                Console.WriteLine($"post: https://www.instagram.com/p/{item.Groups[1].Value}/");
                posts.Add($"https://www.instagram.com/p/{item.Groups[1].Value}/");
            }
            return posts;
        }
    }
}
