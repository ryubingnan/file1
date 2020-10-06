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

namespace JOBSOEZ
{
    /// <summary>
    /// 类T_ChatList。
    /// </summary>
    [Serializable]
    public partial class T_ChatList
    {
        public T_ChatList()
        { }
        #region Model
        private int _id;
        private string _department;
        private string _type;
        private string _contents;
        private string _from_userid;
        private string _to_userid;
        private string _datein;
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
        public string department
        {
            set { _department = value; }
            get { return _department; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string contents
        {
            set { _contents = value; }
            get { return _contents; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string from_userID
        {
            set { _from_userid = value; }
            get { return _from_userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string to_userID
        {
            set { _to_userid = value; }
            get { return _to_userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string datein
        {
            set { _datein = value; }
            get { return _datein; }
        }
        #endregion Model


        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public T_ChatList(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,department,type,contents,from_userID,to_userID,datein ");
            strSql.Append(" FROM [T_ChatList] ");
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
                if (ds.Tables[0].Rows[0]["department"] != null)
                {
                    this.department = ds.Tables[0].Rows[0]["department"].ToString();
                }
                if (ds.Tables[0].Rows[0]["type"] != null)
                {
                    this.type = ds.Tables[0].Rows[0]["type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["contents"] != null)
                {
                    this.contents = ds.Tables[0].Rows[0]["contents"].ToString();
                }
                if (ds.Tables[0].Rows[0]["from_userID"] != null)
                {
                    this.from_userID = ds.Tables[0].Rows[0]["from_userID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["to_userID"] != null)
                {
                    this.to_userID = ds.Tables[0].Rows[0]["to_userID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["datein"] != null)
                {
                    this.datein = ds.Tables[0].Rows[0]["datein"].ToString();
                }
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [T_ChatList] (");
            strSql.Append("department,type,contents,from_userID,to_userID,datein)");
            strSql.Append(" values (");
            strSql.Append("@department,@type,@contents,@from_userID,@to_userID,@datein)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@department", SqlDbType.NVarChar,50),
                    new SqlParameter("@type", SqlDbType.NVarChar,50),
                    new SqlParameter("@contents", SqlDbType.NVarChar,-1),
                    new SqlParameter("@from_userID", SqlDbType.NVarChar,50),
                    new SqlParameter("@to_userID", SqlDbType.NVarChar,50),
                    new SqlParameter("@datein", SqlDbType.NVarChar,50)};
            parameters[0].Value = department;
            parameters[1].Value = type;
            parameters[2].Value = contents;
            parameters[3].Value = from_userID;
            parameters[4].Value = to_userID;
            parameters[5].Value = datein;

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
            strSql.Append("update [T_ChatList] set ");
            strSql.Append("department=@department,");
            strSql.Append("type=@type,");
            strSql.Append("contents=@contents,");
            strSql.Append("from_userID=@from_userID,");
            strSql.Append("to_userID=@to_userID,");
            strSql.Append("datein=@datein");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@department", SqlDbType.NVarChar,50),
                    new SqlParameter("@type", SqlDbType.NVarChar,50),
                    new SqlParameter("@contents", SqlDbType.NVarChar,-1),
                    new SqlParameter("@from_userID", SqlDbType.NVarChar,50),
                    new SqlParameter("@to_userID", SqlDbType.NVarChar,50),
                    new SqlParameter("@datein", SqlDbType.NVarChar,50),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = department;
            parameters[1].Value = type;
            parameters[2].Value = contents;
            parameters[3].Value = from_userID;
            parameters[4].Value = to_userID;
            parameters[5].Value = datein;
            parameters[6].Value = id;

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
            strSql.Append("delete from [T_ChatList] ");
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
            strSql.Append(" FROM [T_ChatList] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}







