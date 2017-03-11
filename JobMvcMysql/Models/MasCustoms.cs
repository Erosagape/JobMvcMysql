using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class MasCustoms
	{
		public const string tbname = "MasCustoms";
		public int oid { get; set; }
		public string CustID { get; set; }
		public string CustName { get; set; }
		public DateTime CardBeginDate { get; set; }
		public DateTime CardFinishDate { get; set; }
		public DateTime LastUpdate { get; set; }

		public List<MasCustoms> get()
		{
			var rows = new List<MasCustoms>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new MasCustoms()
						{
							oid = rd.GetInt32("oid"),
							CustID = rd.GetString("CustID"),
							CustName = rd.GetString("CustName"),
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
						dr["CustID"] = this.CustID;
						dr["CustName"] = this.CustName;
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