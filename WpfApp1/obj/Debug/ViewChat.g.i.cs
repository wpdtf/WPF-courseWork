﻿#pragma checksum "..\..\ViewChat.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "13479EAD429D9C5A468642F7028BE885484AB7C17A37708E49363A3AE320E3DD"
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
    /// ListChat
    /// </summary>
    public partial class ListChat : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 90 "..\..\ViewChat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border b3;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\ViewChat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnOut;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\ViewChat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackEdit;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\ViewChat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox chat;
        
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
            System.Uri resourceLocater = new System.Uri("/NevaLink;component/viewchat.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ViewChat.xaml"
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
            this.BtnOut = ((System.Windows.Controls.Button)(target));
            
            #line 94 "..\..\ViewChat.xaml"
            this.BtnOut.MouseMove += new System.Windows.Input.MouseEventHandler(this.ClickMove);
            
            #line default
            #line hidden
            
            #line 94 "..\..\ViewChat.xaml"
            this.BtnOut.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ClickLeave);
            
            #line default
            #line hidden
            
            #line 94 "..\..\ViewChat.xaml"
            this.BtnOut.Click += new System.Windows.RoutedEventHandler(this.ClickBack);
            
            #line default
            #line hidden
            return;
            case 3:
            this.stackEdit = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.chat = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

