using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFICC
	{
		public const string tbname = "RFICC";
		public int oid { get; set; }
		public string CountryCode { get; set; }
		public string CountryName { get; set; }
		public string CurrencyCode { get; set; }
		public string WTOCountry { get; set; }
		public string Continent { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime FinishDate { get; set; }
		public DateTime LastUpdate { get; set; }

		public List<RFICC> get()
		{
			var rows = new List<RFICC>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFICC()
						{
							oid = rd.GetInt32("oid"),
							CountryCode = rd.GetString("CountryCode"),
							CountryName = rd.GetString("CountryName"),
							CurrencyCode = rd.GetString("CurrencyCode"),
							WTOCountry = rd.GetString("WTOCountry"),
							Continent = rd.GetString("Continent"),
							StartDate = rd.GetDateTime("StartDate"),
							FinishDate = rd.GetDateTime("FinishDate"),
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
						dr["CountryCode"] = this.CountryCode;
						dr["CountryName"] = this.CountryName;
						dr["CurrencyCode"] = this.CurrencyCode;
						dr["WTOCountry"] = this.WTOCountry;
						dr["Continent"] = this.Continent;
						dr["StartDate"] = this.StartDate;
						dr["FinishDate"] = this.FinishDate;
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