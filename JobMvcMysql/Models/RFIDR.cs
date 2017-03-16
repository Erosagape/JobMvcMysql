using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFEDR
	{
		public const string tbname = "RFEDR";
		public int oid { get; set; }
		public string TariffClass { get; set; }
		public string TariffSeq { get; set; }
		public string DutyCode { get; set; }
		public string SpecCode { get; set; }
		public string DescTh { get; set; }
		public string DescEng { get; set; }
		public string AnnounceNo { get; set; }
		public string AnnounceDesc { get; set; }
		public string Description { get; set; }
		public DateTime AnnounceDate { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime FinishDate { get; set; }
		public DateTime LastUpdate { get; set; }
		public Double AdDutyRate { get; set; }
		public Double SpecDutyRate { get; set; }

		public List<RFEDR> get()
		{
			var rows = new List<RFEDR>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFEDR()
						{
							oid = rd.GetInt32("oid"),
							TariffClass = rd.GetString("TariffClass"),
							TariffSeq = rd.GetString("TariffSeq"),
							DutyCode = rd.GetString("DutyCode"),
							SpecCode = rd.GetString("SpecCode"),
							DescTh = rd.GetString("DescTh"),
							DescEng = rd.GetString("DescEng"),
							AnnounceNo = rd.GetString("AnnounceNo"),
							AnnounceDesc = rd.GetString("AnnounceDesc"),
							Description = rd.GetString("Description"),

							AnnounceDate = rd.GetDateTime("AnnounceDate"),
							StartDate = rd.GetDateTime("StartDate"),
							FinishDate = rd.GetDateTime("FinishDate"),
							LastUpdate = rd.GetDateTime("LastUpdate"),

							AdDutyRate = rd.GetDouble("AdDutyRate"),
							SpecDutyRate = rd.GetDouble("SpecDutyRate")
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
						dr["DutyCode"] = this.DutyCode;
						dr["SpecCode"] = this.SpecCode;
						dr["DescTh"] = this.DescTh;
						dr["DescEng"] = this.DescEng;
						dr["AnnounceNo"] = this.AnnounceNo;
						dr["AnnounceDesc"] = this.AnnounceDesc;
						dr["Description"] = this.Description;

						dr["AdDutyRate"] = this.AdDutyRate;
						dr["SpecDutyRate"] = this.SpecDutyRate;

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