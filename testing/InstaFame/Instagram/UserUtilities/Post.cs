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
    public class Post
    {
        private string PhotoUrl { get; set; }
        public Post(string photoUrl)
        {
            PhotoUrl = photoUrl;
        }

        public bool Like(string proxy = "")
        {
            if (!Helpers.Initialized || !Cookies.Authenticated) return false;

            string photoId = Helpers.GetPhotoId(PhotoUrl, proxy);
            HttpWebRequest request = WebRequest.Create($"https://www.instagram.com/web/likes/{photoId}/like/") as HttpWebRequest;
            if (proxy != string.Empty)
            {
                request.SetRequestProxy(proxy);
            }
            request.Method = "POST";
            request.Host = "www.instagram.com";
            request.KeepAlive = true;
            request.ContentLength = 0;
            request.Headers.Add("Origin", "https://www.instagram.com");
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            request.Headers.Add("X-Instagram-AJAX", "1");
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36";
            request.Headers.Add("X-CSRFToken", Cookies.Csrf);
            request.Referer = PhotoUrl;
            request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
            request.Headers.Add($"Cookie: mid=WVQlEwALAAHqb7X4T62PaIWpf6tO; sessionid={Cookies.SessionId}; ig_vw=1440; ig_pr=1; csrftoken={Cookies.Csrf}; rur={Cookies.Rur}; ds_user_id={Cookies.DsUserId}");

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string responseString = response.GetResponseString();
            return responseString.Contains("{\"status\": \"ok\"}");
        }

        public bool Comment(string comment, string proxy = "")
        {
            if (!Helpers.Initialized || !Cookies.Authenticated) return false;

            string post = $"comment_text={UrlEncode(comment)}";
            string photoId = Helpers.GetPhotoId(PhotoUrl, proxy);
            HttpWebRequest request = WebRequest.Create($"https://www.instagram.com/web/comments/{photoId}/add/") as HttpWebRequest;
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
            request.Referer = PhotoUrl;
            request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
            request.Headers.Add($"Cookie: mid=WVQlEwALAAHqb7X4T62PaIWpf6tO; sessionid={Cookies.SessionId}; ig_vw=1440; ig_pr=1; csrftoken={Cookies.Csrf}; rur={Cookies.Rur}; ds_user_id={Cookies.DsUserId}");

            byte[] data = Encoding.ASCII.GetBytes(post);
            request.ContentLength = data.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Close();
            }

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string responseString = response.GetResponseString();
            return responseString.Contains("{\"status\": \"ok\"}");
        }
    }
}
