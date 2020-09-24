using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace registroNotas
{
    public partial class MainPage : ContentPage
    {
        readonly UsuarioLogin usuario = new UsuarioLogin();
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ingresar_Clicked(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string contraseña = txtContraseña.Text;

            var result = await usuario.logeo(correo, contraseña);

            Usuario user = (Usuario) result;

            if (user.id != 0)
            {
                await Navigation.PushAsync(new RegistroAlumno(user));
            }
            else {

                await DisplayAlert("Login fallo", "Usuario No existe o la contraseña es Incorrecta", "OK");
            }
        }

        private async void registro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SingUp());
        }

        private void creadores_Clicked(object sender, EventArgs e)
        {
            using (var datos = new Persistencia())
            {
                List<Creador> creadors = datos.GetAlumno();

                foreach (Creador creador in creadors) {

                    DisplayAlert("Creador: ", "Nombre: " + creador.nombres + "\n Apellidos: " + creador.apellidos, "OK");
                }
            }
        }
    }
}
