using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineVoting.UserPages
{
    public partial class CurrentUserSubject : System.Web.UI.Page
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
            RadioButtonList2.SelectedIndex = subject.Votable.ToString()=="False"?1:0;
            Label4.Text = "发表用户:"+ subject.User_name;
            DataTable dataTable = userHome.GetItems(int.Parse(Request["subject_id"]));
            Session["Select_mode"] = subject.Select_mode;
            if (Session["Select_mode"].ToString() == "单选")
            {
                RadioButtonList1.Visible = true;
                CheckBoxList1.Visible = false;
                RadioButtonList1.Items.Clear();
                for(int i = 0; i < dataTable.Rows.Count; i++)
                {
                    byte[] bt = new byte[1];
                    bt[0] = (byte)Convert.ToInt32(65 + i);
                    RadioButtonList1.Items.Add(System.Text.Encoding.ASCII.GetString(bt)
                        + "、" + dataTable.Rows[i]["item_content"].ToString());
                }
            }
            else
            {
                RadioButtonList1.Visible = false;
                CheckBoxList1.Visible = true;
                CheckBoxList1.Items.Clear();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    byte[] bt = new byte[1];
                    bt[0] = (byte)Convert.ToInt32(65 + i);
                    CheckBoxList1.Items.Add(System.Text.Encoding.ASCII.GetString(bt)
                        +"、"+dataTable.Rows[i]["item_content"].ToString());
                }
            }
            string[] xValue=new string[26];
            double[] yValue=new double[26];
            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                byte[] bt = new byte[1];
                bt[0] = (byte)Convert.ToInt32(65 + i);
                xValue[i] = System.Text.Encoding.ASCII.GetString(bt);
                yValue[i] = userHome.getItemVoteCount(int.Parse(dataTable.Rows[i]["item_id"].ToString()));
            }
            Chart1.Series["Series1"].Points.DataBindXY(xValue,yValue);
            Chart1.Series[0].Label = "#PERCENT-数量:#VALY-选项:#VALX";
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            if (edit_text.InnerHtml == "编辑")
            {
                SetAllTextBox(true, BorderStyle.Solid,this);
                edit_text.InnerHtml = "退出编辑";
                Button1.Visible=true;
                if (Request["state1"] == "0")
                {
                    RadioButtonList1.Enabled = true;
                    CheckBoxList1.Enabled = true;
                }
                DataFlush();
            }
            else
            {
                CheckBoxList1.Enabled = false;
                RadioButtonList1.Enabled = false;
                SetAllTextBox(false, BorderStyle.None,this);
                edit_text.InnerHtml = "编辑";
                Button1.Visible = false;
                DataFlush();
            }
        }
        public void SetAllTextBox(Boolean bl, BorderStyle borderStyle, Control control)
        {
            if(control is TextBox)
            {
                (control as TextBox).Enabled = bl;
                (control as TextBox).BorderStyle = borderStyle;
            }
            else if (control.HasControls())
            {
                foreach(Control control1 in control.Controls)
                {
                    SetAllTextBox(bl, borderStyle, control1);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "update Subject set subject_content=@subject_content,select_mode=@select_mode" +
                ",votable=@votable,deadline=@deadline where subject_id=@subject_id";
            SqlParameter[] parameters = {
                new SqlParameter("subject_id",SqlDbType.Int),
                new SqlParameter("subject_content",SqlDbType.NText),
                new SqlParameter("select_mode",SqlDbType.NChar),
                new SqlParameter("votable",SqlDbType.VarChar),
                new SqlParameter("deadline",SqlDbType.DateTime)
            };
            parameters[0].Value = Request["subject_id"];
            parameters[1].Value = subject_content.Text;
            parameters[2].Value = TextBox1.Text;
            parameters[3].Value = RadioButtonList2.SelectedValue;
            parameters[4].Value =TextBox2.Text;
            //修改URL中的参数
            EditButton.PostBackUrl = Request.CurrentExecutionFilePath + "?subject_id=" + Request["subject_id"]
                + "&state1=" + GetSubjectState();
            BLL.UserHome.GetUserHome().CUD(sql, parameters);
            //更改用户在该主题的所选项
            sql = "delete from UserVote where votedSubject_id=@subject_id and user_id=@user_id";
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
                for(int i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    if (CheckBoxList1.Items[i].Selected)
                    {
                        selectedIndex = i;
                        parameters2[2].Value = dataTable.Rows[selectedIndex]["item_id"];
                        BLL.UserHome.GetUserHome().CUD(sql, parameters2);
                    }
                }
            }
            SetAllTextBox(false, BorderStyle.None, this);
            edit_text.InnerHtml = "编辑";
            Button1.Visible = false;
            DataFlush();
        }
        public string GetSubjectState()
        {
            //没截止显示不可投，截止显示已截止
            return Convert.ToDateTime(Convert.ToDateTime(TextBox2.Text).ToLongDateString())
                          <= Convert.ToDateTime(DateTime.Now.ToLongDateString())
                          ? "已截止" : ((RadioButtonList2.SelectedValue == "false") ? "不可投":"0");
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            //修改URL中的参数
            Button1.PostBackUrl = Request.CurrentExecutionFilePath + "?subject_id=" + Request["subject_id"]
                + "&state1=" + GetSubjectState();
        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //修改URL中的参数
            Button1.PostBackUrl = Request.CurrentExecutionFilePath + "?subject_id=" + Request["subject_id"]
                + "&state1=" + GetSubjectState();
        }
    }
}