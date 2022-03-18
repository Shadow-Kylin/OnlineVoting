using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models;
using DAL;
using System.Data.SqlClient;
using System.Data;

namespace BLL
{
    public class UserHome
    {
        string sql;
        public UserInf GetUserInf(string user_name)
        {
            UserInf userInf = new UserInf();
            userInf.User_name = user_name;
            sql = "select * from UserInf where user_name=@username";
            SqlParameter[] parameters = { new SqlParameter("username", SqlDbType.NVarChar) };
            parameters[0].Value = user_name;
            DataTable dataTable = DAUtils.GetDAUtils().GetRecords(sql, parameters);
            userInf.User_signature = dataTable.Rows[0]["user_signature"].ToString();
            userInf.User_id = (int)dataTable.Rows[0]["user_id"];
            userInf.User_phone = dataTable.Rows[0]["user_phone"].ToString();
            userInf.User_email = dataTable.Rows[0]["user_email"].ToString();
            userInf.User_pwd = dataTable.Rows[0]["user_pwd"].ToString();
            userInf.User_photopath = dataTable.Rows[0]["user_photopath"].ToString();
            userInf.User_sex = dataTable.Rows[0]["user_sex"].ToString();
            userInf.User_residence= dataTable.Rows[0]["user_residence"].ToString();
            userInf.User_birthday= dataTable.Rows[0]["user_birthday"].ToString(); ;
            return userInf;
        }
        //获取用户发布的投票记录
        public DataTable GetUserVoteSubject(string user_name)
        {
            sql = "select * from Subject where user_name=@username";
            SqlParameter[] parameters = { new SqlParameter("username", SqlDbType.NVarChar) };
            parameters[0].Value = user_name;
            return DAUtils.GetDAUtils().GetRecords(sql, parameters);
        }
        public DataTable GetOtherUserVoteSubject(string user_name)
        {
            sql = "select * from Subject where user_name!=@username";
            SqlParameter[] parameters = { new SqlParameter("username", SqlDbType.NVarChar) };
            parameters[0].Value = user_name;
            return DAUtils.GetDAUtils().GetRecords(sql, parameters);
        }
        public Subject GetSubject(int subject_id)
        {
            sql = "select * from Subject where subject_id = @subject_id";
            SqlParameter[] parameters = { new SqlParameter("subject_id", SqlDbType.Int) };
            parameters[0].Value = subject_id;
            DataTable dataTable= DAUtils.GetDAUtils().GetRecords(sql, parameters);
            Subject subject = new Subject();
            subject.Subject_id = (int)dataTable.Rows[0]["subject_id"];
            subject.Subject_content = dataTable.Rows[0]["subject_content"].ToString();
            subject.Select_mode = dataTable.Rows[0]["select_mode"].ToString();
            subject.Votable =Convert.ToBoolean( dataTable.Rows[0]["Votable"]);
            subject.Deadline = dataTable.Rows[0]["deadline"].ToString();
            subject.User_name = dataTable.Rows[0]["user_name"].ToString();
            return subject;
        }
        public DataTable GetItems(int subject_id)
        {
            sql = "select * from Item where subject_id=@subject_id";
            SqlParameter[] parameters = {new SqlParameter("subject_id", SqlDbType.Int) };
            parameters[0].Value = subject_id;
            DataTable dataTable = DAUtils.GetDAUtils().GetRecords(sql, parameters);
            return dataTable;
        }
        public int getItemVoteCount(int item_id)
        {
            sql = "select count(*) from UserVote where votedItem_id=@item_id";
            SqlParameter[] parameters = { new SqlParameter("item_id", SqlDbType.Int) };
            parameters[0].Value = item_id;
            return (int)DAUtils.GetDAUtils().SingleQuery(sql, parameters);
        }
        public SystemInfo GetSystemInfo()
        {
            SystemInfo systemInfo = new SystemInfo();
            sql = "select * from SystemInfo where Id=1";
            DataTable dataTable = DAUtils.GetDAUtils().GetRecords(sql);
            systemInfo.RegiterUserSum = int.Parse(dataTable.Rows[0]["RegiterUserSum"].ToString());
            systemInfo.PublishedSubjectSum = int.Parse(dataTable.Rows[0]["PublishedSubjectSum"].ToString());
            systemInfo.VisitSum = int.Parse(dataTable.Rows[0]["VisitSum"].ToString());
            return systemInfo;
        }
        public void UpdateSystemInfo(SystemInfo systemInfo,int paraid)
        {
            sql = "update SystemInfo set ";
            if (paraid == 1)
                sql += "RegiterUserSum=" + systemInfo.RegiterUserSum;
            else if (paraid == 2)
                sql += "PublishedSubjectSum=" + systemInfo.PublishedSubjectSum;
            else if (paraid == 3)
                sql += "VisitSum=" + systemInfo.VisitSum;
            sql += " where id=1";
            CUD(sql);
        }
        public static UserHome GetUserHome()
        {
            return new UserHome();
        }
        public void CUD(string sql,SqlParameter[] parameters)
        {
            DAUtils.GetDAUtils().cud(sql, parameters);
        }
        public void CUD(string sql)
        {
            DAUtils.GetDAUtils().cud(sql, new SqlParameter[] { });
        }
        public void InsertToSubject(Subject subject)
        {
            sql = "insert into Subject (subject_id,subject_content,select_mode,deadline,user_name)" +
                " values (@subject_id,@subject_content,@select_mode,@deadline,@user_name)";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("subject_id",SqlDbType.Int),
                new SqlParameter("subject_content",SqlDbType.NText),
                new SqlParameter("select_mode",SqlDbType.NChar),
                new SqlParameter("deadline",SqlDbType.Date),
                new SqlParameter("user_name",SqlDbType.NVarChar)
            };
            sqlParameters[0].Value = subject.Subject_id;
            sqlParameters[1].Value = subject.Subject_content;
            sqlParameters[2].Value = subject.Select_mode;
            sqlParameters[3].Value = subject.Deadline;
            sqlParameters[4].Value = subject.User_name;
            CUD(sql, sqlParameters);
        }
    }
}
