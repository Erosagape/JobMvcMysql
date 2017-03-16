using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFETB
	{
		public const string tbname = "RFETB";
		public int oid { get; set; }
		public string ETBNUM { get; set; }
		public string ETBNME { get; set; }
		public string CMPTAXNUM { get; set; }
		public string CMPBRN { get; set; }
		public string ADR1 { get; set; }
		public string ADR2 { get; set; }
		public string PHN { get; set; }
		public string FAXNUM { get; set; }
		public string ETBOFRNME { get; set; }
		public string ETBFACCDE { get; set; }
		public string UIDCTEAMN { get; set; }
		public DateTime DTESTR { get; set; }
		public DateTime DTEFIN { get; set; }
		public DateTime DTECTEAMN { get; set; }
		public DateTime TMECTEAMN { get; set; }

		public List<RFETB> get()
		{
			var rows = new List<RFETB>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFETB()
						{
							oid = rd.GetInt32("oid"),
							ETBNUM = rd.GetString("ETBNUM"),
							ETBNME = rd.GetString("ETBNME"),
							CMPTAXNUM = rd.GetString("CMPTAXNUM"),
							CMPBRN = rd.GetString("CMPBRN"),
							ADR1 = rd.GetString("ADR1"),
							ADR2 = rd.GetString("ADR2"),
							PHN = rd.GetString("PHN"),
							FAXNUM = rd.GetString("FAXNUM"),
							ETBOFRNME = rd.GetString("ETBOFRNME"),
							ETBFACCDE = rd.GetString("ETBFACCDE"),
							UIDCTEAMN = rd.GetString("UIDCTEAMN"),

							DTESTR = rd.GetDateTime("DTESTR"),
							DTEFIN = rd.GetDateTime("DTEFIN"),
							DTECTEAMN = rd.GetDateTime("DTECTEAMN"),
							TMECTEAMN = rd.GetDateTime("TMECTEAMN")
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
						dr["ETBNUM"] = this.ETBNUM;
						dr["ETBNME"] = this.ETBNME;
						dr["CMPTAXNUM"] = this.CMPTAXNUM;
						dr["CMPBRN"] = this.CMPBRN;
						dr["ADR1"] = this.ADR1;
						dr["ADR2"] = this.ADR2;
						dr["PHN"] = this.PHN;
						dr["FAXNUM"] = this.FAXNUM;
						dr["ETBOFRNME"] = this.ETBOFRNME;
						dr["ETBFACCDE"] = this.ETBFACCDE;
						dr["UIDCTEAMN"] = this.UIDCTEAMN;
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