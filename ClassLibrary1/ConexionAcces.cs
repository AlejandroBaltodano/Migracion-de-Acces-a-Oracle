using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace ClassLibrary1
{
    public class ConexionAcces
    {
        OleDbConnection connection;

        public ConexionAcces()
        {

            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Creyes/Documents/PruebaMigracion.accdb");

        }

        public OleDbConnection Conectar()
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


        public void Update(String query)
        {
            Conectar();

            OleDbCommand comando = new OleDbCommand(query, connection);

            comando.ExecuteNonQuery();

            Desconectar();
        }
   
        public DataSet obtenerRegistrosAcces(String query, string tabla)
        {
            Conectar();

            OleDbCommand comando = new OleDbCommand(query, connection);

            comando.CommandTimeout = 0;

            OleDbDataAdapter adapter = new OleDbDataAdapter(comando);

            DataSet ds = new DataSet();

            adapter.Fill(ds, tabla);

            return ds;

        }







    }
}
