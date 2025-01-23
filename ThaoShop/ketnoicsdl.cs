using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace ThaoShop
{
    
    
        public class ketnoicsdl
        {
            SqlConnection conn;

            public ketnoicsdl()
            {
                string str = "Data Source=DESKTOP-9BAJ70V\\SQLEXPRESS;Initial Catalog=QLQA;Integrated Security=True";
                conn = new SqlConnection(str);
            }

            public string GetConnectionString()
            {
                return conn.ConnectionString;
            }

            public DataTable Execute(string query)
            {
                DataTable dt = new DataTable();
                openConection();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                closeConection();
                return dt;
            }

            public void ExecuteNonQuery(string query)
            {
                openConection();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                closeConection();
            }

            public void openConection()
            {
                if (ConnectionState.Closed == conn.State)
                {
                    try
                    {
                        conn.Open();
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi kết nối");
                    }
                }
            }

            public void closeConection()
            {
                if (ConnectionState.Open == conn.State)
                {
                    try
                    {
                        conn.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi kết nối");
                    }
                }
            }

            public DataTable getLogin(string query, string user, string pass)
            {
                DataTable dt = new DataTable();
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@TaiKhoan", user);
                cmd.Parameters.AddWithValue("@MatKhau", pass);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                conn.Close();
                return dt;
            }


            public void ExecuteStoredProcedure(string storedProcedure, Dictionary<string, object> parameters)
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProcedure;

                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }

                cmd.ExecuteNonQuery();
                conn.Close();
            }

        }
    }

