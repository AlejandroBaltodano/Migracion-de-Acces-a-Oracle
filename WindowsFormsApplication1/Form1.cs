using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblFecha.Text = DateTime.Now.ToShortDateString() +" "+ DateTime.Now.ToShortTimeString();
        }

       
 private void button5_Click(object sender, EventArgs e)
        {
  ClassLibrary1.ConexionOracle conexionOracle = new ClassLibrary1.ConexionOracle();
  Clases.ConstructoraSQL constructorSQL = new Clases.ConstructoraSQL();
            String procedimientoInsertOracle = String.Empty;
            String procePrueba = String.Empty;

string queryEliminarOracle = "BEGIN DELETE FROM TABLA_EMPLEADO;"+
"DELETE FROM TABLA_PRUEBA;DELETE FROM TABLA_INVENTARIO;END;";


                if (MessageBox.Show("Desea Migrar los Registros de Acces a Oracle?\nNota: Se eliminaran los registros contenidos en las tablas de Oracle", "Informacion Requerida",
      MessageBoxButtons.YesNo, MessageBoxIcon.Question)
      == DialogResult.Yes)
                {
                procedimientoInsertOracle = constructorSQL.MigracionAO("select * from TABLA_EMPLEADO","TABLA_EMPLEADO");
                procedimientoInsertOracle = constructorSQL.MigracionAO("select * from TABLA_PRUEBA", "TABLA_PRUEBA");
                procedimientoInsertOracle = constructorSQL.MigracionAO("select * from TABLA_INVENTARIO", "TABLA_INVENTARIO");
           
                //MessageBox.Show(procePrueba);
                    try
                    {
                       conexionOracle.update(queryEliminarOracle);
                   
 MessageBox.Show("Se eliminaron los registros de las tablas en Oracle", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                    catch (Exception)
                    {
 MessageBox.Show("Problemas al realizar la transaccion de eliminar", "Error del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); ;

                    }
                try
                {
                    conexionOracle.update(procedimientoInsertOracle);
                    MessageBox.Show("Migracion de Acces a Oracle\nRealizada con exito", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {

                    MessageBox.Show("Problemas al realizar la migracion", "Error del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                }

                }
                else
                {
MessageBox.Show("Migracion no realizada", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //proceEmpleado = String.Empty;
                //procePrueba = String.Empty;
            }
            

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir de APPMAOJC?", "Informacion Requerida",
      MessageBoxButtons.YesNo, MessageBoxIcon.Question)
      == DialogResult.Yes)
            {
  Application.Exit();
            }

            /* invocacion de sobrecarga

            ClassLibrary1.ConexionOracle conexion = new ClassLibrary1.ConexionOracle();
            conexion.prueba(1);
            conexion.prueba(1, 2);
          */
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
