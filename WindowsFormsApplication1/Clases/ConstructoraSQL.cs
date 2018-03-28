using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Clases
{
   public class ConstructoraSQL
    {

        String insertSQL = String.Empty;
        String procedimientoFinal = String.Empty;
      
        public String insertBuilder(string table, List<KeyValuePair<string, string>> values)
        {
            String sql = String.Empty;
            String columns = String.Empty;
            String vals = String.Empty;


            sql = "INSERT INTO " + table;
            columns += "( ";
            vals += "( ";
            int contador = 0;
            foreach (KeyValuePair<string, string> keyVal in values)
            {
                var coma = (contador == 0) ? " " : ", ";
                columns += coma + keyVal.Key;
                vals += coma + keyVal.Value;
                contador += 1;
            }
            columns += " ) VALUES";
            vals += " ); ";

            sql += columns + vals;
            return sql;
        }


        public String MigracionAO(string queryAcces,string nombreTablaAcces) {

            ClassLibrary1.ConexionAcces conexion = new ClassLibrary1.ConexionAcces();
           ClassLibrary1.ConexionOracle conexionOracle = new ClassLibrary1.ConexionOracle();

            //dataset que se utiliza para meter los registros que viene de la queryACCES y tabla
            var dsConsultaSQL = conexion.obtenerRegistrosAcces(queryAcces, nombreTablaAcces);
  //en este datatable se meteran los registros que vienen del dataset, esto para poder sacar las filas y columnas
            DataTable dataTabla = dsConsultaSQL.Tables[0];
  //variable para meter los registros del dataset, se utilizara para cuantos registros hay en en data set
            var listaTabla = dataTabla.Select(null, null, DataViewRowState.CurrentRows);


            if (listaTabla.Count() < 1)
            {
MessageBox.Show("No hay registros en la Base de Datos Acces", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                insertSQL = String.Empty;
            }
            else
            {

                string comilla = "'";
                List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();

                foreach (DataRow row in dataTabla.Rows)
                {
                    foreach (DataColumn column in dataTabla.Columns)
                    {

                        values.Add(new KeyValuePair<string, string>(
                            column.ColumnName,
                            comilla + row[column].ToString() + comilla
                            ));

                    }//fin foreachcolumnas
                    insertSQL += insertBuilder(nombreTablaAcces, values) + "\n";
                    values.Clear();



                }//fin foreach filas



            }//fin else



            procedimientoFinal = "BEGIN " + insertSQL + " END;";

            return procedimientoFinal;
        }





    }
}
