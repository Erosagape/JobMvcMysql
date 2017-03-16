using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFERT
	{
		public const string tbname = "RFERT";
		public int oid { get; set; }
		public string UIDCTEAMN { get; set; }
		public DateTime DTESTR { get; set; }
		public DateTime DTEFIN { get; set; }
		public DateTime DTECTEAMN { get; set; }
		public DateTime TMECTEAMN { get; set; }
		public Double ERT { get; set; }
		public Double CSTWHLCL { get; set; }
		public Double CSTWOLCL { get; set; }

		public List<RFERT> get()
		{
			var rows = new List<RFERT>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFERT()
						{
							oid = rd.GetInt32("oid"),
							UIDCTEAMN = rd.GetString("UIDCTEAMN"),
							DTESTR = rd.GetDateTime("DTESTR"),
							DTEFIN = rd.GetDateTime("DTEFIN"),
							DTECTEAMN = rd.GetDateTime("DTECTEAMN"),
							TMECTEAMN = rd.GetDateTime("TMECTEAMN"),
							ERT = rd.GetDouble("ERT"),
							CSTWHLCL = rd.GetDouble("CSTWHLCL"),
							CSTWOLCL = rd.GetDouble("CSTWOLCL")
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
						dr["UIDCTEAMN"] = this.UIDCTEAMN;
						dr["ERT"] = this.ERT;
						dr["CSTWHLCL"] = this.CSTWHLCL;
						dr["CSTWOLCL"] = this.CSTWOLCL;
						dr["DTESTR"] = this.DTESTR;
						dr["DTEFIN"] = this.DTEFIN;
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