using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class Customs_Response_BillLog
	{
		public const string tbname = "Customs_Response_BillLog";
		public int oid { get; set; }
		public string MailID { get; set; }
		public string Customs_MailID { get; set; }
		public string MailType { get; set; }
		public DateTime SendBillingDate { get; set; }
		public DateTime SendBillingTime { get; set; }
		public DateTime ResponseBillingDate { get; set; }
        public DateTime ResponseBillingTime { get; set; }

		public List<Customs_Response_BillLog> get()
		{
			var rows = new List<Customs_Response_BillLog>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new Customs_Response_BillLog()
						{
							oid = rd.GetInt32("oid"),
							MailID = rd.GetString("MailID"),
							Customs_MailID = rd.GetString("Customs_MailID"),
							MailType = rd.GetString("MailType"),
							SendBillingDate = rd.GetDateTime("SendBillingDate"),
							SendBillingTime = rd.GetDateTime("SendBillingTime"),
							ResponseBillingDate = rd.GetDateTime("ResponseBillingDate"),
                            ResponseBillingTime = rd.GetDateTime("ResponseBillingTime")
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
						dr["MailID"] = this.MailID;
						dr["Customs_MailID"] = this.Customs_MailID;
						dr["MailType"] = this.MailType;
						dr["SendBillingDate"] = this.SendBillingDate;
						dr["SendBillingTime"] = this.SendBillingTime;
						dr["ResponseBillingDate"] = this.ResponseBillingDate;
                        dr["ResponseBillingTime"] = this.ResponseBillingTime;

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