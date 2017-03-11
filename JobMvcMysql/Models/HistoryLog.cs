using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class HistoryLog
	{
		public const string tbname = "HistoryLog";
		public int oid { get; set; }
		public string EmpCode { get; set; }
		public string Description { get; set; }
		public DateTime LogDate { get; set; }
		public DateTime LogTime { get; set; }
		public int LogID { get; set; }
		public int LogType { get; set; }

		public List<HistoryLog> get()
		{
			var rows = new List<HistoryLog>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new HistoryLog()
						{
							oid = rd.GetInt32("oid"),
							EmpCode = rd.GetString("EmpCode"),
							Description = rd.GetString("Description"),
							LogDate = rd.GetDateTime("LogDate"),
							LogTime = rd.GetDateTime("LogTime"),
							LogID = rd.GetInt32("LogID"),
							LogType = rd.GetInt32("LogType")
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
						dr["EmpCode"] = this.EmpCode;
						dr["Description"] = this.Description;
						dr["LogID"] = this.LogID;
						dr["LogType"] = this.LogType;
						dr["LogDate"] = this.LogDate;
						dr["LogTime"] = this.LogTime;

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