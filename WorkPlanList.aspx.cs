using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class admin_manage_WorkPlanList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            YYCMS.BLL.Admin AdminBll = new YYCMS.BLL.Admin();
            DataSet ds = AdminBll.GetAllList();
            StringBuilder sbjs = new StringBuilder();
            sbjs.Append(" var arrayObj = new Array();");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                sbjs.AppendFormat(" arrayObj[{0}]='{1}';",dr["id"].ToString(), dr["TrueName"].ToString());
            }
            ClientScript.RegisterStartupScript(this.Page.GetType(), "message", string.Format("<script language='javascript' type='text/javascript'>{0}</script>", sbjs.ToString()));

        }
    }
   


}