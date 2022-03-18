using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//数据库操作的工具类

namespace DAL
{
    public class DAUtils
    {
        private string connstring = null;
        static private SqlConnection sqlConnection = null;
        SqlCommand sqlCommand;
        static private DAUtils dAUtils = null;
        private DAUtils()
        {
            connstring = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            sqlConnection = new SqlConnection(connstring);
        }
        public static DAUtils GetDAUtils()//单例模式，不用实例化对象
        {
            if (dAUtils == null)
                dAUtils = new DAUtils();
            if(sqlConnection.State==ConnectionState.Open)
                sqlConnection.Close();
            sqlConnection.Open();
            return dAUtils;
        }
        public int cud(string sql,SqlParameter[] parameters)//c->增加，u->修改，d->删除
        {
            sqlCommand = new SqlCommand(sql, sqlConnection);
            if (parameters.Length > 0)
            {
                foreach(SqlParameter parameter in parameters)
                {
                    sqlCommand.Parameters.Add(parameter);
                }
            }
            int n=sqlCommand.ExecuteNonQuery();//只对UPDATE、INSERT 和 DELETE 语句有效，其他类型语句返回-1
            sqlConnection.Close();
            sqlCommand.Parameters.Clear();
            return n;
        }

        public int cud(string sql)  //无参数插入，作为有参的特殊情形，方法重载
        {
            return cud(sql, new SqlParameter[] { });  //调用有参插入方法
        }
        //获取查询select执行结果的第一行第一列
        public Object SingleQuery(string sql,SqlParameter[] parameters)
        {
            sqlCommand = new SqlCommand(sql, sqlConnection);
            if (parameters.Length > 0)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    sqlCommand.Parameters.Add(parameter);
                }
            }
            object obj= sqlCommand.ExecuteScalar();
            sqlConnection.Close();
            sqlCommand.Parameters.Clear();
            return obj;
        }
        public Object SingleQuery(string sql)
        {
            SqlParameter[] parameters = { };
            return SingleQuery(sql, parameters);
        }
        //返回查询结果的DataTable数据结构
        public DataTable GetRecords(string sql,SqlParameter[] parameters)
        {
            sqlCommand = new SqlCommand(sql, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            if (parameters.Length > 0)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    sqlDataAdapter.SelectCommand.Parameters.Add(parameter);
                }
            }
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            sqlCommand.Parameters.Clear();
            return dataTable;
        }
        public DataTable GetRecords(string sql)  //无参查询—作为有参的特殊情形
        {
            SqlParameter[] parameters = { };
            return GetRecords(sql, parameters);
        }
    }
}
