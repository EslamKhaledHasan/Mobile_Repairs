using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Repairs
{
    internal class Funcation
    {
        private SqlConnection Con;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string ConStr;
        public Funcation()
        {
            ConStr = @"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DELL\\Documents\\MobileRepairDb.mdf;Integrated Security=True;Connect Timeout=30";
            Con = new SqlConnection(ConStr);
            cmd = new SqlCommand();
            cmd.Connection = Con;

        }
        public DataTable GetData(string Query)
        {
            try
            {
                dt = new DataTable();
                sda = new SqlDataAdapter(Query, ConStr);
                sda.Fill(dt);
            }
            catch { }
            return dt;
        }
        public int setData(string Query)
        {
            int cnt = 0;
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            cmd.CommandText = Query;
            cnt = cmd.ExecuteNonQuery();
            return cnt;
        }

    }
}
