using LoveAnim.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LoveAnim.Models
{
    public class Item
    {
        private static string BASE_PORTAL_URL = "http://kisssub.org/";
        private static string BASE_SEED_DOWNLOAD_URL = "http://v2.uploadbt.com/?r=down&hash={0}&name={1}";
        private static string BASE_MAGNET_DOWNLOAD_URL = "magnet:?xt=urn:btih:{0}&tr=http://open.acgtracker.com:1096/announce";
        //  发布日期
        public string PublishTime { get; set; }
        //  文件类型
        public string Type { get; set; }
        //  标题
        public string Title { get; set; }
        //  文件大小
        public string FileSize { get; set; }
        //  种子数
        public int SeedCount { get; set; }
        //  下载数
        public int DownlandCount { get; set; }
        //  完成数
        public int DoneCount { get; set; }
        //  发布人
        public string PublishUP { get; set; }

        public string Hash
        {
            get
            {
                Match match = Regex.Match(URL,"([0-9a-zA-Z]+.?).html$");
                return match.Groups[1].Value;
            }
        }
        //  地址
        private string _url;
        public string URL
        {
            get
            {
                //return $"http://kisssub.org/{_url}";
                return BASE_PORTAL_URL + _url;
            }
            set
            {
                _url = value;
            }
        }
        
        public string SeedDownloadURL
        {
            get
            {
                return String.Format(BASE_SEED_DOWNLOAD_URL,Hash,HttpUtil.URLEncode(Title));
            }
        }
        
        public string MagnetDownloadURL
        {
            get
            {
                return String.Format(BASE_MAGNET_DOWNLOAD_URL, Hash);
            }
        }
    }
}
