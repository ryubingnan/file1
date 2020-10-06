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


namespace toho
{
    /// <summary>
    /// 类zfhy。
    /// </summary>
    [Serializable]
    public partial class zfhy
    {
        public zfhy()
        { }
        #region Model
        private int _id;
        private string _hyid;
        private string _hymm;
        private string _name;
        private string _sj;
        private string _qq;
        private string _gsmc;
        private string _gsdh;
        private DateTime? _date;
        private string _gj;
        private string _gssx;
        private string _gsbm;
        private string _gsbmsx;
        private string _yx;
        private string _gsdz;
        private string _gscz;
        private string _yhmc;
        private string _khzh;
        private string _zh;
        private string _hm;
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
        public string hyid
        {
            set { _hyid = value; }
            get { return _hyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hymm
        {
            set { _hymm = value; }
            get { return _hymm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sj
        {
            set { _sj = value; }
            get { return _sj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string qq
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gsmc
        {
            set { _gsmc = value; }
            get { return _gsmc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gsdh
        {
            set { _gsdh = value; }
            get { return _gsdh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? date
        {
            set { _date = value; }
            get { return _date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gj
        {
            set { _gj = value; }
            get { return _gj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gssx
        {
            set { _gssx = value; }
            get { return _gssx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gsbm
        {
            set { _gsbm = value; }
            get { return _gsbm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gsbmsx
        {
            set { _gsbmsx = value; }
            get { return _gsbmsx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string yx
        {
            set { _yx = value; }
            get { return _yx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gsdz
        {
            set { _gsdz = value; }
            get { return _gsdz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gscz
        {
            set { _gscz = value; }
            get { return _gscz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string yhmc
        {
            set { _yhmc = value; }
            get { return _yhmc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string khzh
        {
            set { _khzh = value; }
            get { return _khzh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zh
        {
            set { _zh = value; }
            get { return _zh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hm
        {
            set { _hm = value; }
            get { return _hm; }
        }
        #endregion Model


        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public zfhy(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,hyid,hymm,name,sj,qq,gsmc,gsdh,date,gj,gssx,gsbm,gsbmsx,yx,gsdz,gscz,yhmc,khzh,zh,hm ");
            strSql.Append(" FROM [zfhy] ");
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
                if (ds.Tables[0].Rows[0]["hyid"] != null)
                {
                    this.hyid = ds.Tables[0].Rows[0]["hyid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["hymm"] != null)
                {
                    this.hymm = ds.Tables[0].Rows[0]["hymm"].ToString();
                }
                if (ds.Tables[0].Rows[0]["name"] != null)
                {
                    this.name = ds.Tables[0].Rows[0]["name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sj"] != null)
                {
                    this.sj = ds.Tables[0].Rows[0]["sj"].ToString();
                }
                if (ds.Tables[0].Rows[0]["qq"] != null)
                {
                    this.qq = ds.Tables[0].Rows[0]["qq"].ToString();
                }
                if (ds.Tables[0].Rows[0]["gsmc"] != null)
                {
                    this.gsmc = ds.Tables[0].Rows[0]["gsmc"].ToString();
                }
                if (ds.Tables[0].Rows[0]["gsdh"] != null)
                {
                    this.gsdh = ds.Tables[0].Rows[0]["gsdh"].ToString();
                }
                if (ds.Tables[0].Rows[0]["date"] != null && ds.Tables[0].Rows[0]["date"].ToString() != "")
                {
                    this.date = DateTime.Parse(ds.Tables[0].Rows[0]["date"].ToString());
                }
                if (ds.Tables[0].Rows[0]["gj"] != null)
                {
                    this.gj = ds.Tables[0].Rows[0]["gj"].ToString();
                }
                if (ds.Tables[0].Rows[0]["gssx"] != null)
                {
                    this.gssx = ds.Tables[0].Rows[0]["gssx"].ToString();
                }
                if (ds.Tables[0].Rows[0]["gsbm"] != null)
                {
                    this.gsbm = ds.Tables[0].Rows[0]["gsbm"].ToString();
                }
                if (ds.Tables[0].Rows[0]["gsbmsx"] != null)
                {
                    this.gsbmsx = ds.Tables[0].Rows[0]["gsbmsx"].ToString();
                }
                if (ds.Tables[0].Rows[0]["yx"] != null)
                {
                    this.yx = ds.Tables[0].Rows[0]["yx"].ToString();
                }
                if (ds.Tables[0].Rows[0]["gsdz"] != null)
                {
                    this.gsdz = ds.Tables[0].Rows[0]["gsdz"].ToString();
                }
                if (ds.Tables[0].Rows[0]["gscz"] != null)
                {
                    this.gscz = ds.Tables[0].Rows[0]["gscz"].ToString();
                }
                if (ds.Tables[0].Rows[0]["yhmc"] != null)
                {
                    this.yhmc = ds.Tables[0].Rows[0]["yhmc"].ToString();
                }
                if (ds.Tables[0].Rows[0]["khzh"] != null)
                {
                    this.khzh = ds.Tables[0].Rows[0]["khzh"].ToString();
                }
                if (ds.Tables[0].Rows[0]["zh"] != null)
                {
                    this.zh = ds.Tables[0].Rows[0]["zh"].ToString();
                }
                if (ds.Tables[0].Rows[0]["hm"] != null)
                {
                    this.hm = ds.Tables[0].Rows[0]["hm"].ToString();
                }
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [zfhy] (");
            strSql.Append("hyid,hymm,name,sj,qq,gsmc,gsdh,date,gj,gssx,gsbm,gsbmsx,yx,gsdz,gscz,yhmc,khzh,zh,hm)");
            strSql.Append(" values (");
            strSql.Append("@hyid,@hymm,@name,@sj,@qq,@gsmc,@gsdh,@date,@gj,@gssx,@gsbm,@gsbmsx,@yx,@gsdz,@gscz,@yhmc,@khzh,@zh,@hm)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@hyid", SqlDbType.NVarChar,250),
					new SqlParameter("@hymm", SqlDbType.NVarChar,250),
					new SqlParameter("@name", SqlDbType.NVarChar,150),
					new SqlParameter("@sj", SqlDbType.NVarChar,150),
					new SqlParameter("@qq", SqlDbType.NVarChar,150),
					new SqlParameter("@gsmc", SqlDbType.NVarChar,250),
					new SqlParameter("@gsdh", SqlDbType.NVarChar,250),
					new SqlParameter("@date", SqlDbType.DateTime),
					new SqlParameter("@gj", SqlDbType.NVarChar,150),
					new SqlParameter("@gssx", SqlDbType.NVarChar,50),
					new SqlParameter("@gsbm", SqlDbType.NVarChar,150),
					new SqlParameter("@gsbmsx", SqlDbType.NVarChar,150),
					new SqlParameter("@yx", SqlDbType.NVarChar,150),
					new SqlParameter("@gsdz", SqlDbType.NVarChar,250),
					new SqlParameter("@gscz", SqlDbType.NVarChar,250),
					new SqlParameter("@yhmc", SqlDbType.NVarChar,150),
					new SqlParameter("@khzh", SqlDbType.NVarChar,150),
					new SqlParameter("@zh", SqlDbType.NVarChar,250),
					new SqlParameter("@hm", SqlDbType.NVarChar,50)};
            parameters[0].Value = hyid;
            parameters[1].Value = hymm;
            parameters[2].Value = name;
            parameters[3].Value = sj;
            parameters[4].Value = qq;
            parameters[5].Value = gsmc;
            parameters[6].Value = gsdh;
            parameters[7].Value = date;
            parameters[8].Value = gj;
            parameters[9].Value = gssx;
            parameters[10].Value = gsbm;
            parameters[11].Value = gsbmsx;
            parameters[12].Value = yx;
            parameters[13].Value = gsdz;
            parameters[14].Value = gscz;
            parameters[15].Value = yhmc;
            parameters[16].Value = khzh;
            parameters[17].Value = zh;
            parameters[18].Value = hm;

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
            strSql.Append("update [zfhy] set ");
            strSql.Append("hyid=@hyid,");
            strSql.Append("hymm=@hymm,");
            strSql.Append("name=@name,");
            strSql.Append("sj=@sj,");
            strSql.Append("qq=@qq,");
            strSql.Append("gsmc=@gsmc,");
            strSql.Append("gsdh=@gsdh,");
            strSql.Append("date=@date,");
            strSql.Append("gj=@gj,");
            strSql.Append("gssx=@gssx,");
            strSql.Append("gsbm=@gsbm,");
            strSql.Append("gsbmsx=@gsbmsx,");
            strSql.Append("yx=@yx,");
            strSql.Append("gsdz=@gsdz,");
            strSql.Append("gscz=@gscz,");
            strSql.Append("yhmc=@yhmc,");
            strSql.Append("khzh=@khzh,");
            strSql.Append("zh=@zh,");
            strSql.Append("hm=@hm");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@hyid", SqlDbType.NVarChar,250),
					new SqlParameter("@hymm", SqlDbType.NVarChar,250),
					new SqlParameter("@name", SqlDbType.NVarChar,150),
					new SqlParameter("@sj", SqlDbType.NVarChar,150),
					new SqlParameter("@qq", SqlDbType.NVarChar,150),
					new SqlParameter("@gsmc", SqlDbType.NVarChar,250),
					new SqlParameter("@gsdh", SqlDbType.NVarChar,250),
					new SqlParameter("@date", SqlDbType.DateTime),
					new SqlParameter("@gj", SqlDbType.NVarChar,150),
					new SqlParameter("@gssx", SqlDbType.NVarChar,50),
					new SqlParameter("@gsbm", SqlDbType.NVarChar,150),
					new SqlParameter("@gsbmsx", SqlDbType.NVarChar,150),
					new SqlParameter("@yx", SqlDbType.NVarChar,150),
					new SqlParameter("@gsdz", SqlDbType.NVarChar,250),
					new SqlParameter("@gscz", SqlDbType.NVarChar,250),
					new SqlParameter("@yhmc", SqlDbType.NVarChar,150),
					new SqlParameter("@khzh", SqlDbType.NVarChar,150),
					new SqlParameter("@zh", SqlDbType.NVarChar,250),
					new SqlParameter("@hm", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = hyid;
            parameters[1].Value = hymm;
            parameters[2].Value = name;
            parameters[3].Value = sj;
            parameters[4].Value = qq;
            parameters[5].Value = gsmc;
            parameters[6].Value = gsdh;
            parameters[7].Value = date;
            parameters[8].Value = gj;
            parameters[9].Value = gssx;
            parameters[10].Value = gsbm;
            parameters[11].Value = gsbmsx;
            parameters[12].Value = yx;
            parameters[13].Value = gsdz;
            parameters[14].Value = gscz;
            parameters[15].Value = yhmc;
            parameters[16].Value = khzh;
            parameters[17].Value = zh;
            parameters[18].Value = hm;
            parameters[19].Value = id;

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
            strSql.Append("delete from [zfhy] ");
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
            strSql.Append(" FROM [zfhy] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}

