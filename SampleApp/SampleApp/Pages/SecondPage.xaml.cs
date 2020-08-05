using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SampleApp.Pages
{
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
