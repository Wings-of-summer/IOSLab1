﻿#pragma checksum "..\..\OpenCreateQuestionWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E47F29C100EDD88CEA393399824EBC29"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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


namespace IOSLab1 {
    
    
    /// <summary>
    /// OpenQuestionWindow
    /// </summary>
    public partial class OpenQuestionWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\OpenCreateQuestionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox questionTextBox;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\OpenCreateQuestionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label questionsNumberLabel;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\OpenCreateQuestionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox measureTextBox;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\OpenCreateQuestionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox exampleTextBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\OpenCreateQuestionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addQuestion;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\OpenCreateQuestionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button specifyRules;
        
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
            System.Uri resourceLocater = new System.Uri("/IOSLab1;component/opencreatequestionwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\OpenCreateQuestionWindow.xaml"
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
            this.questionTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.questionsNumberLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.measureTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.exampleTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.addQuestion = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\OpenCreateQuestionWindow.xaml"
            this.addQuestion.Click += new System.Windows.RoutedEventHandler(this.addQuestion_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.specifyRules = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\OpenCreateQuestionWindow.xaml"
            this.specifyRules.Click += new System.Windows.RoutedEventHandler(this.specifyRules_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

