using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RptSummary_Dtl
	{
		public const string tbname = "RptSummary_Dtl";
		public int oid { get; set; }
		public string LDocNo { get; set; }
		public string LReleasePort { get; set; }
		public string RID { get; set; }
		public string RDocNo { get; set; }
		public string RReleasePort { get; set; }
		public string RefNo { get; set; }
		public DateTime LTransmitDate { get; set; }
		public DateTime RTransmitDate { get; set; }
		public int RowID { get; set; }
		public int LID { get; set; }

		public List<RptSummary_Dtl> get()
		{
			var rows = new List<RptSummary_Dtl>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RptSummary_Dtl()
						{
							oid = rd.GetInt32("oid"),
							LDocNo = rd.GetString("LDocNo"),
							LReleasePort = rd.GetString("LReleasePort"),
							RID = rd.GetString("RID"),
							RDocNo = rd.GetString("RDocNo"),
							RReleasePort = rd.GetString("RReleasePort"),
							RefNo = rd.GetString("RefNo"),
							LTransmitDate = rd.GetDateTime("LTransmitDate"),
							RTransmitDate = rd.GetDateTime("RTransmitDate"),
							RowID = rd.GetInt32("RowID"),
							LID = rd.GetInt32("LID")
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
						dr["LDocNo"] = this.LDocNo;
						dr["LReleasePort"] = this.LReleasePort;
						dr["RID"] = this.RID;
						dr["RDocNo"] = this.RDocNo;
						dr["RReleasePort"] = this.RReleasePort;
						dr["RefNo"] = this.RefNo;
						dr["RowID"] = this.RowID;
						dr["LID"] = this.LID;
						dr["LTransmitDate"] = this.LTransmitDate;
						dr["RTransmitDate"] = this.RTransmitDate;

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