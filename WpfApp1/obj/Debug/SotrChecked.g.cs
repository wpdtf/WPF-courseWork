#pragma checksum "..\..\SotrChecked.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "16FA8F7539F69975901F48EC8EB6DC29FDBD87B2233AAC43493F594755E18337"
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
    /// SotrChecked
    /// </summary>
    public partial class SotrChecked : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 71 "..\..\SotrChecked.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border b3;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\SotrChecked.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border b2;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\SotrChecked.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label users;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\SotrChecked.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label posts;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\SotrChecked.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnOut;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\SotrChecked.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrids;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\SotrChecked.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnEdit;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\SotrChecked.xaml"
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
            System.Uri resourceLocater = new System.Uri("/NevaLink;component/sotrchecked.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SotrChecked.xaml"
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
            
            #line 83 "..\..\SotrChecked.xaml"
            this.BtnOut.MouseMove += new System.Windows.Input.MouseEventHandler(this.ClickMove);
            
            #line default
            #line hidden
            
            #line 83 "..\..\SotrChecked.xaml"
            this.BtnOut.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ClickLeave);
            
            #line default
            #line hidden
            
            #line 83 "..\..\SotrChecked.xaml"
            this.BtnOut.Click += new System.Windows.RoutedEventHandler(this.ClickBack);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dataGrids = ((System.Windows.Controls.DataGrid)(target));
            
            #line 88 "..\..\SotrChecked.xaml"
            this.dataGrids.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.deleteClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BtnEdit = ((System.Windows.Controls.Button)(target));
            
            #line 96 "..\..\SotrChecked.xaml"
            this.BtnEdit.Click += new System.Windows.RoutedEventHandler(this.ViewEdit);
            
            #line default
            #line hidden
            
            #line 96 "..\..\SotrChecked.xaml"
            this.BtnEdit.MouseMove += new System.Windows.Input.MouseEventHandler(this.ClickMove);
            
            #line default
            #line hidden
            
            #line 96 "..\..\SotrChecked.xaml"
            this.BtnEdit.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ClickLeave);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BtnNow = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\SotrChecked.xaml"
            this.BtnNow.Click += new System.Windows.RoutedEventHandler(this.ViewNow);
            
            #line default
            #line hidden
            
            #line 97 "..\..\SotrChecked.xaml"
            this.BtnNow.MouseMove += new System.Windows.Input.MouseEventHandler(this.ClickMove);
            
            #line default
            #line hidden
            
            #line 97 "..\..\SotrChecked.xaml"
            this.BtnNow.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ClickLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

