using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFFMU
	{
		public const string tbname = "RFFMU";
		public int oid { get; set; }
		public string FormulaNo { get; set; }
		public string TaxNumber { get; set; }
		public string Parent { get; set; }
		public string Desc1 { get; set; }
		public string Desc2 { get; set; }
		public string Desc3 { get; set; }
		public string Desc4 { get; set; }
		public string Desc5 { get; set; }
		public string UID { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime FinishDate { get; set; }
		public DateTime RecDate { get; set; }
		public DateTime RecTime { get; set; }

		public List<RFFMU> get()
		{
			var rows = new List<RFFMU>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFFMU()
						{
							oid = rd.GetInt32("oid"),
							FormulaNo = rd.GetString("FormulaNo"),
							TaxNumber = rd.GetString("TaxNumber"),
							Parent = rd.GetString("Parent"),
							Desc1 = rd.GetString("Desc1"),
							Desc2 = rd.GetString("Desc2"),
							Desc3 = rd.GetString("Desc3"),
							Desc4 = rd.GetString("Desc4"),
							Desc5 = rd.GetString("Desc5"),
							UID = rd.GetString("UID"),
							StartDate = rd.GetDateTime("StartDate"),
							FinishDate = rd.GetDateTime("FinishDate"),
							RecDate = rd.GetDateTime("RecDate"),
							RecTime = rd.GetDateTime("RecTime")
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
						dr["FormulaNo"] = this.FormulaNo;
						dr["TaxNumber"] = this.TaxNumber;
						dr["Parent"] = this.Parent;
						dr["Desc1"] = this.Desc1;
						dr["Desc2"] = this.Desc2;
						dr["Desc3"] = this.Desc3;
						dr["Desc4"] = this.Desc4;
						dr["Desc5"] = this.Desc5;
						dr["UID"] = this.UID;
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