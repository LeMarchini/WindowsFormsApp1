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
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }
        connection con = new connection();

        private bool computerInsert()
        {
            string query = @"insert into inventariopc values ('" + int.Parse(txtAsset.Text) + "','" + txtSerialNumber.Text + "','" + txtMac.Text + "','" + txtIp.Text + "','" + txtUser.Text + "','" + txtHmc.Text + "')";
            if (con.execQuery(query))
            {
                MessageBox.Show("O Computador foi inserido no banco de dados");
            }
            else
            {
                MessageBox.Show("Ocorreu um erro durante a inserção do computador", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




            return true;
        }

        private void btCriar_Click(object sender, EventArgs e)
        {
            computerInsert();
        }

        private void txtMac_KeyPress(object sender, KeyPressEventArgs e)
        {

                if(txtMac.TextLength == 2)
                {
                    txtMac.Text = txtMac.Text + ":";
                }
                


        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }
    }
}
