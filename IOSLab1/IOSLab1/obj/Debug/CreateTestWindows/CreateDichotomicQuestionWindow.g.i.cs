﻿#pragma checksum "..\..\..\CreateTestWindows\CreateDichotomicQuestionWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3A034BF18DDC00564E09199F62CB41D8"
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
    /// CreateDichotomicQuestionWindow
    /// </summary>
    public partial class CreateDichotomicQuestionWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\CreateTestWindows\CreateDichotomicQuestionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox questionTextBox;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\CreateTestWindows\CreateDichotomicQuestionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label questionsNumberLabel;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\CreateTestWindows\CreateDichotomicQuestionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addQuestion;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\CreateTestWindows\CreateDichotomicQuestionWindow.xaml"
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
            System.Uri resourceLocater = new System.Uri("/IOSLab1;component/createtestwindows/createdichotomicquestionwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CreateTestWindows\CreateDichotomicQuestionWindow.xaml"
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
            this.addQuestion = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\CreateTestWindows\CreateDichotomicQuestionWindow.xaml"
            this.addQuestion.Click += new System.Windows.RoutedEventHandler(this.addQuestion_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.specifyRules = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\CreateTestWindows\CreateDichotomicQuestionWindow.xaml"
            this.specifyRules.Click += new System.Windows.RoutedEventHandler(this.specifyRules_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

