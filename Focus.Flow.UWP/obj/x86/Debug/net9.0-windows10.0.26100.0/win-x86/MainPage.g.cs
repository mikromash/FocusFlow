﻿#pragma checksum "C:\Users\maria\Desktop\Focus.Flow.UWP\Focus.Flow.UWP\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "74C4C129593D2C5DF490B8B70BEDA16C1AA735BFF386BD1F7CA8B9B9FDCE9A3B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Focus.Flow.UWP
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 16
                {
                    global::Windows.UI.Xaml.Controls.Button element2 = global::WinRT.CastExtensions.As<global::Windows.UI.Xaml.Controls.Button>(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element2).Click += this.AddTask_Click;
                }
                break;
            case 3: // MainPage.xaml line 24
                {
                    global::Windows.UI.Xaml.Controls.Button element3 = global::WinRT.CastExtensions.As<global::Windows.UI.Xaml.Controls.Button>(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element3).Click += this.OpenTasks_Click;
                }
                break;
            case 4: // MainPage.xaml line 32
                {
                    global::Windows.UI.Xaml.Controls.Button element4 = global::WinRT.CastExtensions.As<global::Windows.UI.Xaml.Controls.Button>(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element4).Click += this.OpenTimer_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

