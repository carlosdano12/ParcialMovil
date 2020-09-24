using System;
using System.Collections.Generic;
using System.Text;

namespace registroNotas
{
    public class Notas
    {
        public int idAlumno { get; set; }

        public int id_usuario { get; set; }

        public string nombres { get; set; }

        public string apellidos { get; set; }

        public DateTime fechaPublicacion { get; set; }

        public Decimal nota { get; set; }

        public bool estado { get; set; }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}{3}{4}", 
                idAlumno, id_usuario, nombres, apellidos, fechaPublicacion, nota, estado);
        }
    }
}
