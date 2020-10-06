using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Data.SqlClient;


namespace YYCMS
{
    /// <summary>
    /// 类ShoppingCart。
    /// </summary>
    [Serializable]
    public partial class ShoppingCart
    {
        public ShoppingCart()
        { }
        #region Model
        private int _id;
        private int? _proid;
        private string _sessionid;
        private int? _pronum;
        private DateTime? _ctime;
        private int? _price1;
        private int? _price2;
        private string _proname;
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
        public int? ProID
        {
            set { _proid = value; }
            get { return _proid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SessionID
        {
            set { _sessionid = value; }
            get { return _sessionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ProNum
        {
            set { _pronum = value; }
            get { return _pronum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ctime
        {
            set { _ctime = value; }
            get { return _ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Price1
        {
            set { _price1 = value; }
            get { return _price1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Price2
        {
            set { _price2 = value; }
            get { return _price2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProName
        {
            set { _proname = value; }
            get { return _proname; }
        }
        #endregion Model


        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShoppingCart(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ProID,SessionID ,ProNum,ctime,Price1,Price2,ProName ");
            strSql.Append(" FROM [ShoppingCart] ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    this.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProID"] != null && ds.Tables[0].Rows[0]["ProID"].ToString() != "")
                {
                    this.ProID = int.Parse(ds.Tables[0].Rows[0]["ProID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SessionID "] != null && ds.Tables[0].Rows[0]["SessionID "].ToString() != "")
                {
                    this.SessionID = ds.Tables[0].Rows[0]["SessionID "].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProNum"] != null && ds.Tables[0].Rows[0]["ProNum"].ToString() != "")
                {
                    this.ProNum = int.Parse(ds.Tables[0].Rows[0]["ProNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ctime"] != null && ds.Tables[0].Rows[0]["ctime"].ToString() != "")
                {
                    this.ctime = DateTime.Parse(ds.Tables[0].Rows[0]["ctime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price1"] != null && ds.Tables[0].Rows[0]["Price1"].ToString() != "")
                {
                    this.Price1 = int.Parse(ds.Tables[0].Rows[0]["Price1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price2"] != null && ds.Tables[0].Rows[0]["Price2"].ToString() != "")
                {
                    this.Price2 = int.Parse(ds.Tables[0].Rows[0]["Price2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProName"] != null && ds.Tables[0].Rows[0]["ProName"].ToString() != "")
                {
                    this.ProName = ds.Tables[0].Rows[0]["ProName"].ToString();
                }
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [ShoppingCart] (");
            strSql.Append("ProID,SessionID ,ProNum,ctime,Price1,Price2,ProName)");
            strSql.Append(" values (");
            strSql.Append("@ProID,@SessionID ,@ProNum,@ctime,@Price1,@Price2,@ProName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ProID", SqlDbType.Int,4),
					new SqlParameter("@SessionID ", SqlDbType.NVarChar,50),
					new SqlParameter("@ProNum", SqlDbType.Int,4),
					new SqlParameter("@ctime", SqlDbType.DateTime),
					new SqlParameter("@Price1", SqlDbType.Int,4),
					new SqlParameter("@Price2", SqlDbType.Int,4),
					new SqlParameter("@ProName", SqlDbType.NVarChar,50)};
            parameters[0].Value = ProID;
            parameters[1].Value = SessionID;
            parameters[2].Value = ProNum;
            parameters[3].Value = ctime;
            parameters[4].Value = Price1;
            parameters[5].Value = Price2;
            parameters[6].Value = ProName;

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
        public int Update()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [ShoppingCart] set ");
            strSql.Append("ProID=@ProID,");
            strSql.Append("SessionID =@SessionID ,");
            strSql.Append("ProNum=@ProNum,");
            strSql.Append("ctime=@ctime,");
            strSql.Append("Price1=@Price1,");
            strSql.Append("Price2=@Price2,");
            strSql.Append("ProName=@ProName");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProID", SqlDbType.Int,4),
					new SqlParameter("@SessionID ", SqlDbType.NVarChar,50),
					new SqlParameter("@ProNum", SqlDbType.Int,4),
					new SqlParameter("@ctime", SqlDbType.DateTime),
					new SqlParameter("@Price1", SqlDbType.Int,4),
					new SqlParameter("@Price2", SqlDbType.Int,4),
					new SqlParameter("@ProName", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ProID;
            parameters[1].Value = SessionID;
            parameters[2].Value = ProNum;
            parameters[3].Value = ctime;
            parameters[4].Value = Price1;
            parameters[5].Value = Price2;
            parameters[6].Value = ProName;
            parameters[7].Value = ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [ShoppingCart] ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(string sessionid)
        {

            string strSql = string.Format("delete from ShoppingCart where SessionID='{0}'", sessionid);
            return DbHelperSQL.ExecuteSql(strSql);




        }








        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [ShoppingCart] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 更新购买数量
        /// </summary>

        public int UpdateProNum(int proNum, int id)
        {
            string strSql = string.Format(" update ShoppingCart set ProNum={0} where id={1}", proNum, id);
            return DbHelperSQL.ExecuteSql(strSql);
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
            string strSql = string.Format("select top {0} * from ShoppingCart where id not in (select top {1} id from ShoppingCart where {2} order by id desc) and ({2}) order by id desc", PageSize, PageSize * (PageIndex - 1), strWhere);
            DataSet ds = DbHelperSQL.Query(strSql);

            string strSql2 = string.Format("select id from ShoppingCart where {0}", strWhere);
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
            strSql.Append(" delete ShoppingCart ");
            strSql.Append(string.Format(" where ID in ({0}) ", _idstr));
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }





        #endregion  Method
    }
}

