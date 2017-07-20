using System.IO;
using System.Net;
using System.Drawing;
using InstaFame.Extensions;
using System.Text.RegularExpressions;
using System.Text;
using Newtonsoft.Json;

namespace InstaFame.Instagram
{
    public class Helpers
    {
        public static bool Initialized { get; set; } = false;
        public static void Init(string proxy = "")
        {
            HttpWebRequest request = WebRequest.Create("https://www.instagram.com/") as HttpWebRequest;
            if (proxy != string.Empty)
            {
                request.SetRequestProxy(proxy);
            }
            request.Method = "GET";
            request.Host = "www.instagram.com";
            request.KeepAlive = true;

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Cookies.Rur = response.GetCookie("rur");
            Cookies.Csrf = response.GetCookie("csrftoken");
            Initialized = true;
        }

        public static bool FollowsCurrent(string username, string proxy = "")
        {
            if (!Initialized || !Cookies.Authenticated) return false;

            HttpWebRequest request = WebRequest.Create($"https://www.instagram.com/{username}/") as HttpWebRequest;
            if (proxy != string.Empty)
            {
                request.SetRequestProxy(proxy);
            }
            request.Method = "GET";
            request.Host = "www.instagram.com";
            request.KeepAlive = true;
            request.Headers.Add("Cache-Control", "max-age=0");
            request.Headers.Add("Upgrade-Insecure-Requests", "1");
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            request.Referer = "https://www.instagram.com/";
            request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
            request.Headers.Add($"Cookie: mid=WVQlEwALAAHqb7X4T62PaIWpf6tO; sessionid={Cookies.SessionId}; rur={Cookies.Rur}; csrftoken={Cookies.Csrf}; ds_user_id={Cookies.DsUserId}; ig_pr=1; ig_vw=1440");
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string responseString = string.Empty;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                responseString = reader.ReadToEnd();
            }
            return responseString.Contains("\"follows_viewer\": true");
        }

        public static string GetUserId(string username, string proxy = "")
        {
            string id = string.Empty;
            using (WebClient client = new WebClient())
            {
                if (proxy !=string.Empty)
                {
                    client.SetClientProxy(proxy);
                }
                string input = client.DownloadString($"https://www.instagram.com/{username}/");
                string pattern = "\"id\": \"(.*?)\"";
                id = Regex.Matches(input, pattern)[0].Groups[1].Value;
            }
            return id;
        }

        public static Image GetProfilePicture(string username, string proxy = "")
        {
            Image img = null;
            using (WebClient client = new WebClient())
            {
                if (proxy != string.Empty)
                {
                    client.SetClientProxy(proxy);
                }
                string input = client.DownloadString($"https://www.instagram.com/{username}/");
                string pattern = "\"profile_pic_url_hd\": \"(.*?)\"";
                byte[] data = client.DownloadData(Regex.Matches(input, pattern)[0].Groups[1].Value);
                using (MemoryStream stream = new MemoryStream(data))
                {
                    img = Image.FromStream(stream);
                }
            }

            return img;
        }

        public static string GetPhotoId(string photoUrl, string proxy = "")
        {
            string id = string.Empty;
            using (WebClient client = new WebClient())
            {
                if (proxy != string.Empty)
                {
                    client.SetClientProxy(proxy);
                }
                string input = client.DownloadString(photoUrl);
                string pattern = "\"id\": \"(.*?)\"";
                foreach (Match item in (new Regex(pattern).Matches(input)))
                {
                    string _id = item.Groups[1].Value;
                    if (_id.Length == 19)
                    {
                        id = _id;
                        break;
                    }
                }
            }
            return id;
        }

        public static int GetFollowers(string username, string proxy = "")
        {
            int count = 0;
            using (WebClient client = new WebClient())
            {
                if (proxy != string.Empty)
                {
                    client.SetClientProxy(proxy);
                }
                string input = client.DownloadString($"https://www.instagram.com/{username}/");
                string pattern = "\"followed_by\": {\"count\": (.*?)}";
                count = int.Parse(Regex.Matches(input, pattern)[0].Groups[1].Value);
            }
            return count;
        }

        public static int GetPostCount(string username, string proxy = "")
        {
            int count = 0;
            using (WebClient client = new WebClient())
            {
                if (proxy != string.Empty)
                {
                    client.SetClientProxy(proxy);
                }
                string input = client.DownloadString($"https://www.instagram.com/{username}/");
                string pattern = "\"display_src\": \"(.*?)\"";
                count = Regex.Matches(input, pattern).Count;
            }
            return count;
        }
    }
}