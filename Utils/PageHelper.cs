using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media.Animation;

namespace LoveAnim.Utils
{
    public class PageHelper
    {
        private class PageHelperItem
        {
            //导航类型
            public Type PageType { get; set; }
            //导航页面
            public Frame PageFrame { get; set; }
            //导航参数
            public object PageParam { get; set; }

            public bool Navigate()
            {
                return this.PageFrame.Navigate(this.PageType, this.PageParam);
            }
        }

        private PageHelper() { }

        //单例本类对象
        private static PageHelper _instance;
        public static PageHelper Instance
        {
            get
            {
                return _instance ?? (_instance = new PageHelper());
            }
        }

        private Grid _grid;
        public void Init(Grid grid)
        {
            _grid = grid;
            //设置页面过渡动画
            if (grid.ChildrenTransitions == null)
            {
                TransitionCollection transitions = new TransitionCollection();
                grid.ChildrenTransitions = transitions;
            }
            grid.ChildrenTransitions.Add(new EdgeUIThemeTransition() { Edge = EdgeTransitionLocation.Right });
            this.InitBack();
        }


        //页面导航
        private int ZIndex = 1;
        private Stack<PageHelperItem> pageHelperItems = new Stack<PageHelperItem>();
        public bool Navigate(Type PageType,object PageParam)
        {
            PageHelperItem page = new PageHelperItem()
            {
                PageType = PageType,
                PageParam = PageParam,
                PageFrame = new Frame()
            };

            Canvas.SetZIndex(page.PageFrame,ZIndex);

            if (!page.Navigate())
            {
                return false;
            }

            this._grid.Children.Add(page.PageFrame);

            this.pageHelperItems.Push(page);

            ZIndex++;
            this.CheckBackButton();
            return true;
        }

        //返回页面
        public void Back()
        {
            if (this.CanBack()) { 
                this._grid.Children.Remove(this.pageHelperItems.Pop().PageFrame);
                this.CheckBackButton();
            }
        }

        public bool CanBack()
        {
            return pageHelperItems.Count > 0;
        }

        public void InitBack()
        {
            SystemNavigationManager.GetForCurrentView().BackRequested += PageHelper_BackRequested;
        }

        private void PageHelper_BackRequested(object sender, BackRequestedEventArgs e)
        {
            this.Back();
        }

        private void CheckBackButton()
        {
            if (this.CanBack())
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
        }
    }
}
