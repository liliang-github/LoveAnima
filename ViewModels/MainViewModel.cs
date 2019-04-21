using LoveAnim.Managers;
using LoveAnim.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveAnim.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            this.Items.Loading += () =>
            {
                this.IsLoading = true;
            };
            this.Items.Loaded += () =>
            {
                this.IsLoading = false;
            };
        }

        private IncrementObservableCollection<Item> _items;

        public IncrementObservableCollection<Item> Items
        {
            get
            {
                return _items ?? (_items = new IncrementObservableCollection<Item>(LoadMore));
            }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));
                }
            }
        }

        private int _page = 1;

        public async Task<List<Item>> LoadMore()
        {
            List<Item> results = await ItemManager.GetItemsAsync(_page);
            if (results == null)
            {
                return new List<Item>();
            }
            _page++;
            return results;
        }

        public async void LoadList()
        {
            IsLoading = true;
            List<Item> items = await LoadMore();
            items.ForEach(ele =>
            {
                Items.Add(ele);
            });
            IsLoading = false;
            if (items.Count >= 50)
                Items.HasMoreItems = true;
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsLoading)));
                }
            }
        }
    }
}
