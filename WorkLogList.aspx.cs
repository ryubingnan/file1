using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class admin_manage_WorkLogList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ltr_batchDelete.Text = "<input id=\"deleteSelect\" class=\"bgbtn2\" type=\"button\" value=\"删除选中记录\"  onclick=\"DeleteSelect()\" />";
            PageInit();
        }
    }
    /// <summary>
    /// 初始化
    /// </summary>
    protected void PageInit()
    {
        YYCMS.BLL.WorkLog WorkLogBll = new YYCMS.BLL.WorkLog();
        int recordcount = 0;
        int _pageindex = YYCMS.Components.Request.GetQueryInt("p", 1);
        string strWhere = " 1=1 ";
        int userid = BasePage.GetUserId();
        int groupid = BasePage.GetUserGroupId();
        if (groupid != 1)
        {
            strWhere += string.Format(" and userid={0} ", userid);
        }
        int typeid = YYCMS.Components.Request.GetQueryInt("type", 1);
        DataSet ds = WorkLogBll.Pager(_pageindex, 20, strWhere, out recordcount);
        Repeater1.DataSource = ds;
        Repeater1.DataBind();
        Pager1.PageSize = 20;
        Pager1.PageIndex = _pageindex;
        Pager1.RecordCount = recordcount;
    }
    /// <summary>
    /// 根据userid返回名称
    /// </summary>
    /// <param name="userid"></param>
    /// <returns></returns>
    protected string GetUserName(string userid)
    {
        YYCMS.BLL.Admin AdminBll = new YYCMS.BLL.Admin();
        return AdminBll.GetUserName(Convert.ToInt32(userid));
    }
    /// <summary>
    /// 审核按钮的显示与隐藏
    /// </summary>
    /// <returns></returns>
    protected string GetShowType()
    {
        string str = "none";
        if (BasePage.GetUserGroupId() == 1)
        {
            str = "inline";
        }
        return str;
    }
}