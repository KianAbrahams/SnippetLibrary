﻿using Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels;
using System.Windows;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.Views
{
    /// <summary>
    /// Interaction logic for SnippetEditDialogue.xaml
    /// </summary>
    public partial class SnippetEditDialog : Window
    {
        private readonly SnippetEditDialogViewModel snippetEditDialogViewModel;
        
        public SnippetEditDialog(SnippetEditDialogViewModel snippetEditDialogViewModel)
        {
            this.snippetEditDialogViewModel = snippetEditDialogViewModel;
            
            InitializeComponent();
            this.DataContext = this.snippetEditDialogViewModel;        
        }
    }
}