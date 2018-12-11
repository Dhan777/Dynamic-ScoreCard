using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplication10.Models
{
    public class DataLaye
    {
        private string _con;
        SqlConnection Con;
        public DataLaye()
        {
            Connection();
        }
        private void Connection()
        {
            _con = ConfigurationManager.ConnectionStrings["DataLaye"].ToString();
            Con = new SqlConnection(_con);
            if (System.Data.ConnectionState.Open == Con.State)
            {
                Con.Close();
            }
            Con.Open();
        }

        public dynamic GetData()
        {
            var lst = SqlMapper.Query<dynamic>(Con, "Proc_Demo", commandType: CommandType.StoredProcedure);
            return lst;
        }

        public object GetData2()
        {
            var lst = SqlMapper.Query<dynamic>(Con, "Proc_Demo", commandType: CommandType.StoredProcedure);
            return lst;
        }

        public DataTable GetData3()
        {
            SqlCommand cmd = new SqlCommand("Proc_Demo", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd;
            ad.Fill(dt);
            return dt;
        }

        public DataTable GetColumns()
        {
            SqlCommand cmd = new SqlCommand("Proc_GetColumns", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd;
            ad.Fill(dt);
            return dt;
        }

        public IEnumerable<ColumnMapping> GetColumns2()
        {
            try
            {
                var lst = SqlMapper.Query<ColumnMapping>(Con, "Proc_GetColumns", commandType: CommandType.StoredProcedure).ToList();
                return lst;
            }
            catch (Exception E)
            {
                return null;
            }
        }

        public IEnumerable<ColorMapping> GetColors()
        {
            try 
            {
                var lst = SqlMapper.Query<ColorMapping>(Con, "Proc_ColorMapping", commandType: CommandType.StoredProcedure).ToList();
                return lst;
            }
            catch (Exception E) { return null; }
        }
    }
}