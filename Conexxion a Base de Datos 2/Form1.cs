using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Conexxion_a_Base_de_Datos_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_conectar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexionBD = Conexion_MySql.ConexionSql.conexion();
            
            MessageBox.Show("La Conexion fue Exitosa!!!!!!!!!!!!!");
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            string nombre, apellido;
            double cedula;

            nombre = tbx_Nombre.Text;
            apellido = tbx_Apellido.Text;
            cedula = Convert.ToDouble(tbx_Cedula.Text);


            string sql = "INSERT INTO persona2 (Cedula, Nombre, Apellido) VALUES ('" + cedula + "', '" + nombre + "', '" + apellido +"')";
            MySqlConnection conexionBD = Conexion_MySql.ConexionSql.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro Guardado");
                tbx_Cedula.Clear();
                tbx_Nombre.Clear();
                tbx_Apellido.Clear();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
            
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            double cedula = Convert.ToDouble(tbx_Cedula.Text);

            MySqlDataReader reader = null;

            string sql = "SELECT Nombre, Apellido FROM persona2 WHERE cedula LIKE '"+cedula +"' LIMIT 1";

            MySqlConnection conexionBD = Conexion_MySql.ConexionSql.conexion();

            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tbx_Nombre.Text = reader.GetString(0);
                        tbx_Apellido.Text = reader.GetString(1);
                    }
                }
                else
                {
                    MessageBox.Show("No se Encontro esa Cedula");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al Buscar: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }


        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            string nombre, apellido;
            double cedula;

            nombre = tbx_Nombre.Text;
            apellido = tbx_Apellido.Text;
            cedula = Convert.ToDouble(tbx_Cedula.Text);


            string sql = "UPDATE persona2 SET Nombre= '" + nombre + "', Apellido='" + apellido + "'WHERE Cedula='" + cedula + "'";
            MySqlConnection conexionBD = Conexion_MySql.ConexionSql.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro Modificado");
                tbx_Cedula.Clear();
                tbx_Nombre.Clear();
                tbx_Apellido.Clear();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al modificar: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            double cedula;


            cedula = Convert.ToDouble(tbx_Cedula.Text);


            string sql = "DELETE FROM persona2 WHERE Cedula='" + cedula + "'";
            MySqlConnection conexionBD = Conexion_MySql.ConexionSql.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro Borrado");
                tbx_Cedula.Clear();
                tbx_Nombre.Clear();
                tbx_Apellido.Clear();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al borrar: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            tbx_Cedula.Clear();
            tbx_Nombre.Clear();
            tbx_Apellido.Clear();
        }
    }


}
