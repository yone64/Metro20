﻿

#pragma checksum "C:\Users\yone64\Source\Repos\Metro20\App1\App1\SplitPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DB518C13438A1BD9C41F79683FE406EB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App1
{
    partial class SplitPage : global::App1.Common.LayoutAwarePage
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::App1.Common.LayoutAwarePage pageRoot; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Data.CollectionViewSource itemsViewSource; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.ColumnDefinition primaryColumn; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Grid titlePanel; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.ListView itemListView; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.ScrollViewer itemDetail; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Grid itemDetailGrid; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.StackPanel itemDetailTitlePanel; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock itemTitle; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock itemSubtitle; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button backButton; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock pageTitle; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.VisualStateGroup ApplicationViewStates; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.VisualState FullScreenLandscapeOrWide; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.VisualState FilledOrNarrow; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.VisualState FullScreenPortrait; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.VisualState FullScreenPortrait_Detail; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.VisualState Snapped; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.VisualState Snapped_Detail; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private bool _contentLoaded;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;
            global::Windows.UI.Xaml.Application.LoadComponent(this, new global::System.Uri("ms-appx:///SplitPage.xaml"), global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
 
            pageRoot = (global::App1.Common.LayoutAwarePage)this.FindName("pageRoot");
            itemsViewSource = (global::Windows.UI.Xaml.Data.CollectionViewSource)this.FindName("itemsViewSource");
            primaryColumn = (global::Windows.UI.Xaml.Controls.ColumnDefinition)this.FindName("primaryColumn");
            titlePanel = (global::Windows.UI.Xaml.Controls.Grid)this.FindName("titlePanel");
            itemListView = (global::Windows.UI.Xaml.Controls.ListView)this.FindName("itemListView");
            itemDetail = (global::Windows.UI.Xaml.Controls.ScrollViewer)this.FindName("itemDetail");
            itemDetailGrid = (global::Windows.UI.Xaml.Controls.Grid)this.FindName("itemDetailGrid");
            itemDetailTitlePanel = (global::Windows.UI.Xaml.Controls.StackPanel)this.FindName("itemDetailTitlePanel");
            itemTitle = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("itemTitle");
            itemSubtitle = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("itemSubtitle");
            backButton = (global::Windows.UI.Xaml.Controls.Button)this.FindName("backButton");
            pageTitle = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("pageTitle");
            ApplicationViewStates = (global::Windows.UI.Xaml.VisualStateGroup)this.FindName("ApplicationViewStates");
            FullScreenLandscapeOrWide = (global::Windows.UI.Xaml.VisualState)this.FindName("FullScreenLandscapeOrWide");
            FilledOrNarrow = (global::Windows.UI.Xaml.VisualState)this.FindName("FilledOrNarrow");
            FullScreenPortrait = (global::Windows.UI.Xaml.VisualState)this.FindName("FullScreenPortrait");
            FullScreenPortrait_Detail = (global::Windows.UI.Xaml.VisualState)this.FindName("FullScreenPortrait_Detail");
            Snapped = (global::Windows.UI.Xaml.VisualState)this.FindName("Snapped");
            Snapped_Detail = (global::Windows.UI.Xaml.VisualState)this.FindName("Snapped_Detail");
        }
    }
}



