﻿#pragma checksum "C:\Users\Митрандир\Desktop\IISandAzure\StoreApp\Store\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BE4677351A33EF0CB3EFB265FB02A4B9"
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
    partial class MainPage : 
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
                    global::Windows.UI.Xaml.Controls.StackPanel element1 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                    #line 11 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.StackPanel)element1).Tapped += this.Menu_Tapped;
                    #line default
                }
                break;
            case 2:
                {
                    this.foodButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 20 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.foodButton).Click += this.foodButton_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.drinksButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 4:
                {
                    this.fashionButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 5:
                {
                    this.foodText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6:
                {
                    this.drinksText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.fashionText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8:
                {
                    this.header = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

