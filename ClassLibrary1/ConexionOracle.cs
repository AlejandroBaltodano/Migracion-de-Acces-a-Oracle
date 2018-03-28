using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace ClassLibrary1
{
    public class ConexionOracle
    {
        string conexionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        OracleConnection conexion;

        public ConexionOracle()
        {
            conexion = new OracleConnection(conexionString);


        }

        public OracleConnection Conectar() {

            try
            {
                Desconectar();
            }
            catch (Exception)
            {

                throw;
            }
            conexion.Open();
            return conexion;

        }

        public void Desconectar() {

            conexion.Close();
        }

        public void update(string query ) {
            Conectar();
            OracleCommand sql = new OracleCommand(query, conexion);
            OracleDataAdapter dataAdapter = new OracleDataAdapter();
            dataAdapter.InsertCommand = sql;
            dataAdapter.InsertCommand.ExecuteNonQuery();
            Desconectar();
           


        }
        /* ejemplo de sobrecarga en c#
        public int prueba(int numero) {

            return numero;
                }

        public int prueba( int numero, int numero2) {

            return numero + numero2;

        }*/





    }
}
