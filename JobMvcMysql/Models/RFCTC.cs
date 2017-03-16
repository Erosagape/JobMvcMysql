using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFCTC
	{
		public const string tbname = "RFCTC";
		public int oid { get; set; }
		public string CTRCDE { get; set; }
		public string CTRDSC { get; set; }
		public string CTRSIZ { get; set; }
		public string MNT { get; set; }
		public string UIDAMN { get; set; }
		public DateTime DTETMEAMN { get; set; }
		public DateTime DTESTR { get; set; }
		public DateTime DTEFIN { get; set; }

		public List<RFCTC> get()
		{
			var rows = new List<RFCTC>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFCTC()
						{
							oid = rd.GetInt32("oid"),
							CTRCDE = rd.GetString("CTRCDE"),
							CTRDSC = rd.GetString("CTRDSC"),
							CTRSIZ = rd.GetString("CTRSIZ"),
							MNT = rd.GetString("MNT"),
							UIDAMN = rd.GetString("UIDAMN"),
							DTETMEAMN = rd.GetDateTime("DTETMEAMN"),
							DTESTR = rd.GetDateTime("DTESTR"),
							DTEFIN = rd.GetDateTime("DTEFIN")
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
						dr["CTRCDE"] = this.CTRCDE;
						dr["CTRDSC"] = this.CTRDSC;
						dr["CTRSIZ"] = this.CTRSIZ;
						dr["MNT"] = this.MNT;
						dr["UIDAMN"] = this.UIDAMN;
						dr["DTETMEAMN"] = this.DTETMEAMN;
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