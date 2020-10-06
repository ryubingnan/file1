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

namespace toho
{
    /// <summary>
    /// 类T_UserList。
    /// </summary>
    [Serializable]
    public partial class T_UserList
    {
        public T_UserList()
        { }
        #region Model
        private int _id;
        private string _mail;
        private string _password;
        private string _userid;
        private string _address;
        private string _tel;
        private string _fax;
        private string _sex;
        private string _type;
        private string _regdate;
        private string _country;
        private string _phone;
        private string _qq;
        private string _wc;
        private string _gsmc;
        private string _gsgj;
        private string _gsdz;
        private string _gsdh;
        private string _gscz;
        private string _gsyx;
        private string _date;
        private string _shop;
        private string _username;
        private int? _money;
        private string _purview;
        private string _fromweb;
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
        public string mail
        {
            set { _mail = value; }
            get { return _mail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fax
        {
            set { _fax = value; }
            get { return _fax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sex
        {
            set { _sex = value; }
            get { return _sex; }
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
        public string regdate
        {
            set { _regdate = value; }
            get { return _regdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string country
        {
            set { _country = value; }
            get { return _country; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
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
        public string wc
        {
            set { _wc = value; }
            get { return _wc; }
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
        public string gsgj
        {
            set { _gsgj = value; }
            get { return _gsgj; }
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
        public string gsdh
        {
            set { _gsdh = value; }
            get { return _gsdh; }
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
        public string gsyx
        {
            set { _gsyx = value; }
            get { return _gsyx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string date
        {
            set { _date = value; }
            get { return _date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string shop
        {
            set { _shop = value; }
            get { return _shop; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? money
        {
            set { _money = value; }
            get { return _money; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string purview
        {
            set { _purview = value; }
            get { return _purview; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fromWeb
        {
            set { _fromweb = value; }
            get { return _fromweb; }
        }
        #endregion Model


        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public T_UserList(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,mail,password,userID,address,tel,fax,sex,type,regdate,country,phone,qq,wc,gsmc,gsgj,gsdz,gsdh,gscz,gsyx,date,shop,userName,money,purview,fromWeb ");
            strSql.Append(" FROM [T_UserList] ");
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
                if (ds.Tables[0].Rows[0]["mail"] != null)
                {
                    this.mail = ds.Tables[0].Rows[0]["mail"].ToString();
                }
                if (ds.Tables[0].Rows[0]["password"] != null)
                {
                    this.password = ds.Tables[0].Rows[0]["password"].ToString();
                }
                if (ds.Tables[0].Rows[0]["userID"] != null)
                {
                    this.userID = ds.Tables[0].Rows[0]["userID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["address"] != null)
                {
                    this.address = ds.Tables[0].Rows[0]["address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["tel"] != null)
                {
                    this.tel = ds.Tables[0].Rows[0]["tel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["fax"] != null)
                {
                    this.fax = ds.Tables[0].Rows[0]["fax"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sex"] != null)
                {
                    this.sex = ds.Tables[0].Rows[0]["sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["type"] != null)
                {
                    this.type = ds.Tables[0].Rows[0]["type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["regdate"] != null)
                {
                    this.regdate = ds.Tables[0].Rows[0]["regdate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["country"] != null)
                {
                    this.country = ds.Tables[0].Rows[0]["country"].ToString();
                }
                if (ds.Tables[0].Rows[0]["phone"] != null)
                {
                    this.phone = ds.Tables[0].Rows[0]["phone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["qq"] != null)
                {
                    this.qq = ds.Tables[0].Rows[0]["qq"].ToString();
                }
                if (ds.Tables[0].Rows[0]["wc"] != null)
                {
                    this.wc = ds.Tables[0].Rows[0]["wc"].ToString();
                }
                if (ds.Tables[0].Rows[0]["gsmc"] != null)
                {
                    this.gsmc = ds.Tables[0].Rows[0]["gsmc"].ToString();
                }
                if (ds.Tables[0].Rows[0]["gsgj"] != null)
                {
                    this.gsgj = ds.Tables[0].Rows[0]["gsgj"].ToString();
                }
                if (ds.Tables[0].Rows[0]["gsdz"] != null)
                {
                    this.gsdz = ds.Tables[0].Rows[0]["gsdz"].ToString();
                }
                if (ds.Tables[0].Rows[0]["gsdh"] != null)
                {
                    this.gsdh = ds.Tables[0].Rows[0]["gsdh"].ToString();
                }
                if (ds.Tables[0].Rows[0]["gscz"] != null)
                {
                    this.gscz = ds.Tables[0].Rows[0]["gscz"].ToString();
                }
                if (ds.Tables[0].Rows[0]["gsyx"] != null)
                {
                    this.gsyx = ds.Tables[0].Rows[0]["gsyx"].ToString();
                }
                if (ds.Tables[0].Rows[0]["date"] != null)
                {
                    this.date = ds.Tables[0].Rows[0]["date"].ToString();
                }
                if (ds.Tables[0].Rows[0]["shop"] != null)
                {
                    this.shop = ds.Tables[0].Rows[0]["shop"].ToString();
                }
                if (ds.Tables[0].Rows[0]["userName"] != null)
                {
                    this.userName = ds.Tables[0].Rows[0]["userName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["money"] != null && ds.Tables[0].Rows[0]["money"].ToString() != "")
                {
                    this.money = int.Parse(ds.Tables[0].Rows[0]["money"].ToString());
                }
                if (ds.Tables[0].Rows[0]["purview"] != null)
                {
                    this.purview = ds.Tables[0].Rows[0]["purview"].ToString();
                }
                if (ds.Tables[0].Rows[0]["fromWeb"] != null)
                {
                    this.fromWeb = ds.Tables[0].Rows[0]["fromWeb"].ToString();
                }
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [T_UserList] (");
            strSql.Append("mail,password,userID,address,tel,fax,sex,type,regdate,country,phone,qq,wc,gsmc,gsgj,gsdz,gsdh,gscz,gsyx,date,shop,userName,money,purview,fromWeb)");
            strSql.Append(" values (");
            strSql.Append("@mail,@password,@userID,@address,@tel,@fax,@sex,@type,@regdate,@country,@phone,@qq,@wc,@gsmc,@gsgj,@gsdz,@gsdh,@gscz,@gsyx,@date,@shop,@userName,@money,@purview,@fromWeb)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@mail", SqlDbType.NVarChar,150),
                    new SqlParameter("@password", SqlDbType.NVarChar,150),
                    new SqlParameter("@userID", SqlDbType.NVarChar,50),
                    new SqlParameter("@address", SqlDbType.NVarChar,150),
                    new SqlParameter("@tel", SqlDbType.NVarChar,150),
                    new SqlParameter("@fax", SqlDbType.NVarChar,150),
                    new SqlParameter("@sex", SqlDbType.NVarChar,50),
                    new SqlParameter("@type", SqlDbType.NVarChar,50),
                    new SqlParameter("@regdate", SqlDbType.NVarChar,50),
                    new SqlParameter("@country", SqlDbType.NVarChar,50),
                    new SqlParameter("@phone", SqlDbType.NVarChar,150),
                    new SqlParameter("@qq", SqlDbType.NVarChar,150),
                    new SqlParameter("@wc", SqlDbType.NVarChar,150),
                    new SqlParameter("@gsmc", SqlDbType.NVarChar,150),
                    new SqlParameter("@gsgj", SqlDbType.NVarChar,150),
                    new SqlParameter("@gsdz", SqlDbType.NVarChar,150),
                    new SqlParameter("@gsdh", SqlDbType.NVarChar,150),
                    new SqlParameter("@gscz", SqlDbType.NVarChar,150),
                    new SqlParameter("@gsyx", SqlDbType.NVarChar,150),
                    new SqlParameter("@date", SqlDbType.NVarChar,150),
                    new SqlParameter("@shop", SqlDbType.NVarChar,150),
                    new SqlParameter("@userName", SqlDbType.NVarChar,150),
                    new SqlParameter("@money", SqlDbType.Int,4),
                    new SqlParameter("@purview", SqlDbType.NVarChar,50),
                    new SqlParameter("@fromWeb", SqlDbType.NVarChar,50)};
            parameters[0].Value = mail;
            parameters[1].Value = password;
            parameters[2].Value = userID;
            parameters[3].Value = address;
            parameters[4].Value = tel;
            parameters[5].Value = fax;
            parameters[6].Value = sex;
            parameters[7].Value = type;
            parameters[8].Value = regdate;
            parameters[9].Value = country;
            parameters[10].Value = phone;
            parameters[11].Value = qq;
            parameters[12].Value = wc;
            parameters[13].Value = gsmc;
            parameters[14].Value = gsgj;
            parameters[15].Value = gsdz;
            parameters[16].Value = gsdh;
            parameters[17].Value = gscz;
            parameters[18].Value = gsyx;
            parameters[19].Value = date;
            parameters[20].Value = shop;
            parameters[21].Value = userName;
            parameters[22].Value = money;
            parameters[23].Value = purview;
            parameters[24].Value = fromWeb;

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
            strSql.Append("update [T_UserList] set ");
            strSql.Append("mail=@mail,");
            strSql.Append("password=@password,");
            strSql.Append("userID=@userID,");
            strSql.Append("address=@address,");
            strSql.Append("tel=@tel,");
            strSql.Append("fax=@fax,");
            strSql.Append("sex=@sex,");
            strSql.Append("type=@type,");
            strSql.Append("regdate=@regdate,");
            strSql.Append("country=@country,");
            strSql.Append("phone=@phone,");
            strSql.Append("qq=@qq,");
            strSql.Append("wc=@wc,");
            strSql.Append("gsmc=@gsmc,");
            strSql.Append("gsgj=@gsgj,");
            strSql.Append("gsdz=@gsdz,");
            strSql.Append("gsdh=@gsdh,");
            strSql.Append("gscz=@gscz,");
            strSql.Append("gsyx=@gsyx,");
            strSql.Append("date=@date,");
            strSql.Append("shop=@shop,");
            strSql.Append("userName=@userName,");
            strSql.Append("money=@money,");
            strSql.Append("purview=@purview,");
            strSql.Append("fromWeb=@fromWeb");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@mail", SqlDbType.NVarChar,150),
                    new SqlParameter("@password", SqlDbType.NVarChar,150),
                    new SqlParameter("@userID", SqlDbType.NVarChar,50),
                    new SqlParameter("@address", SqlDbType.NVarChar,150),
                    new SqlParameter("@tel", SqlDbType.NVarChar,150),
                    new SqlParameter("@fax", SqlDbType.NVarChar,150),
                    new SqlParameter("@sex", SqlDbType.NVarChar,50),
                    new SqlParameter("@type", SqlDbType.NVarChar,50),
                    new SqlParameter("@regdate", SqlDbType.NVarChar,50),
                    new SqlParameter("@country", SqlDbType.NVarChar,50),
                    new SqlParameter("@phone", SqlDbType.NVarChar,150),
                    new SqlParameter("@qq", SqlDbType.NVarChar,150),
                    new SqlParameter("@wc", SqlDbType.NVarChar,150),
                    new SqlParameter("@gsmc", SqlDbType.NVarChar,150),
                    new SqlParameter("@gsgj", SqlDbType.NVarChar,150),
                    new SqlParameter("@gsdz", SqlDbType.NVarChar,150),
                    new SqlParameter("@gsdh", SqlDbType.NVarChar,150),
                    new SqlParameter("@gscz", SqlDbType.NVarChar,150),
                    new SqlParameter("@gsyx", SqlDbType.NVarChar,150),
                    new SqlParameter("@date", SqlDbType.NVarChar,150),
                    new SqlParameter("@shop", SqlDbType.NVarChar,150),
                    new SqlParameter("@userName", SqlDbType.NVarChar,150),
                    new SqlParameter("@money", SqlDbType.Int,4),
                    new SqlParameter("@purview", SqlDbType.NVarChar,50),
                    new SqlParameter("@fromWeb", SqlDbType.NVarChar,50),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = mail;
            parameters[1].Value = password;
            parameters[2].Value = userID;
            parameters[3].Value = address;
            parameters[4].Value = tel;
            parameters[5].Value = fax;
            parameters[6].Value = sex;
            parameters[7].Value = type;
            parameters[8].Value = regdate;
            parameters[9].Value = country;
            parameters[10].Value = phone;
            parameters[11].Value = qq;
            parameters[12].Value = wc;
            parameters[13].Value = gsmc;
            parameters[14].Value = gsgj;
            parameters[15].Value = gsdz;
            parameters[16].Value = gsdh;
            parameters[17].Value = gscz;
            parameters[18].Value = gsyx;
            parameters[19].Value = date;
            parameters[20].Value = shop;
            parameters[21].Value = userName;
            parameters[22].Value = money;
            parameters[23].Value = purview;
            parameters[24].Value = fromWeb;
            parameters[25].Value = id;

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
            strSql.Append("delete from [T_UserList] ");
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
            strSql.Append(" FROM [T_UserList] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}



