﻿#pragma checksum "D:\C\win10\LoveAnim\Views\ItemDetail.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "12B5885831DA66F0AE722F0AB8107173"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoveAnim.Views
{
    partial class ItemDetail : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
        };

        private class ItemDetail_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IItemDetail_Bindings
        {
            private global::LoveAnim.Views.ItemDetail dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::LoveAnim.Controls.HAppBarButton obj7;
            private global::LoveAnim.Controls.HAppBarButton obj8;

            public ItemDetail_obj1_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 7:
                        this.obj7 = (global::LoveAnim.Controls.HAppBarButton)target;
                        ((global::LoveAnim.Controls.HAppBarButton)target).Click += (global::System.Object param0, global::Windows.UI.Xaml.RoutedEventArgs param1) =>
                        {
                        this.dataRoot.Model.CopySeedDownloadUrl();
                        };
                        break;
                    case 8:
                        this.obj8 = (global::LoveAnim.Controls.HAppBarButton)target;
                        ((global::LoveAnim.Controls.HAppBarButton)target).Click += (global::System.Object param0, global::Windows.UI.Xaml.RoutedEventArgs param1) =>
                        {
                        this.dataRoot.Model.CopyMagnetDownloadUrl();
                        };
                        break;
                    default:
                        break;
                }
            }

            // IItemDetail_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            // ItemDetail_obj1_Bindings

            public void SetDataRoot(global::LoveAnim.Views.ItemDetail newDataRoot)
            {
                this.dataRoot = newDataRoot;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2:
                {
                    global::Windows.UI.Xaml.Controls.Grid element2 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 19 "..\..\..\Views\ItemDetail.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)element2).Loaded += this.Grid_Loaded;
                    #line default
                }
                break;
            case 3:
                {
                    this.background = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 4:
                {
                    this.fileWebView = (global::Windows.UI.Xaml.Controls.WebView)(target);
                }
                break;
            case 5:
                {
                    this.infoWebView = (global::Windows.UI.Xaml.Controls.WebView)(target);
                }
                break;
            case 6:
                {
                    this.time = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.seedDownload = (global::LoveAnim.Controls.HAppBarButton)(target);
                }
                break;
            case 8:
                {
                    global::LoveAnim.Controls.HAppBarButton element8 = (global::LoveAnim.Controls.HAppBarButton)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    ItemDetail_obj1_Bindings bindings = new ItemDetail_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            }
            return returnValue;
        }
    }
}

