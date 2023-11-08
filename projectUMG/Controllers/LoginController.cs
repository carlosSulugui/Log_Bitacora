using Microsoft.AspNetCore.Mvc;
using projectUMG.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using projectUMG.Data;


namespace projectUMG.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly DbContext _context;


        public LoginController(DbContext context, ILogger<LoginController> logger)
        {
            _context = context;
            _logger = logger;
        }




        [HttpPost]
        public ActionResult Add (UserViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SqlConnection con = new(_context.Value))
                    {
                        using (SqlCommand com = new("sp_RegistrarUsuario", con))
                        {
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.Add("@primer_nombre", SqlDbType.VarChar).Value = user.Primer_nombre;
                            com.Parameters.Add("@segundo_nombre", SqlDbType.VarChar).Value = user.Segundo_nombre;
                            com.Parameters.Add("@tercer_nombre", SqlDbType.VarChar).Value = user.Tercer_nombre;
                            com.Parameters.Add("@primer_apellido", SqlDbType.VarChar).Value = user.Primer_apellido;
                            com.Parameters.Add("@segundo_nombre", SqlDbType.VarChar).Value = user.Segundo_apellido;
                            com.Parameters.Add("@fecha_nacimiento", SqlDbType.VarChar).Value = user.Fecha_nacimiento;
                            com.Parameters.Add("@estado", SqlDbType.VarChar).Value = user.Estado;
                            com.Parameters.Add("@dpi", SqlDbType.VarChar).Value = user.Dpi;
                            com.Parameters.Add("@nit", SqlDbType.VarChar).Value = user.Nit;
                            com.Parameters.Add("@telefono", SqlDbType.VarChar).Value = user.Telefono;
                            com.Parameters.Add("@direccion", SqlDbType.VarChar).Value = user.Direccion;
                            com.Parameters.Add("@sexo", SqlDbType.VarChar).Value = user.Sexo;
                            com.Parameters.Add("@correo", SqlDbType.VarChar).Value = user.Correo;
                            com.Parameters.Add("@user_password", SqlDbType.VarChar).Value = user.User_password;
                            com.Parameters.Add("@usuario", SqlDbType.VarChar).Value = user.Usuario;
                            com.Parameters.Add("@foto", SqlDbType.Image).Value = user.Foto;
                            string token = Guid.NewGuid().ToString();
                            com.Parameters.Add("@token", SqlDbType.VarChar).Value = token;
                            com.Parameters.Add("@password", SqlDbType.VarChar).Value = user.Password;

                            //mandar el email

                            con.Open();
                            com.ExecuteNonQuery();
                            Email email = new();

                            if (user.Correo != null) email.Send(user.Correo, token);


                            con.Close();

                        }
                    }

                    return RedirectToAction("Token", "Home");
                }
            }
            catch (Exception e)
            {
                ViewData["Error"] = e.Message;
                return View();
            }

            return View();
        }

        public ActionResult Token()
        {
            string token = Request.Query["value"];
            if (token != null)
            {

            }
            else
            {
                ViewData["Error"] = "Token no valido";
                return View();
            }

            return View();
        }
    }
}





