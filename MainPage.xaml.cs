using LoveAnim.Managers;
using LoveAnim.Utils;
using LoveAnim.ViewModels;
using LoveAnim.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace LoveAnim
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            PageHelper.Instance.Init(this.detail);
            InitializeFrostedGlass(this.background);
            //Auth.GetCodeUrl();
        }

        public MainViewModel Model
        {
            get
            {
                return this.DataContext as MainViewModel;
            }
        }

        private void InitializeFrostedGlass(UIElement glassHost)
        {
            Visual hostVisual = ElementCompositionPreview.GetElementVisual(glassHost);
            Compositor compositor = hostVisual.Compositor;
            var backdropBrush = compositor.CreateHostBackdropBrush();
            var glassVisual = compositor.CreateSpriteVisual();
            glassVisual.Brush = backdropBrush;
            ElementCompositionPreview.SetElementChildVisual(glassHost, glassVisual);
            var bindSizeAnimation = compositor.CreateExpressionAnimation("hostVisual.Size");
            bindSizeAnimation.SetReferenceParameter("hostVisual", hostVisual);
            glassVisual.StartAnimation("Size", bindSizeAnimation);
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            PageHelper.Instance.Navigate(typeof(ItemDetail),e.ClickedItem);
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.Instance.Navigate(typeof(SearchPage), null);
        }
    }
}
