﻿#pragma checksum "..\..\EditRate.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C67FFD9A3CCC3A1A018EC6167A2B670C0B8A5801238C66D2FAD7C01A5EB74AEA"
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
    /// EditRate
    /// </summary>
    public partial class EditRate : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 89 "..\..\EditRate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border b3;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\EditRate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel up;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\EditRate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnOut;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\EditRate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackEdit;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\EditRate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\EditRate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox discription;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\EditRate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox price;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\EditRate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnEdit;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\EditRate.xaml"
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
            System.Uri resourceLocater = new System.Uri("/NevaLink;component/editrate.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EditRate.xaml"
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
            this.up = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            
            #line 92 "..\..\EditRate.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.textUpdate);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnOut = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\EditRate.xaml"
            this.BtnOut.MouseMove += new System.Windows.Input.MouseEventHandler(this.ClickMove);
            
            #line default
            #line hidden
            
            #line 97 "..\..\EditRate.xaml"
            this.BtnOut.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ClickLeave);
            
            #line default
            #line hidden
            
            #line 97 "..\..\EditRate.xaml"
            this.BtnOut.Click += new System.Windows.RoutedEventHandler(this.ClickBack);
            
            #line default
            #line hidden
            return;
            case 5:
            this.stackEdit = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.discription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.price = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.BtnEdit = ((System.Windows.Controls.Button)(target));
            
            #line 113 "..\..\EditRate.xaml"
            this.BtnEdit.Click += new System.Windows.RoutedEventHandler(this.updateSotr);
            
            #line default
            #line hidden
            
            #line 113 "..\..\EditRate.xaml"
            this.BtnEdit.MouseMove += new System.Windows.Input.MouseEventHandler(this.ClickMove);
            
            #line default
            #line hidden
            
            #line 113 "..\..\EditRate.xaml"
            this.BtnEdit.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ClickLeave);
            
            #line default
            #line hidden
            return;
            case 10:
            this.BtnNow = ((System.Windows.Controls.Button)(target));
            
            #line 114 "..\..\EditRate.xaml"
            this.BtnNow.Click += new System.Windows.RoutedEventHandler(this.nowSotr);
            
            #line default
            #line hidden
            
            #line 114 "..\..\EditRate.xaml"
            this.BtnNow.MouseMove += new System.Windows.Input.MouseEventHandler(this.ClickMove);
            
            #line default
            #line hidden
            
            #line 114 "..\..\EditRate.xaml"
            this.BtnNow.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ClickLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

