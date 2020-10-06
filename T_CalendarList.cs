using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Data.SqlClient;

namespace Maticsoft
{
    /// <summary>
    /// 类T_CalendarList。
    /// </summary>
    [Serializable]
    public partial class T_CalendarList
    {
        public T_CalendarList()
        { }
        #region Model
        private int _id;
        private string _i_title;
        private string _i_content;
        private string _i_name;
        private string _i_date;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string i_title
        {
            set { _i_title = value; }
            get { return _i_title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string i_content
        {
            set { _i_content = value; }
            get { return _i_content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string i_name
        {
            set { _i_name = value; }
            get { return _i_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string i_date
        {
            set { _i_date = value; }
            get { return _i_date; }
        }
        #endregion Model


        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public T_CalendarList(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,i_title,i_content,i_name,i_date ");
            strSql.Append(" FROM [T_CalendarList] ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    this.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["i_title"] != null)
                {
                    this.i_title = ds.Tables[0].Rows[0]["i_title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["i_content"] != null)
                {
                    this.i_content = ds.Tables[0].Rows[0]["i_content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["i_name"] != null)
                {
                    this.i_name = ds.Tables[0].Rows[0]["i_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["i_date"] != null)
                {
                    this.i_date = ds.Tables[0].Rows[0]["i_date"].ToString();
                }
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [T_CalendarList] (");
            strSql.Append("i_title,i_content,i_name,i_date)");
            strSql.Append(" values (");
            strSql.Append("@i_title,@i_content,@i_name,@i_date)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@i_title", SqlDbType.NVarChar,150),
                    new SqlParameter("@i_content", SqlDbType.NVarChar,-1),
                    new SqlParameter("@i_name", SqlDbType.NVarChar,150),
                    new SqlParameter("@i_date", SqlDbType.NVarChar,150)};
            parameters[0].Value = i_title;
            parameters[1].Value = i_content;
            parameters[2].Value = i_name;
            parameters[3].Value = i_date;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [T_CalendarList] set ");
            strSql.Append("i_title=@i_title,");
            strSql.Append("i_content=@i_content,");
            strSql.Append("i_name=@i_name,");
            strSql.Append("i_date=@i_date");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@i_title", SqlDbType.NVarChar,150),
                    new SqlParameter("@i_content", SqlDbType.NVarChar,-1),
                    new SqlParameter("@i_name", SqlDbType.NVarChar,150),
                    new SqlParameter("@i_date", SqlDbType.NVarChar,150),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = i_title;
            parameters[1].Value = i_content;
            parameters[2].Value = i_name;
            parameters[3].Value = i_date;
            parameters[4].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [T_CalendarList] ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [T_CalendarList] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}


