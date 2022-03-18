using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineVoting.UserPages
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RepeaterDataBind();
        }
        public void RepeaterDataBind()
        {
            //从网站url中获取应该设置的当前页
            int currentPage =Request["page"]==null?1: int.Parse(Request["page"]);
            PagedDataSource pds = new PagedDataSource();
            BLL.UserHome userHome = new BLL.UserHome();
            //获得登录用户发布的投票
            pds.DataSource = userHome.GetUserVoteSubject(Session["user_name"].ToString()).DefaultView;
            //一页五条数据
            pds.PageSize = 5;
            //允许分页
            pds.AllowPaging = true;
            Label1.Text = "当前第 " + currentPage + " 页,共" +pds.PageCount+"页";
            //设置pds的当前页,PagedDataSource从第0页开始所以减1
            pds.CurrentPageIndex = currentPage-1;
            //设置按钮的url中的页面参数值
            if (!pds.IsFirstPage)//不是第一页
            {
                PreButton.PostBackUrl = Request.CurrentExecutionFilePath + "?page=" + (currentPage - 1);
            }
            if (!pds.IsLastPage)//不是最后一页
            {
                NextButton.PostBackUrl = Request.CurrentExecutionFilePath + "?page=" + (currentPage + 1);
            }
            //手动输入页数
            int inputPage = (InputPage.Text == "" ? 0 : Convert.ToInt32(InputPage.Text));
            if (inputPage<=pds.PageCount&& inputPage > 0)
            {
                Response.Redirect(Request.CurrentExecutionFilePath + "?page=" + inputPage);
            }
            Repeater1.DataSource = pds;
            Repeater1.DataBind();
        }
        public string GetSubjectState()
        {
            //没截止显示不可投，截止显示已截止，截止时间小于等于当前日期都算截止
           return Convert.ToDateTime(Eval("deadline").ToString())
                         <= DateTime.Now
                         ?"已截止": ((Eval("votable").ToString() == "false") ? "不可投" : ("<script>" +
                        "$('#subject"+Eval("subject_id")+"').hide()</script>"));
        }
    }
}