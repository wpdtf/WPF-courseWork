﻿#pragma checksum "..\..\homeLink.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7F94FE96D368D100FEC5266AF7A53761FD517FA222CBF32A09B5153B3B1ADC37"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfApp1;


namespace WpfApp1 {
    
    
    /// <summary>
    /// homeLink
    /// </summary>
    public partial class homeLink : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 73 "..\..\homeLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border b3;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\homeLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border b2;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\homeLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label users;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\homeLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label posts;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\homeLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnOut;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\homeLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrids;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\homeLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnEdit;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\homeLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnNow;
        
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
            System.Uri resourceLocater = new System.Uri("/NevaLink;component/homelink.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\homeLink.xaml"
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
            this.b3 = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.b2 = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.users = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.posts = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.BtnOut = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\homeLink.xaml"
            this.BtnOut.MouseMove += new System.Windows.Input.MouseEventHandler(this.ClickMove);
            
            #line default
            #line hidden
            
            #line 85 "..\..\homeLink.xaml"
            this.BtnOut.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ClickLeave);
            
            #line default
            #line hidden
            
            #line 85 "..\..\homeLink.xaml"
            this.BtnOut.Click += new System.Windows.RoutedEventHandler(this.ClickBack);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dataGrids = ((System.Windows.Controls.DataGrid)(target));
            
            #line 90 "..\..\homeLink.xaml"
            this.dataGrids.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.deleteClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BtnEdit = ((System.Windows.Controls.Button)(target));
            
            #line 98 "..\..\homeLink.xaml"
            this.BtnEdit.Click += new System.Windows.RoutedEventHandler(this.ViewEdit);
            
            #line default
            #line hidden
            
            #line 98 "..\..\homeLink.xaml"
            this.BtnEdit.MouseMove += new System.Windows.Input.MouseEventHandler(this.ClickMove);
            
            #line default
            #line hidden
            
            #line 98 "..\..\homeLink.xaml"
            this.BtnEdit.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ClickLeave);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BtnNow = ((System.Windows.Controls.Button)(target));
            
            #line 99 "..\..\homeLink.xaml"
            this.BtnNow.Click += new System.Windows.RoutedEventHandler(this.ViewNow);
            
            #line default
            #line hidden
            
            #line 99 "..\..\homeLink.xaml"
            this.BtnNow.MouseMove += new System.Windows.Input.MouseEventHandler(this.ClickMove);
            
            #line default
            #line hidden
            
            #line 99 "..\..\homeLink.xaml"
            this.BtnNow.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ClickLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

