using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class Currency
	{
		public int oid { get; set; }
		public string currencyCode { get; set; }
		public string currencyName { get; set; }
		public string countryCode { get; set; }
	}
	public class Country
	{
		public int oid { get; set; }
		public string countryCode { get; set; }
		public string countryName { get; set; }
		public List<Country> getCountry_all()
		{
			List<Country> rows = new List<Country>();
			using (Connection cn = new Connection()) 
			{
				using (var rd = cn.getDataReader("select * from Country"))
				{
					while (rd.Read())
					{
						rows.Add(new Country()
						{
							oid = rd.GetInt32("oid"),
							countryCode = rd.GetString("countryCode"),
							countryName = rd.GetString("countryName")
						});
					}
					rd.Close();
				}
				cn.Close();
			}
			return rows;
		}
		public string saveCountry() 
		{
			using (Connection cn = new Connection())
			{
				try
				{
					string sql = string.Format("select * from Country where oid='{0}'", this.oid);
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
						dr["countryCode"] = this.countryCode;
						dr["countryName"] = this.countryName;
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
	}
}
