using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccConSys
{
    public class SqlHelper
    {
        //读取配置文件，获得连接字符串
        public static readonly string connStr = ConfigurationManager.ConnectionStrings["connacs"].ConnectionString;

        //执行增删改
        public static int ExecuteNonQuery(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        //封装返回单个值
        public static object ExecuteScalar(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        //读取值
        public static SqlDataReader ExecuteReader(string sql)
        {
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                con.Close();
                return cmd.ExecuteReader();
            }
        }

        //
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] pms)
        {
            //根据连接字符串创建连接对象
            using (SqlConnection con = new SqlConnection(connStr))
            {
                //创建adapter对象，用于执行查询
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                //添加参数
                adapter.SelectCommand.Parameters.AddRange(pms);
                DataTable dt = new DataTable();
                adapter.Fill(dt);//将数据库中的数据存到adapter
                return dt;//返回数据
            }
        }
    }
}
