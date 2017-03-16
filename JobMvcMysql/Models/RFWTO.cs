using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFWTO
	{
		public const string tbname = "RFWTO";
		public int oid { get; set; }
		public string TRFCLS { get; set; }
		public string TRFSEQ { get; set; }
		public string DTYCDE { get; set; }
		public string SPECDE { get; set; }
		public string ANONUM { get; set; }
		public string DSCTRS1 { get; set; }
		public string DSCTRS2 { get; set; }
		public DateTime DTEANO { get; set; }
		public DateTime DTESTR { get; set; }
		public DateTime DTEFIN { get; set; }
		public Double DTYYRTE { get; set; }
		public Double DTYSPE { get; set; }

		public List<RFWTO> get()
		{
			var rows = new List<RFWTO>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFWTO()
						{
							oid = rd.GetInt32("oid"),
							TRFCLS = rd.GetString("TRFCLS"),
							TRFSEQ = rd.GetString("TRFSEQ"),
							DTYCDE = rd.GetString("DTYCDE"),
							SPECDE = rd.GetString("SPECDE"),
							ANONUM = rd.GetString("ANONUM"),
							DSCTRS1 = rd.GetString("DSCTRS1"),
							DSCTRS2 = rd.GetString("DSCTRS2"),
							DTEANO = rd.GetDateTime("DTEANO"),
							DTESTR = rd.GetDateTime("DTESTR"),
							DTEFIN = rd.GetDateTime("DTEFIN"),
							DTYYRTE = rd.GetDouble("DTYYRTE"),
							DTYSPE = rd.GetDouble("DTYSPE")
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
						dr["DSCTRS1"] = this.DSCTRS1;
						dr["DSCTRS2"] = this.DSCTRS2;
						dr["DTYYRTE"] = this.DTYYRTE;
						dr["DTYSPE"] = this.DTYSPE;
						dr["DTEANO"] = this.DTEANO;
						dr["DTESTR"] = this.DTESTR;
						dr["DTEFIN"] = this.DTEFIN;

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