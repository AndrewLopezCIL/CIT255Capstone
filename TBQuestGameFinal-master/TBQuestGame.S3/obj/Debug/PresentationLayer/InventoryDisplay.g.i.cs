﻿#pragma checksum "..\..\..\PresentationLayer\InventoryDisplay.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E9D293F6473919E108CF1B5B6109F0F931B95435B7E9AE960A0C1C1FE9C4191E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using TBQuestGame.PresentationLayer;


namespace TBQuestGame.PresentationLayer {
    
    
    /// <summary>
    /// InventoryDisplay
    /// </summary>
    public partial class InventoryDisplay : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem PlayerInventoryTab;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid playerInventoryGrid;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn ItemsNames;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn ItemsStack;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn LevelRequirement;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem EquippedTab;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid playerEquippedGrid;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn EquippedName;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem LocationLootTab;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid locationLootGrid;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn LootItemName;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn LootableItemStack;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DropItem;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DropAll;
        
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
            System.Uri resourceLocater = new System.Uri("/TBQuestGame;component/presentationlayer/inventorydisplay.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
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
            
            #line 8 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
            ((TBQuestGame.PresentationLayer.InventoryDisplay)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PlayerInventoryTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 3:
            
            #line 19 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Label_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.playerInventoryGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 22 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
            this.playerInventoryGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.playerInventoryGrid_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 22 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
            this.playerInventoryGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.playerInventoryGrid_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ItemsNames = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 6:
            this.ItemsStack = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 7:
            this.LevelRequirement = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 8:
            this.EquippedTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 9:
            
            #line 60 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Label_MouseLeftButtonDown_2);
            
            #line default
            #line hidden
            return;
            case 10:
            this.playerEquippedGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 11:
            this.EquippedName = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 12:
            this.LocationLootTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 13:
            
            #line 81 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Label_MouseLeftButtonDown_1);
            
            #line default
            #line hidden
            return;
            case 14:
            this.locationLootGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 83 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
            this.locationLootGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.locationLootGrid_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 83 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
            this.locationLootGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.locationLootGrid_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 15:
            this.LootItemName = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 16:
            this.LootableItemStack = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 17:
            this.DropItem = ((System.Windows.Controls.Button)(target));
            
            #line 113 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
            this.DropItem.Click += new System.Windows.RoutedEventHandler(this.DropItem_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            this.DropAll = ((System.Windows.Controls.Button)(target));
            
            #line 114 "..\..\..\PresentationLayer\InventoryDisplay.xaml"
            this.DropAll.Click += new System.Windows.RoutedEventHandler(this.DropAll_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

