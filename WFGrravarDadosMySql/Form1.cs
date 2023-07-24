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

            lstContato.View = View.Details;
            lstContato.AllowColumnReorder = true;
            lstContato.FullRowSelect = true;
            lstContato.GridLines = true;

            lstContato.Columns.Add("ID", 30, HorizontalAlignment.Center);
            lstContato.Columns.Add("Nome", 150, HorizontalAlignment.Center);
            lstContato.Columns.Add("Email", 150, HorizontalAlignment.Center);
            lstContato.Columns.Add("Telefone", 150, HorizontalAlignment.Center);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                Conexao = new MySqlConnection(data_source);

                Conexao.Open();

                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = Conexao;

                cmd.CommandText = "INSERT INTO contato (nome,email,telefone) VALUES(@nome,@email,@telefone)";

                
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@email", txtNome.Text);
                cmd.Parameters.AddWithValue("@telefone", txtNome.Text);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

                MessageBox.Show("Contato inserido com sucesso!", "sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Erro Ocorreu" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
