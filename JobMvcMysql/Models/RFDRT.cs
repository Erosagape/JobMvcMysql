using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFDRT
	{
		public const string tbname = "RFDRT";
		public int oid { get; set; }
		public string TRFCLS { get; set; }
		public string TRFSEQ { get; set; }
		public string DTYCDE { get; set; }
		public string SPECDE { get; set; }
		public string ANONUM { get; set; }
		public string ANODES { get; set; }
		public string DSCTRS1 { get; set; }
		public string DSCTRS2 { get; set; }
		public string UIDCTEAMN { get; set; }
		public string PRVCDE { get; set; }
		public DateTime DTEANO { get; set; }
		public DateTime DTESTR { get; set; }
		public DateTime DTEFIN { get; set; }
		public DateTime DTECTEAMN { get; set; }
		public DateTime TMECTEAMN { get; set; }

		public List<RFDRT> get()
		{
			var rows = new List<RFDRT>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFDRT()
						{
							oid = rd.GetInt32("oid"),
							TRFCLS = rd.GetString("TRFCLS"),
							TRFSEQ = rd.GetString("TRFSEQ"),
							DTYCDE = rd.GetString("DTYCDE"),
							SPECDE = rd.GetString("SPECDE"),
							ANONUM = rd.GetString("ANONUM"),
							ANODES = rd.GetString("ANODES"),
							DSCTRS1 = rd.GetString("DSCTRS1"),
							DSCTRS2 = rd.GetString("DSCTRS2"),
							UIDCTEAMN = rd.GetString("UIDCTEAMN"),
							PRVCDE = rd.GetString("PRVCDE"),
							DTEANO = rd.GetDateTime("DTEANO"),
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
						dr["TRFCLS"] = this.TRFCLS;
						dr["TRFSEQ"] = this.TRFSEQ;
						dr["DTYCDE"] = this.DTYCDE;
						dr["SPECDE"] = this.SPECDE;
						dr["ANONUM"] = this.ANONUM;
						dr["ANODES"] = this.ANODES;
						dr["DSCTRS1"] = this.DSCTRS1;
						dr["DSCTRS2"] = this.DSCTRS2;
						dr["UIDCTEAMN"] = this.UIDCTEAMN;
						dr["PRVCDE"] = this.PRVCDE;
						dr["DTEANO"] = this.DTEANO;
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