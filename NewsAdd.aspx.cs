using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;
using System.IO;
public partial class admin_manage_NewsAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PageInit();
        }
    }


    /// <summary>
    /// 初始化
    /// </summary>
    protected void PageInit()
    {
        string _selectHtml = string.Format("<select id=\"newsclass\" name=\"newsclass\" >{0}</select>", GetClassHtml("0"));
        ltr_class.Text = _selectHtml;
    }
    /// <summary>
    /// 递归获取类别html select 中间循环部分 <select id="newsclass" name="newsclass" ><option value="1">aaaa</option></select>
    /// </summary>
    protected string _classHtml = "";
    /// <summary>
    /// 递归获取类别html
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    protected string GetClassHtml(string id)
    {
        YYCMS.BLL.NewsGroup NewsGroupBll = new YYCMS.BLL.NewsGroup();
        DataSet ds = NewsGroupBll.GetList(string.Format(" ParentId={0} ", id));
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            int _depth = 0;
            try
            {
                _depth = Convert.ToInt32(dr["depth"]);
            }
            catch
            {
                _depth = 0;
            }
            string _space = YYCMS.Components.StringUtil.GetSpacesString(_depth, "※");
            _classHtml += string.Format("<option value=\"{0}\">{1}{2}</option>", dr["id"].ToString(), _space, dr["Name"].ToString());
            GetClassHtml(dr["id"].ToString());//递归
        }
        return _classHtml;
    }



    /// <summary>
    /// 保存数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        //上传图片 分为两步 第一步：将图片上传到服务器 第二部 将路径保存到数据库
        string path = "";
        string path_small = "";
        string fileNewName = YYCMS.Components.StringUtil.GetDateTimeString();
        if (this.FileUpload1.PostedFile.FileName.Length > 0)
        {
            int ipos = this.FileUpload1.PostedFile.FileName.LastIndexOf("\\");//记录最后一个\的位置
            string fileName = "";
            if (ipos.ToString().Trim() != "-1")
            {
                fileName = this.FileUpload1.PostedFile.FileName.Substring(ipos);//获取文件名
            }
            else
            {
                fileName = this.FileUpload1.PostedFile.FileName;
            }
            int iiii = fileName.LastIndexOf(".");
            string fileExpandName = fileName.Substring(iiii);//获取扩展名
            fileExpandName = fileExpandName.ToLower();
            if (fileExpandName == ".jpg" || fileExpandName == ".gif" || fileExpandName == ".png" || fileExpandName == ".bmp")
            {
                string fileFolder = "\\UploadFile\\News";//构造文件夹名称
                path_small = fileFolder + "\\s_img\\" + fileNewName+fileExpandName;
                path = fileFolder + "\\" + fileNewName + fileExpandName;
                DirectoryInfo dire = new DirectoryInfo(Server.MapPath(fileFolder)); //创建文件夹
                if (!dire.Exists)
                {
                    dire.Create();
                }
                DirectoryInfo dires = new DirectoryInfo(Server.MapPath(fileFolder + "\\s_img")); //创建文件夹
                if (!dires.Exists)
                {
                    dires.Create();
                }
                this.FileUpload1.PostedFile.SaveAs(Server.MapPath(path));//100*150
                YYCMS.Components.Thumbnail.MakeThumbnail(Server.MapPath(path), Server.MapPath(path_small), 88, 98, "WH");//364*379
            }
            else
            {
                YYCMS.Components.Jscript.AlertAndRedirect("您上传的图片格式不正确！", string.Format("NewsAdd.aspx?type={0}", YYCMS.Components.Request.GetQueryInt("type", 0)));
                Response.End();
            }
        }
        //保存到数据库
        YYCMS.BLL.News NewsBll = new YYCMS.BLL.News();
        YYCMS.Model.News NewsModel = new YYCMS.Model.News();
        NewsModel.AddTime =Convert.ToDateTime(tbAddTime.Text);
        NewsModel.Author = YYCMS.Components.StringUtil.CheckStr(tbAuthor.Text);
        NewsModel.Brief = "";
        NewsModel.Details = FCKContent.Value;
        NewsModel.FlagID = 0;
        NewsModel.ImgUrl = path;
        NewsModel.ParentId = YYCMS.Components.Request.GetFormInt("newsclass", 0);
        NewsModel.Source = YYCMS.Components.StringUtil.CheckStr(tbsource.Text);
        NewsModel.Title = YYCMS.Components.StringUtil.CheckStr(tbTitle.Text);
        NewsModel.TypeID = 0;
        NewsModel.Visble = 1;
        NewsModel.VisitCounts = 0;
        int i = NewsBll.Add(NewsModel);
        if (i > 0)
        {
            //更新首页幻灯片XML文件

            DataSet ds = NewsBll.GetList(" ImgUrl<> '' ", 5);
            string strItem = "";
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strItem += string.Format("<item item_url=\"{0}\" link=\"NewsDetails.aspx?type={1}&amp;id={2}\" itemtitle=\"{3}\"></item>", dr["ImgUrl"], dr["parentid"], dr["id"], dr["title"]);
            }

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(string.Format("<?xml version=\"1.0\" encoding=\"utf-8\"?><bcaster autoPlayTime=\"10\">{0}</bcaster>", strItem));
            doc.Save(Server.MapPath("..\\xml\\bcastr.xml"));
            YYCMS.Components.Jscript.AlertAndRedirect("添加成功!", string.Format("NewsAdd.aspx?type={0}", YYCMS.Components.Request.GetQueryInt("type", 0)));
        }
        else
        {
            YYCMS.Components.Jscript.AlertAndRedirect("添加失败!", string.Format("NewsAdd.aspx?type={0}", YYCMS.Components.Request.GetQueryInt("type", 0)));
        }
    }
}
