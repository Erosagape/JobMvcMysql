using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class Broker
	{
		public const string tbname = "Broker";
		public int oid { get; set; }
		public string BrokerID { get; set; }
		public string BrokerName { get; set; }
		public string TStreet { get; set; }
		public string TDistrict { get; set; }
		public string TSubProvince { get; set; }
		public string TProvince { get; set; }
		public string TPostCode { get; set; }
		public string EMailAddress { get; set; }
		public string Branch { get; set; }
		public string BrokerTax13No { get; set; }
		public DateTime CardBeginDate { get; set; }
		public DateTime CardFinishDate { get; set; }
		public DateTime LastUpdate { get; set; }

		public List<Broker> get()
		{
			var rows = new List<Broker>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new Broker()
						{
							oid = rd.GetInt32("oid"),
							BrokerID = rd.GetString("BrokerID"),
							BrokerName = rd.GetString("BrokerName"),
							TStreet = rd.GetString("TStreet"),
							TDistrict = rd.GetString("TDistrict"),
							TSubProvince = rd.GetString("TSubProvince"),
							TProvince = rd.GetString("TProvince"),
							TPostCode = rd.GetString("TPostCode"),
							EMailAddress = rd.GetString("EMailAddress"),
							Branch = rd.GetString("Branch"),
							BrokerTax13No = rd.GetString("BrokerTax13No"),
							CardBeginDate = rd.GetDateTime("CardBeginDate"),
							CardFinishDate = rd.GetDateTime("CardFinishDate"),
							LastUpdate = rd.GetDateTime("LastUpdate")
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
						dr["BrokerID"] = this.BrokerID;
						dr["BrokerName"] = this.BrokerName;
						dr["TStreet"] = this.TStreet;
						dr["TDistrict"] = this.TDistrict;
						dr["TSubProvince"] = this.TSubProvince;
						dr["TProvince"] = this.TProvince;
						dr["TPostCode"] = this.TPostCode;
						dr["EMailAddress"] = this.EMailAddress;
						dr["Branch"] = this.Branch;
						dr["BrokerTax13No"] = this.BrokerTax13No;
						dr["CardBeginDate"] = this.CardBeginDate;
						dr["CardFinishDate"] = this.CardFinishDate;
						dr["LastUpdate"] = this.LastUpdate;

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