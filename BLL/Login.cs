using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models;
using DAL;

//登录页面的逻辑层

namespace BLL
{
    public class Login
    {
        public UserInf checkUserName(UserInf userInf)
        {
            string sql = "select user_status from UserInf where user_name= @username";
            SqlParameter[] parameters = { new SqlParameter("username", SqlDbType.NVarChar) };
            parameters[0].Value = userInf.User_name;
            //DataTable dataTable = DAUtils.GetDAUtils().GetRecords(sql, parameters);
            //try
            //{
            //    string s = dataTable.Rows[0][dataTable.Columns[0].ColumnName].ToString();
            //}
            //catch
            //{
            //    return false;
            //}
            //return true;
            Object obj=DAUtils.GetDAUtils().SingleQuery(sql, parameters);
            if (obj == null)
                userInf.User_status = 2;//不存在
            else if (obj.ToString()=="0")
                userInf.User_status = 0;//用户
            else
                userInf.User_status = 1;//管理员
            return userInf;
        }
        public Boolean checkPassword(UserInf userInf)
        {
            string sql = "select user_pwd from UserInf where user_name= @username";
            SqlParameter[] parameters = { new SqlParameter("username", SqlDbType.NVarChar) };
            parameters[0].Value = userInf.User_name;
            Object obj = DAUtils.GetDAUtils().SingleQuery(sql, parameters);
            //判null防止对象未实例化
            if (obj!=null&&obj.ToString().Equals(userInf.User_pwd))
            {
                return true;
            }
            return false;
        }
        public string getPhotoPath(string username)
        {
            string sql = "select user_photopath from UserInf where user_name=@username";
            SqlParameter[] parameters = { new SqlParameter("username", SqlDbType.NVarChar) };
            parameters[0].Value = username;
            return DAUtils.GetDAUtils().SingleQuery(sql, parameters).ToString();
        }
    }
}
