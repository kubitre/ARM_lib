﻿#pragma checksum "..\..\..\views\ReturnBook.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "726DBEDAF8879DA4E5B921A7C943E505C071A36A76301D19F576BE1DA68CD0FD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ARM_Lib.views;
using MahApps.Metro.Controls;
using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ARM_Lib.views {
    
    
    /// <summary>
    /// ReturnBook
    /// </summary>
    public partial class ReturnBook : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\views\ReturnBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.FlyoutsControl FlyoutControls;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\views\ReturnBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.Flyout AboutApp;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\views\ReturnBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.Flyout reports_pane;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\views\ReturnBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button report_per_books_button;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\views\ReturnBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button report_per_reader_button;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\views\ReturnBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button reports_button;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\views\ReturnBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button about_app;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\views\ReturnBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button back_to_main_window;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\views\ReturnBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid return_book_grid;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\views\ReturnBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button return_button;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ARM_Lib;component/views/returnbook.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\views\ReturnBook.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.FlyoutControls = ((MahApps.Metro.Controls.FlyoutsControl)(target));
            return;
            case 2:
            this.AboutApp = ((MahApps.Metro.Controls.Flyout)(target));
            return;
            case 3:
            this.reports_pane = ((MahApps.Metro.Controls.Flyout)(target));
            return;
            case 4:
            this.report_per_books_button = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\views\ReturnBook.xaml"
            this.report_per_books_button.Click += new System.Windows.RoutedEventHandler(this.report_per_books_button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.report_per_reader_button = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\views\ReturnBook.xaml"
            this.report_per_reader_button.Click += new System.Windows.RoutedEventHandler(this.report_per_reader_button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.reports_button = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\views\ReturnBook.xaml"
            this.reports_button.Click += new System.Windows.RoutedEventHandler(this.reports_button_click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.about_app = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\..\views\ReturnBook.xaml"
            this.about_app.Click += new System.Windows.RoutedEventHandler(this.about_app_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.back_to_main_window = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\..\views\ReturnBook.xaml"
            this.back_to_main_window.Click += new System.Windows.RoutedEventHandler(this.back_to_main_window_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.return_book_grid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 122 "..\..\..\views\ReturnBook.xaml"
            this.return_book_grid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.DataGrid_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.return_button = ((System.Windows.Controls.Button)(target));
            
            #line 130 "..\..\..\views\ReturnBook.xaml"
            this.return_button.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

