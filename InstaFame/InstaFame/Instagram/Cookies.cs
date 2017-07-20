namespace InstaFame.Instagram
{
    public class Cookies
    {
        //this is not a cookie but it helps a lot.
        public static bool Authenticated { get; set; } = false;

        public static string Rur { get; set; }
        public static string Csrf { get; set; }
        public static string SessionId { get; set; }
        public static string DsUserId { get; set; }
    }
}
