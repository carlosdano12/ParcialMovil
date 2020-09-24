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
    public partial class RegistroAlumno : ContentPage
    {
        private Usuario usuario;
        readonly NotasManager notasManager = new NotasManager();
         List<Notas> notas = new List<Notas>();
        public  RegistroAlumno(Usuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
            btnAgregar.Clicked += btnAgregar_Clicked;
            lvLista.ItemSelected += lvLista_ItemSelected;
            lvLista.ItemTemplate = new DataTemplate(typeof(NotasCell));
            llenaLista();
        }

        public async void llenaLista()
        {
            notas = new List<Notas>();
            var notaList = await notasManager.GetAll(this.usuario.id);
            
            foreach (Notas nota in notaList)
            {

                notas.Add(nota);
                
                
            }
            lvLista.ItemsSource = notas;
        }

        private void lvLista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new EditarAlumno(usuario, (Notas)e.SelectedItem));
        }

        public async void btnAgregar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entNombres.Text))
            {
                await DisplayAlert("Error", "Debe ingresar nombres", "Aceptar");
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
                await DisplayAlert("Error", "Debe ingresar nota", "Aceptar");
                entNota.Focus();
                return;
            }
            Console.WriteLine("Aqui");

            Notas alumno = new Notas()
            {
                idAlumno = 0,
                id_usuario = this.usuario.id,
                nombres = entNombres.Text,
                apellidos = entApellidos.Text,
                nota = decimal.Parse(entNota.Text),
                fechaPublicacion = dtpFechaPublicacion.Date,
                estado = SwEstado.IsToggled
            };
            
            var result = await notasManager.Add(alumno);
            
            Notas nota = (Notas)result;
            if (nota.idAlumno != 0)
            {
                llenaLista();
                
            }
            else
            {

                await DisplayAlert("Registro fallo", "No se pudo registrar la Nota", "OK");
            }
            entNombres.Text = string.Empty;
            entApellidos.Text = string.Empty;
            entNota.Text = string.Empty;
            dtpFechaPublicacion.Date = DateTime.Now;
            llenaLista();
            await DisplayAlert("Mensaje", "Alumno creado correctamente", "Aceptar");
        }
    }
}