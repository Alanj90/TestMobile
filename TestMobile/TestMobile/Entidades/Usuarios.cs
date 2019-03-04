namespace TestMobile.Entidades
{
    using System;
    using SQLite.Net.Attributes;

    public class Usuarios
    {
        [PrimaryKey, AutoIncrement]
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public int IdPerfil { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }

        public override string ToString()
        {
            return (IdUsuario.ToString() + " " + Usuario + " " + Nombre + " " + FechaCreacion.ToString());
        }
    }
}
