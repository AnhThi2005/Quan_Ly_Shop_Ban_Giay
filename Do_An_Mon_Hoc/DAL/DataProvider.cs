using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Mon_Hoc.DAL
{
    internal class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                }
                return instance;
            }
            private set => instance = value;
        }

        private string connectionStr = "Data Source=DESKTOP-AOPR4T6\\SQLEXPRESS;Initial Catalog=Moi;Integrated Security=True;";
        public DataTable excuteReader(string query, List<object> parameters = null)
        {
            DataTable table = new DataTable();

            SqlConnection connection = new SqlConnection(connectionStr);

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            if (parameters != null)
            {
                int i = 0;
                string[] words = query.Split(' ');
                foreach (string word in words)
                {
                    if (word.Contains('@'))
                    {
                        if (i < parameters.Count)
                        {
                            command.Parameters.AddWithValue(word, parameters[i]);
                            i++;
                        }
                    }
                }
            }

            SqlDataAdapter adaper = new SqlDataAdapter(command);

            adaper.Fill(table);

            connection.Close();

            return table;
        }

        public object executeScalar(string query, List<object> parameters = null)
        {
            object result = null;

            SqlConnection connection = new SqlConnection(connectionStr);

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            // Detect cac ten tham so va gia tri cua no
            if (parameters != null)
            {
                string[] words = query.Split(' ');
                int i = 0;
                foreach (string word in words)
                {
                    if (word.Contains('@')) // tu co chua ky tu @ la parameterName
                    {
                        command.Parameters.AddWithValue(word, parameters[i]);
                        i++; // tang index len 1 don vi
                    }
                }
            }
            result = command.ExecuteScalar();

            connection.Close();

            return result;
        }

        public int executeNonQuery(string query, List<object> parameters = null)
        {
            int result = 0;


            SqlConnection connection = new SqlConnection(connectionStr);

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            if (parameters != null)
            {
                int i = 0;
                string[] words = query.Split(' ', '=', '(', ')', ',');
                foreach (string word in words)
                {
                    if (word.Contains('@'))
                    {
                        command.Parameters.AddWithValue(word, parameters[i]);
                        i++;
                    }
                }
            }

            result = command.ExecuteNonQuery();

            connection.Close();

            return result;
        }
    }
}
