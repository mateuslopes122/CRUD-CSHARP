using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace WFGrravarDadosMySql
{
    public partial class Form1 : Form
    {
        private MySqlConnection Conexao;
        private string data_source = "datasource=localhost;username=root;password=;database=db_agenda;";
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                Conexao = new MySqlConnection(data_source);

                string sql = "INSERT INTO contato (nome,email,telefone)"+
                    "VALUES "+
                    "('"+txtNome.Text+"','"+txtEmail.Text+"' ,'"+txtTelefone.Text+"')";

                MySqlCommand comando = new MySqlCommand(sql, Conexao);
                Conexao.Open();
                comando.ExecuteReader();

                MessageBox.Show("Cadastro feito com sucesso!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conexao.Close();
            }




            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Conexao = new MySqlConnection(data_source);

                string q = " '%" + txtBuscar.Text + "%' ";


                string sql = "SELECT * FROM contato WHERE nome LIKE"+q+"OR email LIKE"+q;

                MySqlCommand comando = new MySqlCommand(sql, Conexao);

                Conexao.Open();
                MySqlDataReader reader = comando.ExecuteReader();

                lstContato.Items.Clear();

                while (reader.Read())
                {
                    string[] row =
                    {
                        reader.GetString(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    };

                    var linhaListView = new ListViewItem(row);
                    lstContato.Items.Add(linhaListView);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conexao.Close();
            }
        }
    }
}
