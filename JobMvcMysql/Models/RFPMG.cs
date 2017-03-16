using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFPMG
	{
		public const string tbname = "RFPMG";
		public int oid { get; set; }
		public string TariffClass { get; set; }
		public string TariffCode { get; set; }
		public string PermissionGT { get; set; }
		public string PermitIssue { get; set; }
		public string ValidateIndicator { get; set; }
		public string Country { get; set; }
		public string QUnit { get; set; }
		public string GoodsDesc1 { get; set; }
		public string GoodsDesc2 { get; set; }
		public string GoodsDesc3 { get; set; }
		public string GoodsDesc4 { get; set; }
		public string Condition { get; set; }
		public string AnnounceNo { get; set; }
		public DateTime AnnounceDate { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime FinishDate { get; set; }
		public Double Quantity { get; set; }

		public List<RFPMG> get()
		{
			var rows = new List<RFPMG>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFPMG()
						{
							oid = rd.GetInt32("oid"),
							TariffClass = rd.GetString("TariffClass"),
							TariffCode = rd.GetString("TariffCode"),
							PermissionGT = rd.GetString("PermissionGT"),
							PermitIssue = rd.GetString("PermitIssue"),
							ValidateIndicator = rd.GetString("ValidateIndicator"),
							Country = rd.GetString("Country"),
							QUnit = rd.GetString("QUnit"),
							GoodsDesc1 = rd.GetString("GoodsDesc1"),
							GoodsDesc2 = rd.GetString("GoodsDesc2"),
							GoodsDesc3 = rd.GetString("GoodsDesc3"),
							GoodsDesc4 = rd.GetString("GoodsDesc4"),
							Condition = rd.GetString("Condition"),
							AnnounceNo = rd.GetString("AnnounceNo"),
							AnnounceDate = rd.GetDateTime("AnnounceDate"),
							StartDate = rd.GetDateTime("StartDate"),
							FinishDate = rd.GetDateTime("FinishDate"),
                            Quantity = rd.GetDouble("Quantity")
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
						dr["TariffCode"] = this.TariffCode;
						dr["PermissionGT"] = this.PermissionGT;
						dr["PermitIssue"] = this.PermitIssue;
						dr["ValidateIndicator"] = this.ValidateIndicator;
						dr["Country"] = this.Country;
						dr["QUnit"] = this.QUnit;
						dr["GoodsDesc1"] = this.GoodsDesc1;
						dr["GoodsDesc2"] = this.GoodsDesc2;
						dr["GoodsDesc3"] = this.GoodsDesc3;
						dr["GoodsDesc4"] = this.GoodsDesc4;
						dr["Condition"] = this.Condition;
						dr["AnnounceNo"] = this.AnnounceNo;
						dr["Quantity"] = this.Quantity;
						dr["AnnounceDate"] = this.AnnounceDate;
						dr["StartDate"] = this.StartDate;
						dr["FinishDate"] = this.FinishDate;

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