using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class CompAccess
	{
		public const string tbname = "CompAccess";
		public int oid { get; set; }
		public string CompName { get; set; }
		public string AppName { get; set; }
		public DateTime OpenDate { get; set; }
		public DateTime OpenTime { get; set; }
		public DateTime CloseDate { get; set; }
		public DateTime CloseTime { get; set; }

		public List<CompAccess> get()
		{
			var rows = new List<CompAccess>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new CompAccess()
						{
							oid = rd.GetInt32("oid"),
							CompName = rd.GetString("CompName"),
							AppName = rd.GetString("AppName"),
							OpenDate = rd.GetDateTime("OpenDate"),
							OpenTime = rd.GetDateTime("OpenTime"),
							CloseDate = rd.GetDateTime("CloseDate"),
							CloseTime = rd.GetDateTime("CloseTime")
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
						dr["CompName"] = this.CompName;
						dr["AppName"] = this.AppName;

						dr["OpenDate"] = this.OpenDate;
						dr["OpenTime"] = this.OpenTime;
						dr["CloseDate"] = this.CloseDate;
						dr["CloseTime"] = this.CloseTime;

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