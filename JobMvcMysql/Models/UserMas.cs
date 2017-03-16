using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class UserMas
	{
		public const string tbname = "UserMas";
		public int oid { get; set; }
		public string UserID { get; set; }
		public string UPassword { get; set; }
		public string TName { get; set; }
		public string EName { get; set; }
		public string TPosition { get; set; }
		public string JobAuthorize { get; set; }
		public string EMail { get; set; }
		public string MobilePhone { get; set; }
		public string UserUpline { get; set; }
		public string GLAccountCode { get; set; }
		public string UsedLanguage { get; set; }
		public string DMailAccount { get; set; }
		public string DMailPassword { get; set; }
		public DateTime LoginDate { get; set; }
		public DateTime LoginTime { get; set; }
		public DateTime LogoutDate { get; set; }
		public DateTime LogoutTime { get; set; }
		public int UPosition { get; set; }
		public int IsAlertByAgent { get; set; }
		public int IsAlertByEMail { get; set; }
		public int IsAlertBySMS { get; set; }
		public Double MaxRateDisc { get; set; }
		public Double MaxAdvance { get; set; }

		public List<UserMas> get()
		{
			var rows = new List<UserMas>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new UserMas()
						{
							oid = rd.GetInt32("oid"),
							UserID = rd.GetString("UserID"),
							UPassword = rd.GetString("UPassword"),
							TName = rd.GetString("TName"),
							EName = rd.GetString("EName"),
							TPosition = rd.GetString("TPosition"),
							JobAuthorize = rd.GetString("JobAuthorize"),
							EMail = rd.GetString("EMail"),
							MobilePhone = rd.GetString("MobilePhone"),
							UserUpline = rd.GetString("UserUpline"),
							GLAccountCode = rd.GetString("GLAccountCode"),
							UsedLanguage = rd.GetString("UsedLanguage"),
							DMailAccount = rd.GetString("DMailAccount"),
							DMailPassword = rd.GetString("DMailPassword"),
							LoginDate = rd.GetDateTime("LoginDate"),
							LoginTime = rd.GetDateTime("LoginTime"),
							LogoutDate = rd.GetDateTime("LogoutDate"),
							LogoutTime = rd.GetDateTime("LogoutTime"),
							UPosition = rd.GetInt32("UPosition"),
							IsAlertByAgent = rd.GetInt32("IsAlertByAgent"),
							IsAlertByEMail = rd.GetInt32("IsAlertByEMail"),
							IsAlertBySMS = rd.GetInt32("IsAlertBySMS"),
							MaxRateDisc = rd.GetDouble("MaxRateDisc"),
							MaxAdvance = rd.GetDouble("MaxAdvance")
						});
					}
					rd.Close();
				}
				cn.Close();
			}
			return rows;
		}

		public string save()
		{
			using (Connection cn = new Connection())
			{
				try
				{
					string sql = string.Format("select * from " + tbname + " where oid='{0}'", this.oid);
					using (MysqlDataTable dt = new MysqlDataTable(sql, cn.getConnection()))
					{
						var tb = dt.data;
						var dr = tb.NewRow();
						if (tb.Rows.Count > 0)
						{
							dr = tb.Rows[0];
						}
						else
						{
							dr["oid"] = 0;
						}
						dr["UserID"] = this.UserID;
						dr["UPassword"] = this.UPassword;
						dr["TName"] = this.TName;
						dr["EName"] = this.EName;
						dr["TPosition"] = this.TPosition;
						dr["JobAuthorize"] = this.JobAuthorize;
						dr["EMail"] = this.EMail;
						dr["MobilePhone"] = this.MobilePhone;
						dr["UserUpline"] = this.UserUpline;
						dr["GLAccountCode"] = this.GLAccountCode;
						dr["UsedLanguage"] = this.UsedLanguage;
						dr["DMailAccount"] = this.DMailAccount;
						dr["DMailPassword"] = this.DMailPassword;
						dr["MaxRateDisc"] = this.MaxRateDisc;
						dr["MaxAdvance"] = this.MaxAdvance;
						dr["UPosition"] = this.UPosition;
						dr["IsAlertByAgent"] = this.IsAlertByAgent;
						dr["IsAlertByEMail"] = this.IsAlertByEMail;
						dr["IsAlertBySMS"] = this.IsAlertBySMS;
						dr["LoginDate"] = this.LoginDate;
						dr["LoginTime"] = this.LoginTime;
						dr["LogoutDate"] = this.LogoutDate;
						dr["LogoutTime"] = this.LogoutTime;

						if (dr.RowState.Equals(System.Data.DataRowState.Detached)) tb.Rows.Add(dr);
						dt.update();
					}
					return "Save Successfully";
				}
				catch (Exception e)
				{
					return e.Message;
				}
			}
		}

		public string delete(string oid)
		{
			string msg = "Delete Success";
			using (Connection cn = new Connection())
			{
				if (cn.ExecuteSQL(string.Format("delete from " + tbname + " where oid={0}", oid)) == false)
				{
					msg = cn.Message;
				}
			}
			return msg;
		}
	}
}