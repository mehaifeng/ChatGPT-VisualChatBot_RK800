﻿#pragma checksum "..\..\..\..\Views\VisualChat.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BDA623A664706924865D65ACC89725A2B33BEDB7"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using VisualChatBot.ViewModels;


namespace VisualChatBot {
    
    
    /// <summary>
    /// VisualChat
    /// </summary>
    public partial class VisualChat : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 60 "..\..\..\..\Views\VisualChat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton MenuToggleBtn;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\Views\VisualChat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup MenuPopup;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\..\Views\VisualChat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OpenSettingBtn;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\..\Views\VisualChat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border ConfigBorder;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\..\..\Views\VisualChat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ConfigGrid;
        
        #line default
        #line hidden
        
        
        #line 145 "..\..\..\..\Views\VisualChat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox OptionalModelsComboBox;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\..\..\Views\VisualChat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ObjectDegreeCombobox;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\..\..\Views\VisualChat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MaxTokensTextbox;
        
        #line default
        #line hidden
        
        
        #line 197 "..\..\..\..\Views\VisualChat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox OutputBox;
        
        #line default
        #line hidden
        
        
        #line 209 "..\..\..\..\Views\VisualChat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock loadingSignal;
        
        #line default
        #line hidden
        
        
        #line 238 "..\..\..\..\Views\VisualChat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button confirmBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/VisualChatBot;component/views/visualchat.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\VisualChat.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 32 "..\..\..\..\Views\VisualChat.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.MoveWindow_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 40 "..\..\..\..\Views\VisualChat.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MiniOrReSize_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 46 "..\..\..\..\Views\VisualChat.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Close_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 54 "..\..\..\..\Views\VisualChat.xaml"
            ((System.Windows.Controls.StackPanel)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.StackPanel_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.MenuToggleBtn = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            return;
            case 6:
            this.MenuPopup = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 7:
            this.OpenSettingBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.ConfigBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 9:
            this.ConfigGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 10:
            this.OptionalModelsComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 148 "..\..\..\..\Views\VisualChat.xaml"
            this.OptionalModelsComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OptionalModelsComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.ObjectDegreeCombobox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 161 "..\..\..\..\Views\VisualChat.xaml"
            this.ObjectDegreeCombobox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ObjectDegreeCombobox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.MaxTokensTextbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 175 "..\..\..\..\Views\VisualChat.xaml"
            this.MaxTokensTextbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.MaxTokensTextbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 13:
            this.OutputBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 206 "..\..\..\..\Views\VisualChat.xaml"
            this.OutputBox.GotFocus += new System.Windows.RoutedEventHandler(this.Input_GotFocus);
            
            #line default
            #line hidden
            return;
            case 14:
            this.loadingSignal = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 15:
            
            #line 228 "..\..\..\..\Views\VisualChat.xaml"
            ((System.Windows.Controls.TextBox)(target)).GotFocus += new System.Windows.RoutedEventHandler(this.Input_GotFocus);
            
            #line default
            #line hidden
            return;
            case 16:
            this.confirmBtn = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

