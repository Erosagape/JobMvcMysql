using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFDTB
	{
		public const string tbname = "RFDTB";
		public int oid { get; set; }
		public string DTBUNTCDE { get; set; }
		public string SUBUNTCDE { get; set; }
		public string UIDCTEAMN { get; set; }
		public DateTime DTEANO { get; set; }
		public DateTime DTESTR { get; set; }
		public DateTime DTECTEAMN { get; set; }
		public DateTime TMECTEAMN { get; set; }
		public Double DTBCST { get; set; }

		public List<RFDTB> get()
		{
			var rows = new List<RFDTB>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFDTB()
						{
							oid = rd.GetInt32("oid"),
							DTBUNTCDE = rd.GetString("DTBUNTCDE"),
							SUBUNTCDE = rd.GetString("SUBUNTCDE"),
							UIDCTEAMN = rd.GetString("UIDCTEAMN"),
							DTEANO = rd.GetDateTime("DTEANO"),
							DTESTR = rd.GetDateTime("DTESTR"),
							DTECTEAMN = rd.GetDateTime("DTECTEAMN"),
							TMECTEAMN = rd.GetDateTime("TMECTEAMN"),
							DTBCST = rd.GetDouble("DTBCST")
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
						dr["DTBUNTCDE"] = this.DTBUNTCDE;
						dr["SUBUNTCDE"] = this.SUBUNTCDE;
						dr["UIDCTEAMN"] = this.UIDCTEAMN;
						dr["DTBCST"] = this.DTBCST;
						dr["DTEANO"] = this.DTEANO;
						dr["DTESTR"] = this.DTESTR;
						dr["DTECTEAMN"] = this.DTECTEAMN;
						dr["TMECTEAMN"] = this.TMECTEAMN;

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