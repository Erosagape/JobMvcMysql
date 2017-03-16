using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFCKD
	{
		public const string tbname = "RFCKD";
		public int oid { get; set; }
		public string CKDAPRNUM { get; set; }
		public string BANNME { get; set; }
		public string PRDATB1 { get; set; }
		public string PRDCDE { get; set; }
		public string CMPTAXNUM { get; set; }
		public string CMPBRN { get; set; }
		public string PRTTYP { get; set; }
		public string DPMIDT { get; set; }
		public string JOBTYP { get; set; }
		public string CKDPRTNME { get; set; }
		public string PRTNTE { get; set; }
		public string UIDCTEAMN { get; set; }
		public DateTime DTESTR { get; set; }
		public DateTime DTEFIN { get; set; }
		public DateTime DTECTEAMN { get; set; }
		public DateTime TMECTEAMN { get; set; }
		public int CKDSEQNUM { get; set; }
		public int QTYPERUNT { get; set; }

		public List<RFCKD> get()
		{
			var rows = new List<RFCKD>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFCKD()
						{
							oid = rd.GetInt32("oid"),
							CKDAPRNUM = rd.GetString("CKDAPRNUM"),
							BANNME = rd.GetString("BANNME"),
							PRDATB1 = rd.GetString("PRDATB1"),
							PRDCDE = rd.GetString("PRDCDE"),
							CMPTAXNUM = rd.GetString("CMPTAXNUM"),
							CMPBRN = rd.GetString("CMPBRN"),
							PRTTYP = rd.GetString("PRTTYP"),
							DPMIDT = rd.GetString("DPMIDT"),
							JOBTYP = rd.GetString("JOBTYP"),
							CKDPRTNME = rd.GetString("CKDPRTNME"),
							PRTNTE = rd.GetString("PRTNTE"),
							UIDCTEAMN = rd.GetString("UIDCTEAMN"),

							DTESTR = rd.GetDateTime("DTESTR"),
							DTEFIN = rd.GetDateTime("DTEFIN"),
							DTECTEAMN = rd.GetDateTime("DTECTEAMN"),
							TMECTEAMN = rd.GetDateTime("TMECTEAMN"),
							CKDSEQNUM = rd.GetInt32("CKDSEQNUM"),
							QTYPERUNT = rd.GetInt32("QTYPERUNT")
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
						dr["CKDAPRNUM"] = this.CKDAPRNUM;
						dr["BANNME"] = this.BANNME;
						dr["PRDATB1"] = this.PRDATB1;
						dr["PRDCDE"] = this.PRDCDE;
						dr["CMPTAXNUM"] = this.CMPTAXNUM;
						dr["CMPBRN"] = this.CMPBRN;
						dr["PRTTYP"] = this.PRTTYP;
						dr["DPMIDT"] = this.DPMIDT;
						dr["JOBTYP"] = this.JOBTYP;
						dr["CKDPRTNME"] = this.CKDPRTNME;
						dr["PRTNTE"] = this.PRTNTE;
						dr["UIDCTEAMN"] = this.UIDCTEAMN;
						dr["CKDSEQNUM"] = this.CKDSEQNUM;
						dr["QTYPERUNT"] = this.QTYPERUNT;
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