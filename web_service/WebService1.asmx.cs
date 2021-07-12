using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace web_service
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        private string _cnnString;

        public WebService1()
        {
            _cnnString = ConfigurationManager.ConnectionStrings["_web_service"].ConnectionString;
        }

        [WebMethod]
        public string eliminar(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_cnnString))
                {
                    SqlCommand comando = new SqlCommand("sp_AlumnoDelete", con);
                    comando.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    comando.Parameters.AddWithValue("id", id);
                    int d = comando.ExecuteNonQuery();
                    con.Close();

                    if (d == 1)
                    {
                        return "Exito en la eliminacion";
                    }
                    else
                    {
                        return "Ningun registro afectado";
                    }
                }


               
            }
            catch
            {
                return "Error en la eliminacion";
            }

        }

        

    }
}
