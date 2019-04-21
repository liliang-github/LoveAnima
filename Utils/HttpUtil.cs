using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Headers;

namespace LoveAnim.Utils
{
    public class HttpUtil
    {
        //private static HttpClient httpClient = new HttpClient();
        //static HttpUtil()
        //{
        //    httpClient.DefaultRequestHeaders.Accept.ParseAdd("text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
        //    httpClient.DefaultRequestHeaders.AcceptEncoding.ParseAdd("gzip, deflate, br");
        //    httpClient.DefaultRequestHeaders.AcceptLanguage.ParseAdd("zh-Hans-CN,zh-Hans;q=0.5");
        //    //httpClient.DefaultRequestHeaders.Cookie.ParseAdd("__cfduid=da23badc3e204c443c5184a43c79badf61552618005; user_script_url=%2F%2Fcdn.acgscript.com%2Fscript%2Fmiobt%2F4.js%3F3; user_script_rev=20181120.2; cf_clearance=c239ddeb98f40eed2759688f2229ef43790ca928-1552736732-1800-150; Hm_lvt_bab0ae65b49b7efd4fde9bf6858ec60b=1552661934,1552667118,1552730529,1552736735; Hm_lpvt_bab0ae65b49b7efd4fde9bf6858ec60b=1552736952");
        //    //httpClient.DefaultRequestHeaders.Cookie.Add(new HttpCookiePairHeaderValue("__cfduid", "d8fbd02b8b8977496360fb0bf5c64120b1552633926"));
        //    //httpClient.DefaultRequestHeaders.Cookie.Add(new HttpCookiePairHeaderValue("cf_clearance", "808d5662d9cd960b594cd8eaa983acc4555d7945-1552739397-1800-150"));
        //    httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; WOW64; WebView/3.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.140 Safari/537.36 Edge/17.17134");
        //    //httpClient.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
        //}
        public static async Task<string> GetHttpStringAsync(string url)
        {

            try
            {
                using (var httpClient = new HttpClient())
                {
                    //httpClient.DefaultRequestHeaders.Accept.ParseAdd("text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
                    //httpClient.DefaultRequestHeaders.AcceptEncoding.ParseAdd("gzip, deflate, br");
                    //httpClient.DefaultRequestHeaders.AcceptLanguage.ParseAdd("zh-Hans-CN,zh-Hans;q=0.5");
                    ////httpClient.DefaultRequestHeaders.Cookie.ParseAdd("__cfduid=da23badc3e204c443c5184a43c79badf61552618005; user_script_url=%2F%2Fcdn.acgscript.com%2Fscript%2Fmiobt%2F4.js%3F3; user_script_rev=20181120.2; cf_clearance=c239ddeb98f40eed2759688f2229ef43790ca928-1552736732-1800-150; Hm_lvt_bab0ae65b49b7efd4fde9bf6858ec60b=1552661934,1552667118,1552730529,1552736735; Hm_lpvt_bab0ae65b49b7efd4fde9bf6858ec60b=1552736952");
                    ////httpClient.DefaultRequestHeaders.Cookie.Add(new HttpCookiePairHeaderValue("__cfduid", "d8fbd02b8b8977496360fb0bf5c64120b1552633926"));
                    ////httpClient.DefaultRequestHeaders.Cookie.Add(new HttpCookiePairHeaderValue("cf_clearance", "808d5662d9cd960b594cd8eaa983acc4555d7945-1552739397-1800-150"));
                    httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; WOW64; WebView/3.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.140 Safari/537.36 Edge/17.17134");
                    ////httpClient.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
                    string result = await httpClient.GetStringAsync(new Uri(url));
                    return result;
                }
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public static string URLEncode(string url)
        {
            return WebUtility.UrlEncode(url);
        }
    }
}
