using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_manage_WorkLogEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        YYCMS.BLL.WorkLog WorkLogBll = new YYCMS.BLL.WorkLog();
        YYCMS.Model.WorkLog WorkLogModel = new YYCMS.Model.WorkLog();
        WorkLogModel.checkstate = 0;
        WorkLogModel.contents = FCKContent.Value;
        WorkLogModel.ctime = DateTime.Now;
        WorkLogModel.Title = tbTitle.Text;
        WorkLogModel.userid = Convert.ToInt32(BasePage.GetUserId());
        int i=WorkLogBll.Add(WorkLogModel);
        if (i > 0)
        {
            YYCMS.Components.MessageBox.Show(this.Page, "保存成功!");
        }
        else
        {
            YYCMS.Components.MessageBox.Show(this.Page, "保存失败!");
        }

    }
}