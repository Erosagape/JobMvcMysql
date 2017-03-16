using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFCEP
	{
		public const string tbname = "RFCEP";
		public int oid { get; set; }
		public string TRFCLS { get; set; }
		public string CEPCDE { get; set; }
		public string TRFSEQ { get; set; }
		public string DSCTRS1 { get; set; }
		public string DSCTRS2 { get; set; }
		public string DSCTRS3 { get; set; }
		public string DSCTRS4 { get; set; }
		public string DSCTRS5 { get; set; }
		public string BNAGM { get; set; }
		public string IDAGM { get; set; }
		public string LAAGM { get; set; }
		public string MYAGM { get; set; }
		public string MMAGM { get; set; }
		public string PHAGM { get; set; }
		public string SGAGM { get; set; }
		public string VNAGM { get; set; }
		public string KHAGM { get; set; }
		public string UIDCTEAMN { get; set; }
		public DateTime DTESTR { get; set; }
		public DateTime DTEFIN { get; set; }
		public DateTime DTECTEAMN { get; set; }
		public DateTime TMECTEAMN { get; set; }
		public Double DTYRTE1 { get; set; }
		public Double DTYRTE2 { get; set; }
		public Double DTYSPE1 { get; set; }
		public Double DTYSPE2 { get; set; }

		public List<RFCEP> get()
		{
			var rows = new List<RFCEP>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFCEP()
						{
							oid = rd.GetInt32("oid"),
							TRFCLS = rd.GetString("TRFCLS"),
							CEPCDE = rd.GetString("CEPCDE"),
							TRFSEQ = rd.GetString("TRFSEQ"),
							DSCTRS1 = rd.GetString("DSCTRS1"),
							DSCTRS2 = rd.GetString("DSCTRS2"),
							DSCTRS3 = rd.GetString("DSCTRS3"),
							DSCTRS4 = rd.GetString("DSCTRS4"),
							DSCTRS5 = rd.GetString("DSCTRS5"),
							BNAGM = rd.GetString("BNAGM"),
							IDAGM = rd.GetString("IDAGM"),
							LAAGM = rd.GetString("LAAGM"),
							MYAGM = rd.GetString("MYAGM"),
							MMAGM = rd.GetString("MMAGM"),
							PHAGM = rd.GetString("PHAGM"),
							SGAGM = rd.GetString("SGAGM"),
							VNAGM = rd.GetString("VNAGM"),
							KHAGM = rd.GetString("KHAGM"),
							UIDCTEAMN = rd.GetString("UIDCTEAMN"),

							DTESTR = rd.GetDateTime("DTESTR"),
							DTEFIN = rd.GetDateTime("DTEFIN"),
							DTECTEAMN = rd.GetDateTime("DTECTEAMN"),
							TMECTEAMN = rd.GetDateTime("TMECTEAMN"),
							DTYRTE1 = rd.GetDouble("DTYRTE1"),
							DTYRTE2 = rd.GetDouble("DTYRTE2"),
							DTYSPE1 = rd.GetDouble("DTYSPE1"),
							DTYSPE2 = rd.GetDouble("DTYSPE2")
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
						dr["CEPCDE"] = this.CEPCDE;
						dr["TRFSEQ"] = this.TRFSEQ;
						dr["DSCTRS1"] = this.DSCTRS1;
						dr["DSCTRS2"] = this.DSCTRS2;
						dr["DSCTRS3"] = this.DSCTRS3;
						dr["DSCTRS4"] = this.DSCTRS4;
						dr["DSCTRS5"] = this.DSCTRS5;
						dr["BNAGM"] = this.BNAGM;
						dr["IDAGM"] = this.IDAGM;
						dr["LAAGM"] = this.LAAGM;
						dr["MYAGM"] = this.MYAGM;
						dr["MMAGM"] = this.MMAGM;
						dr["PHAGM"] = this.PHAGM;
						dr["SGAGM"] = this.SGAGM;
						dr["VNAGM"] = this.VNAGM;
						dr["KHAGM"] = this.KHAGM;
						dr["UIDCTEAMN"] = this.UIDCTEAMN;
						dr["DTYRTE1"] = this.DTYRTE1;
						dr["DTYRTE2"] = this.DTYRTE2;
						dr["DTYSPE1"] = this.DTYSPE1;
						dr["DTYSPE2"] = this.DTYSPE2;
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