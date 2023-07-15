namespace ZoologicoApiWeb.Models
{
    public class Registro
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Contraseña { get; set; }

        // Otros campos de registro que puedas necesitar
    }

    public class Usuario : Registro
    {
        public string? NombreUsuario { get; set; }
        public string? Contrasena { get; set; }

        // Otros campos de usuario que puedas necesitar
    }
}

