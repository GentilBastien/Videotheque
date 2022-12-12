﻿#pragma checksum "..\..\..\Views\ClientView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AAB7D8C984BA1B0AD2F124DFD1F98430A770CE6E7F99BB3EF62C5495626BB5FE"
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
using MaVideotheque.Views;
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


namespace MaVideotheque.Views {
    
    
    /// <summary>
    /// ClientView
    /// </summary>
    public partial class ClientView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Views\ClientView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ClientMainContainer;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Views\ClientView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TopName;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Views\ClientView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaVideotheque.Components.BasicBouton BtnDeleteClient;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Views\ClientView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaVideotheque.Components.BasicBouton BtnEditClient;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Views\ClientView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaVideotheque.Components.BasicBouton BtnFactureClient;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Views\ClientView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaVideotheque.Components.BasicBouton BtnLouerFilm;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Views\ClientView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaVideotheque.Components.BasicBouton BtnAddClient;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Views\ClientView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TopId;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Views\ClientView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TopNom;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Views\ClientView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TopPrenom;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Views\ClientView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TopTel;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Views\ClientView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TopMail;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Views\ClientView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TopAdresse;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Views\ClientView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TopDateNaissance;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Views\ClientView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel LocationsStack;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\Views\ClientView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel ClientItems;
        
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
            System.Uri resourceLocater = new System.Uri("/MaVideotheque;component/views/clientview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ClientView.xaml"
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
            this.ClientMainContainer = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.TopName = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.BtnDeleteClient = ((MaVideotheque.Components.BasicBouton)(target));
            return;
            case 4:
            this.BtnEditClient = ((MaVideotheque.Components.BasicBouton)(target));
            return;
            case 5:
            this.BtnFactureClient = ((MaVideotheque.Components.BasicBouton)(target));
            return;
            case 6:
            this.BtnLouerFilm = ((MaVideotheque.Components.BasicBouton)(target));
            return;
            case 7:
            this.BtnAddClient = ((MaVideotheque.Components.BasicBouton)(target));
            return;
            case 8:
            this.TopId = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.TopNom = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.TopPrenom = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.TopTel = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.TopMail = ((System.Windows.Controls.Label)(target));
            return;
            case 13:
            this.TopAdresse = ((System.Windows.Controls.Label)(target));
            return;
            case 14:
            this.TopDateNaissance = ((System.Windows.Controls.Label)(target));
            return;
            case 15:
            this.LocationsStack = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 16:
            this.ClientItems = ((System.Windows.Controls.StackPanel)(target));
            
            #line 98 "..\..\..\Views\ClientView.xaml"
            this.ClientItems.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ClientItem_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

