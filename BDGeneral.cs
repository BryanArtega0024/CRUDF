using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDF
{
    public class BDGeneral
    {

        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DBpersona;Data Source=DESKTOP-A05TUKP\\SQLEXPRESS");
            conexion.Open();
            return conexion;
        }
    }
}
