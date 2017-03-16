using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFTRS
	{
		public const string tbname = "RFTRS";
		public int oid { get; set; }
		public string TariffClass { get; set; }
		public string TariffStatCode { get; set; }
		public string GoodsUnitCode { get; set; }
		public string Desc1 { get; set; }
		public string Desc2 { get; set; }
		public string Desc3 { get; set; }
		public string Desc4 { get; set; }
		public string Desc5 { get; set; }
		public string StatDescThai { get; set; }
		public string StatDescEng { get; set; }
		public string AnnualNo { get; set; }
		public DateTime AnnualDate { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime FinishDate { get; set; }
		public DateTime LastUpDate { get; set; }

		public List<RFTRS> get()
		{
			var rows = new List<RFTRS>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFTRS()
						{
							oid = rd.GetInt32("oid"),
							TariffClass = rd.GetString("TariffClass"),
							TariffStatCode = rd.GetString("TariffStatCode"),
							GoodsUnitCode = rd.GetString("GoodsUnitCode"),
							Desc1 = rd.GetString("Desc1"),
							Desc2 = rd.GetString("Desc2"),
							Desc3 = rd.GetString("Desc3"),
							Desc4 = rd.GetString("Desc4"),
							Desc5 = rd.GetString("Desc5"),
							StatDescThai = rd.GetString("StatDescThai"),
							StatDescEng = rd.GetString("StatDescEng"),
							AnnualNo = rd.GetString("AnnualNo"),
							AnnualDate = rd.GetDateTime("AnnualDate"),
							StartDate = rd.GetDateTime("StartDate"),
							FinishDate = rd.GetDateTime("FinishDate"),
							LastUpDate = rd.GetDateTime("LastUpDate")
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
						dr["TariffClass"] = this.TariffClass;
						dr["TariffStatCode"] = this.TariffStatCode;
						dr["GoodsUnitCode"] = this.GoodsUnitCode;
						dr["Desc1"] = this.Desc1;
						dr["Desc2"] = this.Desc2;
						dr["Desc3"] = this.Desc3;
						dr["Desc4"] = this.Desc4;
						dr["Desc5"] = this.Desc5;
						dr["StatDescThai"] = this.StatDescThai;
						dr["StatDescEng"] = this.StatDescEng;
						dr["AnnualNo"] = this.AnnualNo;
						dr["AnnualDate"] = this.AnnualDate;
						dr["StartDate"] = this.StartDate;
						dr["FinishDate"] = this.FinishDate;
						dr["LastUpDate"] = this.LastUpDate;

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