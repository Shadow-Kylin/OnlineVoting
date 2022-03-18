using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;

//注册页面的逻辑层

namespace BLL
{
    public class Register
    {
        public Boolean checkUserName(UserInf userInf)
        {
            string sql = "select count(*) from UserInf where user_name=@username";
            SqlParameter[] parameters = {new SqlParameter("username",SqlDbType.NVarChar) };
            parameters[0].Value = userInf.User_name;
            int n = (int)DAUtils.GetDAUtils().SingleQuery(sql, parameters);
            if (n == 1)
                return false;
            return true;
        }
        
    }
}
