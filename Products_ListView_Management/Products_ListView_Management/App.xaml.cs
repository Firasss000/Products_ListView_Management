using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Products_ListView_Management
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ProductPage();
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
