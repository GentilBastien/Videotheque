﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaVideotheque.Modals
{
    public partial class ModalLocationDelete : UserControl
    {
        public string Msg { get; set; }
        public ModalLocationDelete(string LocationId)
        {
            InitializeComponent();
            this.DataContext = this;
            this.Msg = "Êtes-vous sûr de vouloir supprimer la location " + LocationId + " de la liste des locations ?";
        }

        private void ClicAilleurs(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void CancelButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void ValidateButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
