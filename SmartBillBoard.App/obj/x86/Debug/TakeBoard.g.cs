﻿#pragma checksum "C:\Users\gookc\Desktop\SmartBillBoard\SmartBillBoard.App\TakeBoard.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "14965464CA81C926C6DAD3FE34D9EE49"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartBillBoard.App
{
    partial class TakeBoard : 
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
                    this.MySplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 2:
                {
                    this.btnHamburgerMenu = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 14 "..\..\..\TakeBoard.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnHamburgerMenu).Click += this.btnHamburgerMenu_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.btnHistory = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 28 "..\..\..\TakeBoard.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnHistory).Click += this.btnHistory_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.btnAdd = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 24 "..\..\..\TakeBoard.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnAdd).Click += this.btnAdd_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.btnSale = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 20 "..\..\..\TakeBoard.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnSale).Click += this.btnSale_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.btnHome = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 16 "..\..\..\TakeBoard.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnHome).Click += this.btnHome_Click;
                    #line default
                }
                break;
            case 7:
                {
                    this.tbFirstDay = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8:
                {
                    this.dpFirstDay = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 9:
                {
                    this.tbLastDay = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10:
                {
                    this.dpLastDay = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 11:
                {
                    this.tbPrice = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12:
                {
                    this.btnBuy = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 66 "..\..\..\TakeBoard.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnBuy).Click += this.btnBuy_Click;
                    #line default
                }
                break;
            case 13:
                {
                    this.tbLocationName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

