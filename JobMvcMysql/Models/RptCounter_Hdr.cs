using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RptCounter_Hdr
	{
		public const string tbname = "RptCounter_Hdr";
		public int oid { get; set; }
		public string RptMonth { get; set; }
		public string RptYear { get; set; }
		public string DocType { get; set; }

		public List<RptCounter_Hdr> get()
		{
			var rows = new List<RptCounter_Hdr>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RptCounter_Hdr()
						{
							oid = rd.GetInt32("oid"),
							RptMonth = rd.GetString("RptMonth"),
							RptYear = rd.GetString("RptYear"),
							DocType = rd.GetString("DocType")
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
						dr["RptMonth"] = this.RptMonth;
						dr["RptYear"] = this.RptYear;
						dr["DocType"] = this.DocType;

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