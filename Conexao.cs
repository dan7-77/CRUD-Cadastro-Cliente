using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro_de_Cliente
{
    internal class Conexao
    {
        MySqlConnection conn;
        public void ConectarBD()
        {
            try
            {
                conn = new MySqlConnection("Persist Security info = false;server = localhost;database = bdEmpresa; user = root; pwd =;");



                
            
              conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro ao conectar: " + e.Message);
            }
        }
        public int ExecutarComandos(string sql)
        {
            int resultado;
            try
            {
                ConectarBD();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                resultado = 1;
            }
            catch (Exception)
            {
                resultado = 0;
                throw;
            }
            finally
            {
                conn.Close();
            }
            return resultado;
        }
        public DataTable ExecutarConsulta(string sql)
        {
            try
            {
                ConectarBD();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
            

