using System;
using Akavache;
using FreshMvvm;
using FreshTinyIoC;
using SampleApp.PageModels;
using Services;
using Services.Cache;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp
{
    public partial class App : Application
    {
        public App()
        {
            SetupDependencies();
            InitializeComponent();

            var page = FreshPageModelResolver.ResolvePageModel<HomePageModel>();
            var basicNavContainer = new FreshNavigationContainer(page);
            MainPage = basicNavContainer;
            //MainPage = new MainPage();
        }

        private void SetupDependencies()
        {
            FreshTinyIoCContainer.Current.Register<IValidationService, ValidationService>();
            FreshTinyIoCContainer.Current.Register<ICacheService, CacheService>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
