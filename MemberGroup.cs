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
namespace YYCMS
{
    /// <summary>
    /// 类MemberGroup。
    /// </summary>
    public class MemberGroup
    {
        public MemberGroup()
        { }
        #region Model
        private int _id;
        private string _groupname;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GroupName
        {
            set { _groupname = value; }
            get { return _groupname; }
        }
        #endregion Model


        #region  成员方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MemberGroup(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,GroupName ");
            strSql.Append(" FROM MemberGroup ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                GroupName = ds.Tables[0].Rows[0]["GroupName"].ToString();
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from MemberGroup");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into MemberGroup(");
            strSql.Append("GroupName)");
            strSql.Append(" values (");
            strSql.Append("@GroupName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@GroupName", SqlDbType.NVarChar,50)};
            parameters[0].Value = GroupName;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MemberGroup set ");
            strSql.Append("GroupName=@GroupName");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@GroupName", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;
            parameters[1].Value = GroupName;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete MemberGroup ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public void GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,GroupName ");
            strSql.Append(" FROM MemberGroup ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                GroupName = ds.Tables[0].Rows[0]["GroupName"].ToString();
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [ID],[GroupName] ");
            strSql.Append(" FROM MemberGroup ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="PageIndex">当前第几页</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="strWhere">条件</param>
        /// <param name="Recordcount">记录总条数</param>
        /// <returns></returns>
        public DataSet Pager(int PageIndex, int PageSize, string strWhere, out int Recordcount)
        {
            if (string.IsNullOrEmpty(strWhere))
            {
                strWhere = " 1=1 ";
            }
            string strSql = string.Format("select top {0} * from MemberGroup where id not in (select top {1} id from MemberGroup where {2} order by id desc) and ({2}) order by id desc", PageSize, PageSize * (PageIndex - 1), strWhere);
            DataSet ds = DbHelperSQL.Query(strSql);

            string strSql2 = string.Format("select id from MemberGroup where {0}", strWhere);
            DataSet dsCount = DbHelperSQL.Query(strSql2);
            try
            {
                Recordcount = dsCount.Tables[0].Rows.Count;
            }
            catch
            {
                Recordcount = 0;
            }
            return ds;
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="_idstr"></param>
        /// <returns></returns>
        public int BatchDelete(string _idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete MemberGroup ");
            strSql.Append(string.Format(" where ID in ({0}) ", _idstr));
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        #endregion  成员方法
    }
}
