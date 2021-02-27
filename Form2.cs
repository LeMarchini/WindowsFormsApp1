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

        private void btCriar_Click(object sender, EventArgs e)
        {
            string strCon = @"server=den1.mysql5.gear.host;user id=coodaax;database=coodaax;persistsecurityinfo=True;Pwd=HMB!1234";
            MySqlConnection cn = new MySqlConnection(strCon);
            cn.Open();
            MySqlCommand comm = new MySqlCommand();
            comm.Connection = cn;
            comm.CommandText = "insert into inventariopc values ('"+int.Parse(txtAsset.Text)+"','"+txtSerialNumber.Text+"','"+txtMac.Text+"','"+txtIp.Text+"','"+txtUser.Text+"','"+txtHmc.Text+"')";
            comm.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("O Computador foi inserido no banco de dados");
            this.Close();


        }
    }
}
