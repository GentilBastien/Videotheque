#pragma checksum "..\..\..\Modals\ModalClientAdd.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EDEF21764B6C8E504C074D1C5652F7C50E8B1F943F968BF0A5D5FB723D0AAB12"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using MaVideotheque.Components;
using MaVideotheque.Modals;
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


namespace MaVideotheque.Modals {
    
    
    /// <summary>
    /// ModalClientAdd
    /// </summary>
    public partial class ModalClientAdd : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\Modals\ModalClientAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox InputNom;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Modals\ModalClientAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox InputPrenom;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Modals\ModalClientAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox InputTel;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Modals\ModalClientAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox InputMail;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Modals\ModalClientAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox InputAdresse;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Modals\ModalClientAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox InputDateNaissance;
        
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
            System.Uri resourceLocater = new System.Uri("/MaVideotheque;component/modals/modalclientadd.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Modals\ModalClientAdd.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 10 "..\..\..\Modals\ModalClientAdd.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ClicAilleurs);
            
            #line default
            #line hidden
            return;
            case 2:
            this.InputNom = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.InputPrenom = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.InputTel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.InputMail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.InputAdresse = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.InputDateNaissance = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

