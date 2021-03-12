using Goiabeira_Xamarin_Mobile.Models;
using Goiabeira_Xamarin_Mobile.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Goiabeira_Xamarin_Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private async void NovoUsuario(object sender, EventArgs e)
        {
            ServiceRepository service = new ServiceRepository();
            Usuario usuario = new Usuario();
            usuario.firstName = Txtname.Text;
            usuario.surname = TxtSurname.Text;
            usuario.age = Convert.ToInt32(TxtAge.Text);

            string response = await service.Cadastrar(usuario);

            if (response == "Created")
            {
                Txtname.Text = string.Empty;
                TxtSurname.Text = string.Empty;
                TxtAge.Text = string.Empty;

                await DisplayAlert("Sucesso","Usuários criado com sucesso.","OK");
            }
            else if(response == "Bad Request")
            {
                await DisplayAlert("Erro", "Ocorreu algum tipo de erro!!!", "Close");
            }
        }
    }
}