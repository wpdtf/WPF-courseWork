﻿#pragma checksum "..\..\Menu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9648943569476E12BAA3FA28A448498923079CCB4770444FC112449EC956E7E2"
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


namespace WpfApp1 {
    
    
    /// <summary>
    /// Menu
    /// </summary>
    public partial class Menu : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 73 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label users;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label posts;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border borderColor;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnWork;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnOut;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StackBoxT;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StackBoxV;
        
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
            System.Uri resourceLocater = new System.Uri("/NevaLink;component/menu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Menu.xaml"
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
            this.users = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.posts = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.borderColor = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.btnWork = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\Menu.xaml"
            this.btnWork.MouseMove += new System.Windows.Input.MouseEventHandler(this.ClickMove);
            
            #line default
            #line hidden
            
            #line 79 "..\..\Menu.xaml"
            this.btnWork.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ClickLeave);
            
            #line default
            #line hidden
            
            #line 79 "..\..\Menu.xaml"
            this.btnWork.Click += new System.Windows.RoutedEventHandler(this.ClickWork);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BtnOut = ((System.Windows.Controls.Button)(target));
            
            #line 83 "..\..\Menu.xaml"
            this.BtnOut.MouseMove += new System.Windows.Input.MouseEventHandler(this.ClickMove);
            
            #line default
            #line hidden
            
            #line 83 "..\..\Menu.xaml"
            this.BtnOut.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ClickLeave);
            
            #line default
            #line hidden
            
            #line 83 "..\..\Menu.xaml"
            this.BtnOut.Click += new System.Windows.RoutedEventHandler(this.ClickLeaveForm);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 87 "..\..\Menu.xaml"
            ((System.Windows.Controls.Button)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.ClickMove);
            
            #line default
            #line hidden
            
            #line 87 "..\..\Menu.xaml"
            ((System.Windows.Controls.Button)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.ClickLeave);
            
            #line default
            #line hidden
            return;
            case 7:
            this.StackBoxT = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.StackBoxV = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
