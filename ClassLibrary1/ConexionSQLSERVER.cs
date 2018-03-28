using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ClassLibrary1
{
   public class ConexionSQLSERVER
    {

        SqlConnection connection;

        public ConexionSQLSERVER()
        {

            connection = new SqlConnection("Data Source=.;Initial Catalog=Almacen;User ID=sa;Password=sa");

        }

        public SqlConnection Conectar()
        {
            try
            {
                Desconectar();
            }
            catch { }

            connection.Open();

            return connection;
        }

        public void Desconectar()
        {
            connection.Close();
        }

        public SqlDataReader Query(String query)
        {
            Conectar();

            SqlCommand comando = new SqlCommand(query, connection);

            return comando.ExecuteReader();
        }

        public void Update(String query)
        {
            Conectar();

            SqlCommand comando = new SqlCommand(query, connection);

            comando.ExecuteNonQuery();

            Desconectar();
        }

       
    }
}
