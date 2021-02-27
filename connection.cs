using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class connection
    {
        private MySqlConnection cn;
        private MySqlCommand cmd;

        public connection()
        {
            cn = new MySqlConnection();
            cmd = new MySqlCommand();
        }

        private bool openConnection()
        {
            try
            {
                if (cn.State != System.Data.ConnectionState.Open)
                {
                    string strCon = @"server=den1.mysql5.gear.host;user id=coodaax;database=coodaax;persistsecurityinfo=True;Pwd=HMB!1234";
                    cn = new MySqlConnection(strCon);
                    cn.Open();
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (MySqlException myex)
            {
                Console.WriteLine("DB ERROR " + myex.Message);
                return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query">The query to execute at db</param>
        /// <returns></returns>
        public bool execQuery(string query)
        {
            try
            {
                if (openConnection())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (MySqlException myex)
            {
                Console.WriteLine("DB Error " + myex.Message);
                return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Generic error " + ex.Message);
                return false;
            }
            finally
            {
                if(cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }



    }
}
