using LoveAnim.Managers;
using LoveAnim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveAnim.ViewModels
{
    public class SearchPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public SearchPageViewModel()
        {
            Items.Loading += () =>
            {
                IsLoading = true;
            };
            Items.Loaded += () =>
            {
                IsLoading = false;
            };
            Items.HasMoreItems = false;
        }

        private IncrementObservableCollection<Item> _items;
        public IncrementObservableCollection<Item> Items
        {
            get
            {
                return _items ?? (_items = new IncrementObservableCollection<Item>(SearchOrLoadMore));
            }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsResults)));
                }
            }
        }

        public bool IsResults
        {
            get
            {
                return !IsLoading && Items.Count == 0 && SearchText.Length != 0;
            }
        }

        private string _searchText = "";
        public string SearchText
        {
            get
            {
                return _searchText.Trim();
            }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchText)));
                    //PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(IsResults)));
                }
            }
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
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsResults)));
                }
            }
        }

        private int _page = 1;

        public async Task<List<Item>> SearchOrLoadMore()
        {
            List<Item> items = await ItemManager.GetSearchByQueryAsync(SearchText, _page);
            _page++;
            return items;
        }

        public async void Search()
        {
            if (IsLoading)
                return;
            _page = 1;
            Items.HasMoreItems = false;
            IsLoading = true;
            Items.Clear();
            if (SearchText.Length == 0)
            {
                IsLoading = false;
                return;
            }
            List<Item> items = await SearchOrLoadMore();
            items.ForEach(ele =>
            {
                Items.Add(ele);
            });
            IsLoading = false;
            if (items.Count >= 50)
                Items.HasMoreItems = true;
        }

    }
}
