using LoveAnim.Managers;
using LoveAnim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;

namespace LoveAnim.ViewModels
{
    public class ItemDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Item _item;

        public Item Item
        {
            get
            {
                return _item ?? (_item = new Item());
            }
            set
            {
                if(_item != value)
                {
                    _item = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Item)));
                }
            }
        }

        private string _viewHtml;
        public string ViewHtml
        {
            get
            {
                return _viewHtml;
            }
            set
            {
                if(_viewHtml != value)
                {
                    _viewHtml = value;
                    PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(ViewHtml)));
                }
            }
        }
        public string FileHtml { get; set; }
        public async Task LoadViewHtml()
        {
            ViewHtml = await ItemManager.GetDetailViewHtmlAsync(Item.URL);
        }
        public async Task LoadFileHtml()
        {
            FileHtml = await ItemManager.GetDetailFileHtmlAsync(Item.URL);
        }

        public void CopyMagnetDownloadUrl()
        {
            DataPackage dataPackage = new DataPackage();
            dataPackage.SetText(Item.MagnetDownloadURL);
            Clipboard.SetContent(dataPackage);
        }

        public void CopySeedDownloadUrl()
        {
            DataPackage dataPackage = new DataPackage();
            dataPackage.SetText(Item.SeedDownloadURL);
            Clipboard.SetContent(dataPackage);
        }

    }
}
