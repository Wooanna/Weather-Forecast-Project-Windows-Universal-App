﻿

#pragma checksum "C:\Users\Polar Bear\Documents\Visual Studio 2013\Projects\WeatherForecast\WeatherForecast\WeatherForecast.Shared\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "492DD156E096AEE7DBC2A03F945CC3E1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeatherForecast
{
    partial class MainPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 64 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.ListBox_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 204 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.FrameworkElement)(target)).Unloaded += this.progressIndicator_Unloaded;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 116 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.FrameworkElement)(target)).Loaded += this.LocationTextBlock_Loaded;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 134 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).DoubleTapped += this.Temp_DoubleTapped;
                 #line default
                 #line hidden
                #line 137 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.TextBlock_Tapped;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


