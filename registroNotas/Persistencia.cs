using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;
using SQLite.Net;
using System.IO;
using Xamarin.Forms;
using System.Linq;


namespace registroNotas
{
    class Persistencia : IDisposable
    {
        private SQLiteConnection conexion;

        public Persistencia()
        {
            var config = DependencyService.Get<Iconfig>();
            conexion = new SQLiteConnection(config.Plataforma, Path.Combine(config.DirectorioDB, "Creadores.db3"));
            conexion.CreateTable<Creador>();
            Creador creador1 = new Creador()
            {
                nombres = "Jose David",
                apellidos = "Chagui Ahumada"
            };
            Creador creador2 = new Creador()
            {
                nombres = "Carlos Daniel",
                apellidos = "Salazar Lopez"
            };
            //conexion.Insert(creador1);
            //conexion.Insert(creador2);
            //conexion.Delete(creador1);
        }

        public void insertAlumno(Creador creador)
        {
            conexion.Insert(creador);
        }

        public void UpdateAlumno(Creador creador)
        {
            conexion.Update(creador);
        }

        public void DeleteAlumno(Creador creador)
        {
            conexion.Delete(creador);
        }

        public Creador GetAlumno(int IDcreador)
        {
            return conexion.Table<Creador>().FirstOrDefault(c => c.idCreador == IDcreador);
        }

        public List<Creador> GetAlumno()
        {
            return conexion.Table<Creador>().OrderBy(c => c.apellidos).ToList();
        }

        public void Dispose()
        {
            conexion.Dispose();
        }
    }
}
