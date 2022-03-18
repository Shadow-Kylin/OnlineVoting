using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Models;
namespace OnlineVoting.UserPages
{
    public partial class OtherUserSubject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataFlush();
            }
        }
        public void DataFlush()
        {
            BLL.UserHome userHome = new BLL.UserHome();
            Subject subject = userHome.GetSubject(int.Parse(Request["subject_id"]));
            subject_content.Text = subject.Subject_content;
            TextBox1.Text = subject.Select_mode;
            //日期类型转换
            TextBox2.Text = Convert.ToDateTime(subject.Deadline).ToString("yyyy-MM-dd");
            //C#Boolean类型转换为string首字母是大写
            RadioButtonList2.SelectedIndex = subject.Votable.ToString() == "False" ? 1 : 0;
            Label4.Text = "发表用户:" + subject.User_name;
            DataTable dataTable = userHome.GetItems(int.Parse(Request["subject_id"]));
            Session["Select_mode"] = subject.Select_mode;
            if (Session["Select_mode"].ToString() == "单选")
            {
                RadioButtonList1.Visible = true;
            }
            else CheckBoxList1.Visible = true;
            if (Request["state1"] == "0")
            {
                RadioButtonList1.Enabled = true;
                CheckBoxList1.Enabled = true;
            }
            if (Session["Select_mode"].ToString() == "单选")
            {
                RadioButtonList1.Items.Clear();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    byte[] bt = new byte[1];
                    bt[0] = (byte)Convert.ToInt32(65 + i);
                    RadioButtonList1.Items.Add(System.Text.Encoding.ASCII.GetString(bt)
                        + "、" + dataTable.Rows[i]["item_content"].ToString());
                }
            }
            else
            {
                CheckBoxList1.Items.Clear();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    byte[] bt = new byte[1];
                    bt[0] = (byte)Convert.ToInt32(65 + i);
                    CheckBoxList1.Items.Add(System.Text.Encoding.ASCII.GetString(bt)
                        + "、" + dataTable.Rows[i]["item_content"].ToString());
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //更改用户在该主题的所选项
            string sql = "delete from UserVote where votedSubject_id=@subject_id and user_id=@user_id";
            SqlParameter[] parameters1 = {
                new SqlParameter("subject_id", SqlDbType.Int),
                new SqlParameter("user_id", SqlDbType.Int)};
            parameters1[0].Value = Request["subject_id"];
            int user_id = BLL.UserHome.GetUserHome().GetUserInf(Session["user_name"].ToString()).User_id;
            parameters1[1].Value = user_id;
            BLL.UserHome.GetUserHome().CUD(sql, parameters1);
            DataTable dataTable = BLL.UserHome.GetUserHome().GetItems(int.Parse(Request["subject_id"]));
            sql = "insert into UserVote values (@user_id,@subject_id,@item_id)";
            SqlParameter[] parameters2 = {
                new SqlParameter("user_id",SqlDbType.Int),
                new SqlParameter("subject_id",SqlDbType.Int),
                new SqlParameter("item_id",SqlDbType.Int)
            };
            parameters2[0].Value = user_id;
            parameters2[1].Value = Request["subject_id"];
            int selectedIndex;
            if (Session["select_mode"].ToString() == "单选")
            {
                selectedIndex = RadioButtonList1.SelectedIndex;
                if (selectedIndex != -1)
                {
                    parameters2[2].Value = dataTable.Rows[selectedIndex]["item_id"];
                    BLL.UserHome.GetUserHome().CUD(sql, parameters2);
                }
            }
            else
            {
                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    if (CheckBoxList1.Items[i].Selected)
                    {
                        selectedIndex = i;
                        parameters2[2].Value = dataTable.Rows[selectedIndex]["item_id"];
                        BLL.UserHome.GetUserHome().CUD(sql, parameters2);
                    }
                }
            }
            DataFlush();
        }
    }
}