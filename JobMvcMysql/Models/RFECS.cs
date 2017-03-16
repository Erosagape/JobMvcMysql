using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFECS
	{
		public const string tbname = "RFECS";
		public int oid { get; set; }
		public string ECSNUM { get; set; }
		public string ECSCDE { get; set; }
		public string SPECDE { get; set; }
		public string CALAVRCDE { get; set; }
		public string CALSPE { get; set; }
		public string DIFCDE { get; set; }
		public string ANONUM { get; set; }
		public string UIDCTEAMN { get; set; }
		public DateTime DTESTR { get; set; }
		public DateTime DTEANO { get; set; }
		public DateTime DTEFIN { get; set; }
		public Double ECSRTE { get; set; }
		public Double ECSSPE { get; set; }

		public List<RFECS> get()
		{
			var rows = new List<RFECS>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFECS()
						{
							oid = rd.GetInt32("oid"),
							ECSNUM = rd.GetString("ECSNUM"),
							ECSCDE = rd.GetString("ECSCDE"),
							SPECDE = rd.GetString("SPECDE"),
							CALAVRCDE = rd.GetString("CALAVRCDE"),
							CALSPE = rd.GetString("CALSPE"),
							DIFCDE = rd.GetString("DIFCDE"),
							ANONUM = rd.GetString("ANONUM"),
							UIDCTEAMN = rd.GetString("UIDCTEAMN"),
							DTESTR = rd.GetDateTime("DTESTR"),
							DTEANO = rd.GetDateTime("DTEANO"),
							DTEFIN = rd.GetDateTime("DTEFIN"),
							ECSRTE = rd.GetDouble("ECSRTE"),
							ECSSPE = rd.GetDouble("ECSSPE")
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
						dr["ECSNUM"] = this.ECSNUM;
						dr["ECSCDE"] = this.ECSCDE;
						dr["SPECDE"] = this.SPECDE;
						dr["CALAVRCDE"] = this.CALAVRCDE;
						dr["CALSPE"] = this.CALSPE;
						dr["DIFCDE"] = this.DIFCDE;
						dr["ANONUM"] = this.ANONUM;
						dr["UIDCTEAMN"] = this.UIDCTEAMN;
						dr["ECSRTE"] = this.ECSRTE;
						dr["ECSSPE"] = this.ECSSPE;
						dr["DTESTR"] = this.DTESTR;
						dr["DTEANO"] = this.DTEANO;
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