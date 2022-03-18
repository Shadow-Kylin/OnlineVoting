using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
namespace OnlineVoting.UserPages
{
    public partial class NestedUserHome : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.UserHome userHome = new BLL.UserHome();
            Signature.Text = userHome.GetUserInf(Session["user_name"].ToString()).User_signature;
            
        }
    }
}