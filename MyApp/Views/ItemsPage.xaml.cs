﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyApp.Models;
using MyApp.Views;
using MyApp.ViewModels;

namespace MyApp.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        private void OnSwipeLeft(object sender, SwipedEventArgs e)
        {
            // Handle the left swipe gesture here
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
