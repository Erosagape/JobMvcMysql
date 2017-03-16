using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFCTR
	{
		public const string tbname = "RFCTR";
		public int oid { get; set; }
		public string TariffClass { get; set; }
		public string TariffSeq { get; set; }
		public string AnnounceNo { get; set; }
		public DateTime AnnounceDate { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime FinishDate { get; set; }
		public DateTime LastUpdate { get; set; }
		public Double CompensationRate { get; set; }

		public List<RFCTR> get()
		{
			var rows = new List<RFCTR>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFCTR()
						{
							oid = rd.GetInt32("oid"),
							TariffClass = rd.GetString("TariffClass"),
							TariffSeq = rd.GetString("TariffSeq"),
							AnnounceNo = rd.GetString("AnnounceNo"),
							AnnounceDate = rd.GetDateTime("AnnounceDate"),
							StartDate = rd.GetDateTime("StartDate"),
							FinishDate = rd.GetDateTime("FinishDate"),
							LastUpdate = rd.GetDateTime("LastUpdate"),
							CompensationRate = rd.GetDouble("CompensationRate")
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
						dr["TariffClass"] = this.TariffClass;
						dr["TariffSeq"] = this.TariffSeq;
						dr["AnnounceNo"] = this.AnnounceNo;
						dr["CompensationRate"] = this.CompensationRate;
						dr["AnnounceDate"] = this.AnnounceDate;
						dr["StartDate"] = this.StartDate;
						dr["FinishDate"] = this.FinishDate;
						dr["LastUpdate"] = this.LastUpdate;

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