using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineVoting.UserPages
{
    public partial class VotingSquare : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RepeaterDataBind();
        }
        public void RepeaterDataBind()
        {
            //PagedDataSource从第0页开始
            int currentPage = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            PagedDataSource pds = new PagedDataSource();
            BLL.UserHome userHome = new BLL.UserHome();
            pds.DataSource = userHome.GetOtherUserVoteSubject(Session["user_name"].ToString()).DefaultView;
            pds.PageSize = 5;
            pds.AllowPaging = true;
            Label1.Text = "当前第 " + currentPage + " 页,共" + pds.PageCount + "页";
            pds.CurrentPageIndex = currentPage - 1;
            if (!pds.IsFirstPage)
            {
                PreButton.PostBackUrl = Request.CurrentExecutionFilePath + "?page=" + (currentPage - 1);
            }
            if (!pds.IsLastPage)
            {
                NextButton.PostBackUrl = Request.CurrentExecutionFilePath + "?page=" + (currentPage + 1);
            }
            int inputPage = (InputPage.Text == "" ? 0 : Convert.ToInt32(InputPage.Text));
            if (inputPage <= pds.PageCount && inputPage > 0)
            {
                Response.Redirect(Request.CurrentExecutionFilePath + "?page=" + inputPage);
            }
            Repeater1.DataSource = pds;
            Repeater1.DataBind();
        }
        public string GetSubjectState()
        {
            //没截止显示不可投，截止显示已截止
            return Convert.ToDateTime(Eval("deadline").ToString())
                          <= DateTime.Now
                          ? "已截止" : ((Eval("votable").ToString() == "false") ? "不可投" : ("<script>" +
                         "$('#subject" + Eval("subject_id") + "').hide()</script>"));
        }
    }
}