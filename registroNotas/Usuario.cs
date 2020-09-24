using System;
using System.Collections.Generic;
using System.Text;

namespace registroNotas
{
    public class Usuario
    {

        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }

        public override string ToString()
        {
            return id + " " + nombre + " " + apellido;
        }
    }
}
