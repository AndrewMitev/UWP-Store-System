﻿#pragma checksum "C:\Users\Митрандир\Desktop\StoreApp\Store\MyCart.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9F15CB652CFB1F3E3F93D7B3F8D610B0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Store
{
    partial class MyCart : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.Menu = (global::Windows.UI.Xaml.Controls.Canvas)(target);
                    #line 17 "..\..\..\MyCart.xaml"
                    ((global::Windows.UI.Xaml.Controls.Canvas)this.Menu).Tapped += this.Menu_Tapped;
                    #line default
                }
                break;
            case 2:
                {
                    this.ItemsToBuy = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.Button element3 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 56 "..\..\..\MyCart.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element3).Click += this.Begin_Transaction;
                    #line default
                }
                break;
            case 4:
                {
                    global::Windows.UI.Xaml.Controls.Button element4 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 59 "..\..\..\MyCart.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element4).Click += this.Clear_Cart;
                    #line default
                }
                break;
            case 5:
                {
                    this.header = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6:
                {
                    this.UserName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.Money = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8:
                {
                    global::Windows.UI.Xaml.Controls.Button element8 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 23 "..\..\..\MyCart.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element8).Click += this.My_Cart;
                    #line default
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
            return returnValue;
        }
    }
}

