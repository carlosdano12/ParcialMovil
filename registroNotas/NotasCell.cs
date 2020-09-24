using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace registroNotas
{
    class NotasCell : ViewCell
    {
        public NotasCell()
        {
            var idAlumnoLable = new Label
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.End
            };
            idAlumnoLable.SetBinding(Label.TextProperty, new Binding("idAlumno"));

            var NombresLabel = new Label
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.Fill
            };
            NombresLabel.SetBinding(Label.TextProperty, new Binding("nombres"));

            var ApellidosLabel = new Label
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.Fill
            };
            ApellidosLabel.SetBinding(Label.TextProperty, new Binding("apellidos"));

            var NotaLabel = new Label
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.Fill
            };
            NotaLabel.SetBinding(Label.TextProperty, new Binding("nota"));

            var FechaPublicacionLabel = new Label
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.Fill
            };
            FechaPublicacionLabel.SetBinding(Label.TextProperty, new Binding("fechaPublicacion"));

            var ActivoSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.End
            };
            ActivoSwitch.SetBinding(Switch.IsToggledProperty, new Binding("estado"));
            View = new StackLayout
            {
                Children = { idAlumnoLable, NombresLabel, ApellidosLabel, NotaLabel, FechaPublicacionLabel, ActivoSwitch },
                Orientation = StackOrientation.Horizontal
            };
        }
    }
}
