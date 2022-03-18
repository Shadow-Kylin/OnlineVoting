using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Models;
namespace OnlineVoting
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                UserInf userInf = new UserInf();
                userInf.User_name = username.Text;
                userInf.User_pwd = password.Text;

                BLL.Login login = new BLL.Login();
                Label2.Visible = false;
                if (login.checkPassword(userInf))
                {
                    Session["identifier"] = "user";
                    Session["user_name"] = username.Text;
                    Session["user_photopath"] = login.getPhotoPath(username.Text);
                    SystemInfo systemInfo = UserHome.GetUserHome().GetSystemInfo();
                    systemInfo.VisitSum += 1;
                    UserHome.GetUserHome().UpdateSystemInfo(systemInfo, 3);
                    Response.Redirect("~/UserPages/index.aspx");
                    Label3.Visible = false;
                }
                else
                {
                    Label3.Visible = true;
                }
            }
            else
            {
                Label2.Visible = true;
            }
        }
    }
}