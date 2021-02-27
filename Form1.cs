using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bt_search_Click(object sender, EventArgs e)
        {
            try
            {
                //String de Conexão
                string strCon = @"server=den1.mysql5.gear.host;user id=coodaax;database=coodaax;persistsecurityinfo=True;Pwd=HMB!1234";
                //Conexão
                MySqlConnection cn = new MySqlConnection(strCon);

                //Abre a DB
                cn.Open();

                //Seleciona os dados da DB
                MySqlCommand comm = new MySqlCommand("select * from inventariopc where asset = ?", cn);

                //Limpa os Parametros
                comm.Parameters.Clear();
                //Define os Parametros
                comm.Parameters.Add("@asset", MySqlDbType.Int32).Value = int.Parse(txt_search.Text);

                //Executa o comando
                comm.CommandType = CommandType.Text;

                //Recebe o conteudo que vem do banco.
                MySqlDataReader dr;
                dr = comm.ExecuteReader();
                dr.Read();

                txt_asset.Text = txt_search.Text;
                txt_serial.Text = dr.GetString(1);
                txt_mac.Text = dr.GetString(2);
                txt_ip.Text = dr.GetString(3);
                txt_user.Text = dr.GetString(4);
                txt_hmc.Text = dr.GetString(5);

                cn.Close();
            } catch(Exception erro)
            {
                MessageBox.Show("Erro ao buscar o registro: " + erro);
            }
        }

        private void bt_edit_Click(object sender, EventArgs e)
        {
            DialogResult resultEdit = MessageBox.Show("Você tem certeza que deseja Editar? Isso ira substituir as informações do computador atual!", "Editando", MessageBoxButtons.YesNo);
            if(resultEdit == DialogResult.Yes)
            {
                try
                {
                    string strCon = @"server=den1.mysql5.gear.host;user id=coodaax;database=coodaax;persistsecurityinfo=True;Pwd=HMB!1234";
                    MySqlConnection cn = new MySqlConnection(strCon);
                    cn.Open();
                    MySqlCommand comm = new MySqlCommand("update inventariopc set serialNumber = ?, macAdress = ?, ip = ?, username = ?, hmc = ? where asset = ?", cn);
                    comm.Parameters.Clear();
                    comm.Parameters.Add("@serialNumber", MySqlDbType.VarChar, 15).Value = txt_serial.Text;
                    comm.Parameters.Add("@macAdress", MySqlDbType.VarChar, 17).Value = txt_mac.Text;
                    comm.Parameters.Add("@ip", MySqlDbType.VarChar, 14).Value = txt_ip.Text;
                    comm.Parameters.Add("@username", MySqlDbType.VarChar, 60).Value = txt_user.Text;
                    comm.Parameters.Add("@hmc", MySqlDbType.VarChar, 8).Value = txt_hmc.Text;
                    comm.Parameters.Add("@asset", MySqlDbType.Int32).Value = int.Parse(txt_asset.Text);
                    comm.CommandType = CommandType.Text;
                    comm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("As informações do Computador " + int.Parse(txt_asset.Text) + " Foram alteradas");

                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao alterar Registros: " + erro);
                }
            }
        }

        private void bt_remove_Click(object sender, EventArgs e)
        {
            DialogResult resultRemove = MessageBox.Show("Você tem certeza que deseja Excluir? Essa operação Deletará as informações do computador e não podera ser Desfeitas!", "Editando", MessageBoxButtons.YesNo);
            if (resultRemove == DialogResult.Yes)
            {
                try
                {
                    string strCon = @"server=den1.mysql5.gear.host;user id=coodaax;database=coodaax;persistsecurityinfo=True;Pwd=HMB!1234";
                    MySqlConnection cn = new MySqlConnection(strCon);
                    cn.Open();
                    MySqlCommand comm = new MySqlCommand("delete from inventariopc where asset = ?", cn);
                    comm.Parameters.Clear();
                    comm.Parameters.Add("@asset", MySqlDbType.Int32).Value = int.Parse(txt_search.Text);
                    comm.CommandType = CommandType.Text;
                    comm.ExecuteNonQuery();
                    cn.Close();
                    txt_asset.Clear();
                    txt_hmc.Clear();
                    txt_ip.Clear();
                    txt_mac.Clear();
                    txt_serial.Clear();
                    txt_user.Clear();
                    MessageBox.Show("As informações do Computador " + int.Parse(txt_search.Text) + " Foram Deletadas");
                }
                catch(Exception erro)
                {
                    MessageBox.Show("Erro ao deletar Registro: " + erro);
                }
                
            }
        }
    }
}
