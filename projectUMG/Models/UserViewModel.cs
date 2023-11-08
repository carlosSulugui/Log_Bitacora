using System.ComponentModel.DataAnnotations;

namespace projectUMG.Models;

public class UserViewModel
{
    public string? Primer_nombre { get; set; }
    public string? Segundo_nombre { get; set; }
    public string? Tercer_nombre { get; set;}
    public string? Primer_apellido { get; set; }
    public string? Segundo_apellido { get; set; }
    public string? Usuario { get; set; }
    public string? User_password { get; set; }
    public string? Fecha_nacimiento { get; set; }
    public string? Estado { get; set; }
    public string? Dpi { get; set; }
    public string? Nit { get; set; }
    public string? Telefono { get; set;}
    public string? Direccion { get; set; }
    public string? Sexo { get; set; }
    [Required]
    public string? Correo { get; set; }
    public string? Token { get; set;  }
    [Required]
    public string? Password { get; set; }
    public string? Foto { get; set; }

}



