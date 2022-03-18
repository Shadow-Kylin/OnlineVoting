using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using BLL;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace OnlineVoting.UserPages
{
    public partial class PersonalCenter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["sumofitem"] = 1;
                deadline.Text = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd");
            }
            //点击选项卡切换view
            MultiView1.ActiveViewIndex = ListBox1.SelectedIndex;
        }
        //注销账户
        protected void CancelAcc_Click(object sender, EventArgs e)
        {
            //清除相关账户信息，包括Session,账户表，发布主题表(级联删除投票信息，以及选项)
            UserInf userInf = UserHome.GetUserHome().GetUserInf(Session["user_name"].ToString());
            Session.Clear();
            string sql = "delete from Subject where user_name=@user_name";
            SqlParameter[] sqlParameter = { new SqlParameter("user_name", System.Data.SqlDbType.NVarChar) };
            sqlParameter[0].Value = userInf.User_name;
            UserHome.GetUserHome().CUD(sql, sqlParameter);
            sql = "delete from UserInf where user_id=@user_id";
            SqlParameter[] sqlParameter1 = { new SqlParameter("user_id", System.Data.SqlDbType.Int) };
            sqlParameter1[0].Value = userInf.User_id;
            UserHome.GetUserHome().CUD(sql, sqlParameter1);
            //退回登录页面
            Response.Redirect("~/Login.aspx");
        }

        protected void subject_TextChanged(object sender, EventArgs e)
        {
            if (subject.Text == "")
            {
                Label3.Visible = true;
            }
            else
            {
                Label3.Visible = false;
            }
        }
        //添加项目到label和数组
        protected void additem_Click(object sender, ImageClickEventArgs e)
        {
            if (TextBox2.Text == "")
            {
                return;
            }
            Label6.Text += ("选项" + Session["sumofitem"] + "、<label ruanat='server' style='border-width:2px;border-style:inset;box-shadow: 0px 0px 2px 1px red; '>" +
                "" + TextBox2.Text + "</label></br>");
            Session["items"] += TextBox2.Text + "\n";
            TextBox2.Text = "";
            Session["sumofitem"] = (int.Parse(Session["sumofitem"].ToString()) + 1);
        }
        //清空
        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox2.Text = "";
            Label6.Text = "";
            Session["sumofitem"] = 1;
        }
        //添加投票项目到数据库
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.subject.Text == "" || Session["items"] == null)
                return;
            //赋值subject
            Subject subject = new Subject();
            subject.Subject_content = this.subject.Text;
            subject.Select_mode = RadioButtonList1.SelectedValue;
            subject.User_name = Session["user_name"].ToString();
            subject.Deadline = deadline.Text;
            //获取投票主题的id
            subject.Subject_id = UserHome.GetUserHome().GetSystemInfo().PublishedSubjectSum + 1;
            SystemInfo systemInfo = new SystemInfo();
            systemInfo.PublishedSubjectSum = subject.Subject_id;
            //增加投票主题到数据库
            UserHome.GetUserHome().InsertToSubject(subject);
            //更新投票选项数据库,遍历Label6里的label获取选项内容 
            string sql = "insert into Item (subject_id,item_content) " + "values (@subject_id,@item_content)";
            StringReader stringReader = new StringReader(Session["items"].ToString());
            string stringReadLine;
            while ((stringReadLine = stringReader.ReadLine()) != null)
            {
                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("subject_id",System.Data.SqlDbType.Int),
                    new SqlParameter("item_content",System.Data.SqlDbType.NText)
                };
                sqlParameters[0].Value = subject.Subject_id;
                sqlParameters[1].Value = stringReadLine;
                UserHome.GetUserHome().CUD(sql, sqlParameters);
            }
            //更新SystemInfo主题发布数
            UserHome.GetUserHome().UpdateSystemInfo(systemInfo, 2);
            //初始化页面
            Session["items"] = null;
            this.subject.Text = "";
            Label6.Text = "";
            //显示提示文字
            Label1.Visible = true;
            Timer1.Enabled = true;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Label1.Visible = false;
            //计时停止
            Timer1.Enabled = false;
        }

        protected void View4_Load(object sender, EventArgs e)
        {
            updateView4();
        }
        public void updateView4()
        {
            UserInf userInf = UserHome.GetUserHome().GetUserInf(Session["user_name"].ToString());
            Label7.Text = userInf.User_name;
            Label8.Text = userInf.User_pwd;
            Label9.Text = userInf.User_phone;
            Label10.Text = userInf.User_email;
            Label11.Text = userInf.User_residence;
            Label12.Text = userInf.User_birthday;
            Image1.ImageUrl = userInf.User_photopath;
            Label13.Text = userInf.User_signature;
        }
        string[] province = new string[]
            {
                "请选择",
                "北京",
                "湖北"
            };
        string[][] city = new string[][]
        {
                new string[]{ "密云区","延庆区", "朝阳区", "丰台区", "石景山区", "海淀区", "门头沟区", "房山区",
                    "通州区", "顺义区", "昌平区", "大兴区", "怀柔区", "平谷区", "东城区", "西城区" },
                new string[]{ "武汉", "黄石", "十堰", "荆州", "宜昌", "襄阳", "鄂州", "荆门",
                    "孝感", "黄冈", "咸宁", "随州" }
        };
        protected void View7_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList2.Items.Clear();
                foreach (var i in province)
                    DropDownList2.Items.Add(i);
                UserInf userInf = UserHome.GetUserHome().GetUserInf(Session["user_name"].ToString());
                TextBox1.Text = userInf.User_name;
                TextBox3.Text = userInf.User_phone;
                TextBox4.Text = userInf.User_email;
                RadioButtonList3.SelectedValue = userInf.User_sex;
                TextBox5.Text = Convert.ToDateTime(userInf.User_birthday).ToString("yyyy-MM-dd");
                TextBox6.Text = userInf.User_signature;
            }
        }

        protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox2.SelectedIndex == 3)
            {
                ListBox2.SelectedIndex = -1;
                MultiView2.ActiveViewIndex = 0;
                return;
            }
            MultiView2.ActiveViewIndex = ListBox2.SelectedIndex + 1;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList3.Items.Clear();
            int selectIndex = DropDownList2.SelectedIndex - 1;
            if (selectIndex >= 0)
            {
                foreach (string i in city[selectIndex])
                    DropDownList3.Items.Add(i);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Page.IsValid&& TextBox1.Text!="")
            {
                string sql = "update UserInf set user_name=@new_username,user_email=@user_email," +
                "user_phone=@user_phone,user_sex=@user_sex,user_birthday=@user_birthday," +
                "user_residence=@user_residence,user_signature=@user_signature where user_name=@old_username";
                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("new_username",SqlDbType.NVarChar),
                    new SqlParameter("user_email",SqlDbType.NText),
                    new SqlParameter("user_phone",SqlDbType.VarChar),
                    new SqlParameter("user_sex",SqlDbType.NChar),
                    new SqlParameter("user_birthday",SqlDbType.Date),
                    new SqlParameter("user_residence",SqlDbType.NText),
                    new SqlParameter("user_signature",SqlDbType.NText),
                    new SqlParameter("old_username",SqlDbType.NVarChar)
                };
                sqlParameters[0].Value = TextBox1.Text;
                sqlParameters[1].Value = TextBox4.Text;
                sqlParameters[2].Value = TextBox3.Text;
                sqlParameters[3].Value = RadioButtonList3.Text;
                sqlParameters[4].Value = TextBox5.Text;
                sqlParameters[5].Value = "(省)"+DropDownList2.SelectedValue +"(市)"+ DropDownList3.SelectedValue;
                sqlParameters[6].Value = TextBox6.Text;
                sqlParameters[7].Value = Session["user_name"];
                UserHome.GetUserHome().CUD(sql, sqlParameters);
                updateView4();
                ListBox2.SelectedIndex = -1;
                MultiView2.ActiveViewIndex = 0;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string saveDiv = @"Images/";
                string filename = Session["user_name"].ToString() + Path.GetExtension(FileUpload1.FileName);
                FileUpload1.SaveAs(Request.PhysicalApplicationPath + saveDiv + filename);
                updateView4();
                ListBox2.SelectedIndex = -1;
                MultiView2.ActiveViewIndex = 0;
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (Label14.Text == "输入旧密码")
            {
                if (TextBox7.Text == UserHome.GetUserHome()
                    .GetUserInf(Session["user_name"].ToString()).User_pwd)
                {
                    Label14.Text = "输入新密码";
                    Label15.Text = "";
                }
                else
                    Label15.Text = "密码错误!";
            }
            else
            {
                string sql = "update UserInf set user_pwd=@user_pwd where user_name=@user_name";
                SqlParameter[] sqlParameters = { 
                    new SqlParameter("user_pwd", SqlDbType.VarChar),
                    new SqlParameter("user_name",SqlDbType.NVarChar)
                };
                sqlParameters[0].Value = TextBox7.Text;
                sqlParameters[1].Value = Session["user_name"];
                UserHome.GetUserHome().CUD(sql, sqlParameters);
                Label14.Text = "输入旧密码";
                Label15.Text = "";
                TextBox7.Text = "";
                ListBox2.SelectedIndex = -1;
                MultiView2.ActiveViewIndex = 0;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            MultiView3.ActiveViewIndex = 1;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            MultiView3.ActiveViewIndex = 0;
        }
    }
}