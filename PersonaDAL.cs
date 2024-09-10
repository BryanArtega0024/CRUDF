using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDF
{
    public class PersonaDAL
    {
        public static int AgregarPersona(Persona persona)
        {
            int retorna = 0;
            using (SqlConnection conexion = BDGeneral.ObtenerConexion())
            {
                string query = "insert into persona (nombre,edad,celular) values('" + persona.nombre + "'," + persona.edad + ",'" + persona.celular + "')";
                SqlCommand command = new SqlCommand(query, conexion);

                retorna = command.ExecuteNonQuery();
            }
            return retorna;
        }


        public static List<Persona> PresentarRegistro()
        {
            List<Persona> Lista = new List<Persona>();

            using (SqlConnection conexion = BDGeneral.ObtenerConexion())
            {
                string query = "select * from persona ";

                SqlCommand comando = new SqlCommand(query, conexion);


                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read()) {

                    Persona persona = new Persona();
                    persona.id = reader.GetInt32(0);
                    persona.nombre = reader.GetString(1);
                    persona.edad = reader.GetInt32(2);
                    persona.celular = reader.GetString(3);
                    Lista.Add(persona);


                }
                conexion.Close();
                return Lista;


            }

        }

        public static int ModificarPersona(Persona persona)
        {

            int result = 0;

            using (SqlConnection conexion = BDGeneral.ObtenerConexion()) 
            { 

            string query = "update persona set nombre='" + persona.nombre+"', edad=" + persona.edad + ",celular = '" + persona.celular + "' where id = "+persona.id + "  ";

                SqlCommand command = new SqlCommand(query,conexion);

                result = command.ExecuteNonQuery();
                conexion.Close();
             }
            return result;
        }

        public static int EliminarPersona(int id)
        {
            int retorna = 0;
            using (SqlConnection conexion = BDGeneral.ObtenerConexion())
            {
                string query = "delete from persona where id = " + id  + "";
                SqlCommand command = new SqlCommand(query, conexion);

                retorna = command.ExecuteNonQuery();
            }
            return retorna;
        }

    }
}
