using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFGTY
	{
		public const string tbname = "RFGTY";
		public int oid { get; set; }
		public string Description { get; set; }
		public string UID { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime FinishDate { get; set; }
		public DateTime RecDate { get; set; }
		public DateTime RecTime { get; set; }
		public Double GoodsType { get; set; }

		public List<RFGTY> get()
		{
			var rows = new List<RFGTY>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFGTY()
						{
							oid = rd.GetInt32("oid"),
							Description = rd.GetString("Description"),
							UID = rd.GetString("UID"),
							StartDate = rd.GetDateTime("StartDate"),
							FinishDate = rd.GetDateTime("FinishDate"),
							RecDate = rd.GetDateTime("RecDate"),
							RecTime = rd.GetDateTime("RecTime"),
							GoodsType = rd.GetDouble("GoodsType")
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
						dr["Description"] = this.Description;
						dr["UID"] = this.UID;
						dr["GoodsType"] = this.GoodsType;
						dr["StartDate"] = this.StartDate;
						dr["FinishDate"] = this.FinishDate;
						dr["RecDate"] = this.RecDate;
						dr["RecTime"] = this.RecTime;

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