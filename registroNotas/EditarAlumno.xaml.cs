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
    public partial class EditarAlumno : ContentPage
    {
        private Usuario usuario;
        private Notas nota;
        readonly NotasManager notasManager = new NotasManager();
        public EditarAlumno(Usuario usuario, Notas nota)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.nota = nota;
            btnActualizar.Clicked += btnActualizar_Clicked;
            btnBorrar.Clicked += btnBorrar_Clicked;
            entNombres.Text = nota.nombres;
            entApellidos.Text = nota.apellidos;
            entNota.Text = nota.nota.ToString();
            dtpFechaPublicacion.Date = nota.fechaPublicacion;
            SwEstado.IsToggled = nota.estado;
        }

        public async void btnBorrar_Clicked(object sender, EventArgs e)
        {
            var rta = await DisplayAlert("Confirmación", "¿Desea Borrar el Alumno?", "Si", "No");
            if (!rta) return;

            await notasManager.delete(nota.idAlumno);
            
            await DisplayAlert("Confirmación", "Alumno borrado correctamente", "Aceptar");
            await Navigation.PushAsync(new RegistroAlumno(usuario));
        }

        public async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entNombres.Text))
            {
                await DisplayAlert("Error", "Debe ingresar Nombres", "Aceptar");
                entNombres.Focus();
                return;
            }

            if (string.IsNullOrEmpty(entApellidos.Text))
            {
                await DisplayAlert("Error", "Debe ingresar Apellidos", "Aceptar");
                entApellidos.Focus();
                return;
            }

            if (string.IsNullOrEmpty(entNota.Text))
            {
                await DisplayAlert("Error", "Debe ingresar Nota", "Aceptar");
                entNota.Focus();
                return;
            }

            Notas alumno = new Notas()
            {
                idAlumno = this.nota.idAlumno,
                id_usuario = this.usuario.id,
                nombres = entNombres.Text,
                apellidos = entApellidos.Text,
                nota = decimal.Parse(entNota.Text),
                fechaPublicacion = dtpFechaPublicacion.Date,
                estado = SwEstado.IsToggled
            };

            await notasManager.update(alumno);
            
            await DisplayAlert("Confirmación", "Alumno modificado", "Aceptar");
            await Navigation.PushAsync(new RegistroAlumno(usuario));
        }
    }
}