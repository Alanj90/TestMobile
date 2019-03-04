namespace TestMobile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using SQLite.Net;
    using Xamarin.Forms;
    using Entidades;

    class DataAccess : IDisposable
    {
        private SQLiteConnection connection;

        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            connection = new SQLiteConnection(config.Plataforma, Path.Combine(config.DirectorioDB, "TestDB.db3"));
            connection.CreateTable<Usuarios>();
        }

        public void Insert_Usuario(Usuarios usuario)
        {
            connection.Insert(usuario);
        }

        public void Update_Usuario(Usuarios usuario)
        {
            connection.Update(usuario);
        }

        public void Delete_Usuario(Usuarios usuario)
        {
            connection.Delete(usuario);
        }

        public Usuarios Search_Usuario(string usuario)
        {
            return connection.Table<Usuarios>().FirstOrDefault(u => u.Usuario == usuario);
        }

        public List<Usuarios> Report_Usuario()
        {
            return connection.Table<Usuarios>().OrderBy(u => u.IdUsuario).ToList();
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
