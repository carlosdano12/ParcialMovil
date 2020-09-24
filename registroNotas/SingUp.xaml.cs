using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace registroNotas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SingUp : ContentPage
    {
        readonly UsuarioManager usuarioManager = new UsuarioManager();
        public SingUp()
        {
            InitializeComponent();
        }

        private async void resgistro_Clicked(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string correo = txtCorreo.Text;
            string contraseña = txtConstraseña.Text;

            var result = await usuarioManager.Add(nombre, apellido, correo, contraseña);
            Usuario usuario = (Usuario)result;
            if (usuario.id != 0)
            {
                await DisplayAlert("Registro", "Registrado Exitosamente", "OK");
                await Navigation.PushAsync(new RegistroAlumno(usuario));
            }
            else {

                await DisplayAlert("Registro fallo", "No se pudo rigistrar como un usuarios, esposible que ya exista una cuenta con ese correo", "OK");
            }
        }
    }
}