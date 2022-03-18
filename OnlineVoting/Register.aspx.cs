using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Models;

namespace OnlineVoting
{
    public partial class Register : System.Web.UI.Page
    {
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach(string i in province)
                    DropDownList1.Items.Add(i);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            int selectedIndex = DropDownList1.SelectedIndex - 1;
            if (selectedIndex >= 0)
            {
                foreach (string i in city[selectedIndex])
                    DropDownList2.Items.Add(i);
            }
        }

        protected void username_TextChanged(object sender, EventArgs e)
        {
            UserInf userInf = new UserInf();
            userInf.User_name = username.Text;
            //-----------检测用户名是否存在-----------------
            BLL.Register register = new BLL.Register();
            if (register.checkUserName(userInf))
            {
                Label11.Visible = false;
            }
            else
            {
                Label11.Visible = true;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)//注册
        {
            if (Page.IsValid)
            {
                //-------------------插入注册用户信息--------------
                //SqlServer语句
                SqlDataSource1.InsertCommand = "INSERT INTO UserInf(/*user_id, */user_name, " +
                    "user_pwd, user_email, user_phone, user_sex, user_birthday, " +
                    "user_residence, user_photopath, user_signature) VALUES (/*@UserSum ,*/ @Name, " +
                    "@Password, @Email, @Phone, @Sex, @Birthday, @Residence, @Photopath, " +
                    "@Signature)";
                //变量赋值
                //SqlDataSource1.InsertParameters.Add("UserSum", TypeCode.Int32, Application["usersum"].ToString());
                SqlDataSource1.InsertParameters.Add("Name", TypeCode.String, username.Text);
                SqlDataSource1.InsertParameters.Add("Password", TypeCode.String, password.Text);
                SqlDataSource1.InsertParameters.Add("Email", TypeCode.String, email.Text);
                SqlDataSource1.InsertParameters.Add("Phone", TypeCode.String, phone.Text);
                SqlDataSource1.InsertParameters.Add("Sex", TypeCode.String, RadioButtonList1.SelectedValue);
                SqlDataSource1.InsertParameters.Add("Birthday", TypeCode.String, birthday.Text!=""?Convert.ToDateTime(birthday.Text).ToShortDateString(): birthday.Text);
                SqlDataSource1.InsertParameters.Add("Residence", TypeCode.String, "(省)" + DropDownList1.
                    SelectedValue + "(市)" + DropDownList2.SelectedValue);
                //文件上传
                
                if (FileUpload1.HasFile)
                {
                    string saveDir = @"Images/";
                    string fileName = username.Text + Path.GetExtension(FileUpload1.FileName);
                    string savePath = Request.PhysicalApplicationPath + saveDir + fileName;
                    FileUpload1.SaveAs(savePath);
                    SqlDataSource1.InsertParameters.Add("Photopath", TypeCode.String, "~/"+saveDir+fileName);
                }
                else
                    SqlDataSource1.InsertParameters.Add("Photopath", TypeCode.String, "");
                SqlDataSource1.InsertParameters.Add("Signature", TypeCode.String, signature.Text);
                //插入数据
                SqlDataSource1.Insert();
                SystemInfo systemInfo = UserHome.GetUserHome().GetSystemInfo();
                systemInfo.RegiterUserSum += 1;
                UserHome.GetUserHome().UpdateSystemInfo(systemInfo,1);
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}