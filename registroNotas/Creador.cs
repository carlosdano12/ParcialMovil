using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;
using SQLite.Net.Interop;

namespace registroNotas
{
    public class Creador
    {
        [PrimaryKey, AutoIncrement]
        public int idCreador { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }

        public override string ToString()
        {
            return string.Format("{0}{1}",
                 nombres, apellidos);
        }
    }
}
