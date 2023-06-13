﻿using GestionApp.Views;
using MyApp.ViewModels;
using MyApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MyApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(ItemEditPage), typeof(ItemEditPage));

        }

    }
}
