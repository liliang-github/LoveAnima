using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Data;

namespace LoveAnim.Models
{
    //支持增量加载的动态集合
    public class IncrementObservableCollection<T> : ObservableCollection<T>, ISupportIncrementalLoading
    {

        private Func<Task<List<T>>> LoadCallBack;

        public IncrementObservableCollection(Func<Task<List<T>>> func)
        {
            this.LoadCallBack = func;
            this.HasMoreItems = false;
        }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            return LoadMore().AsAsyncOperation();
        }

        public async Task<LoadMoreItemsResult> LoadMore()
        {
            Loading?.Invoke();
            List<T> ts = await LoadCallBack();
            ts.ForEach(ele =>
            {
                this.Add(ele);
            });

            this.HasMoreItems = this.Count >= 50;
            Loaded?.Invoke();
            return new LoadMoreItemsResult() { Count = (uint)ts.Count };
        }
        
        public bool HasMoreItems
        {
            get;
            set;
        }

        //加载中事件
        public delegate void loading();
        public event loading Loading;

        //加载完成事件
        public delegate void loaded();
        public event loaded Loaded;
    }
}
