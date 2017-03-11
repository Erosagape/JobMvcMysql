using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class News
	{
		public const string tbname = "News";
		public int oid { get; set; }
		public string NewsID { get; set; }
		public string NewsType { get; set; }
		public string PaperStatus { get; set; }
		public string Descrp { get; set; }
		public string Refer { get; set; }
		public string NewsTime { get; set; }
		public DateTime NewsDate { get; set; }
		public DateTime LastGetDate { get; set; }
		public DateTime LastResponseDate { get; set; }
		public int NewsStatus { get; set; }
		public int Priority { get; set; }
		public int DisplayTimes { get; set; }

		public List<News> get()
		{
			var rows = new List<News>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new News()
						{
							oid = rd.GetInt32("oid"),
							NewsID = rd.GetString("NewsID"),
							NewsType = rd.GetString("NewsType"),
							PaperStatus = rd.GetString("PaperStatus"),
							Descrp = rd.GetString("Descrp"),
							Refer = rd.GetString("Refer"),
							NewsTime = rd.GetString("NewsTime"),
							NewsDate = rd.GetDateTime("NewsDate"),
							LastGetDate = rd.GetDateTime("LastGetDate"),
							LastResponseDate = rd.GetDateTime("LastResponseDate"),
							NewsStatus = rd.GetInt32("NewsStatus"),
							Priority = rd.GetInt32("Priority"),
							DisplayTimes = rd.GetInt32("DisplayTimes")
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
						dr["NewsID"] = this.NewsID;
						dr["NewsType"] = this.NewsType;
						dr["PaperStatus"] = this.PaperStatus;
						dr["Descrp"] = this.Descrp;
						dr["Refer"] = this.Refer;
						dr["NewsTime"] = this.NewsTime;
						dr["NewsStatus"] = this.NewsStatus;
						dr["Priority"] = this.Priority;
						dr["DisplayTimes"] = this.DisplayTimes;
						dr["NewsDate"] = this.NewsDate;
						dr["LastGetDate"] = this.LastGetDate;
						dr["LastResponseDate"] = this.LastResponseDate;

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