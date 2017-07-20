using InstaFame.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebUtility;
namespace InstaFame.Instagram.UserUtilities
{
    public class Auth
    {
        private string Username { get; set; }
        private string Password { get; set; }

        public Auth(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public bool Authenticate(string proxy = "")
        {
            if (!Helpers.Initialized) return false;

            if (Username != string.Empty && Password != string.Empty)
            {
                string post = $"username={UrlEncode(Username)}&password={Password}";
                HttpWebRequest request = WebRequest.Create("https://www.instagram.com/accounts/login/ajax/") as HttpWebRequest;
                if (proxy != string.Empty)
                {
                    request.SetRequestProxy(proxy);
                }

                request.Method = "POST";
                request.Host = "www.instagram.com";
                request.KeepAlive = true;
                request.Headers.Add("Origin", "https://www.instagram.com");
                request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                request.Headers.Add("X-Instagram-AJAX", "1");
                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "*/*";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36";
                request.Headers.Add("X-CSRFToken", Cookies.Csrf);
                request.Referer = "https://www.instagram.com/";
                request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                request.Headers.Add("Cookie", $"mid=WVQlEwALAAHqb7X4T62PaIWpf6tO; ig_vw=1440; ig_pr=1; rur={Cookies.Rur}; csrftoken={Cookies.Csrf}");

                byte[] data = Encoding.ASCII.GetBytes(post);
                request.ContentLength = data.Length;
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                    stream.Close();
                }

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                string responseString = response.GetResponseString();
                if (responseString.Contains("\"authenticated\": true"))
                {
                    Cookies.SessionId = response.GetCookie("sessionid");
                    Cookies.DsUserId = Helpers.GetUserId(Username, proxy);
                    Cookies.Authenticated = true;
                    return true;
                }
                else
                {
                    Cookies.Authenticated = false;
                    return false;
                }
            }
            else return false;
        }
    }
}
