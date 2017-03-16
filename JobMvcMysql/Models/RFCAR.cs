using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFCAR
	{
		public const string tbname = "RFCAR";
		public int oid { get; set; }
		public string MANCDE { get; set; }
		public string SUBCDE { get; set; }
		public string TYPDSC { get; set; }
		public string UIDAMN { get; set; }
		public string MNT { get; set; }
		public DateTime DTESTR { get; set; }
		public DateTime DTEFIN { get; set; }
		public DateTime DTEAMN { get; set; }
		public DateTime TMEAMN { get; set; }

		public List<RFCAR> get()
		{
			var rows = new List<RFCAR>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFCAR()
						{
							oid = rd.GetInt32("oid"),
							MANCDE = rd.GetString("MANCDE"),
							SUBCDE = rd.GetString("SUBCDE"),
							TYPDSC = rd.GetString("TYPDSC"),
							UIDAMN = rd.GetString("UIDAMN"),
							MNT = rd.GetString("MNT"),
							DTESTR = rd.GetDateTime("DTESTR"),
							DTEFIN = rd.GetDateTime("DTEFIN"),
							DTEAMN = rd.GetDateTime("DTEAMN"),
							TMEAMN = rd.GetDateTime("TMEAMN")
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
						dr["MANCDE"] = this.MANCDE;
						dr["SUBCDE"] = this.SUBCDE;
						dr["TYPDSC"] = this.TYPDSC;
						dr["UIDAMN"] = this.UIDAMN;
						dr["MNT"] = this.MNT;
						dr["DTESTR"] = this.DTESTR;
						dr["DTEFIN"] = this.DTEFIN;
						dr["DTEAMN"] = this.DTEAMN;
						dr["TMEAMN"] = this.TMEAMN;

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