using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Goiabeira_Xamarin_Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Cadastro();
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
