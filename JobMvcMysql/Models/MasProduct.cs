using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class MasProduct
	{
		public const string tbname = "MasProduct";
		public int oid { get; set; }
        public string TaxNumber { get; set; }
		public string SubCode { get; set; }
		public string SubDescEng { get; set; }
		public string SubDescThai { get; set; }
		public string SubLabel { get; set; }
		public string TariffClass { get; set; }		
		public string TariffSeq { get; set; }
		public string TariffStatCode { get; set; }
		public string Remark { get; set; }
		public string AFTACode { get; set; }
		public string ExciseNo { get; set; }
		public string RTCCode { get; set; }
		public string PrivilegeCode { get; set; }
		public string ExportTariff { get; set; }
		public string UNDGNumber { get; set; }
		public string OriginalUnit { get; set; }
		public string WeightUnit { get; set; }
		public string PackRatio { get; set; }
		public string SalesPackUnit { get; set; }
		public string SalesPrice { get; set; }
		public string PackageUnit { get; set; }
		public string BrandName { get; set; }
		public string MarkDesc1 { get; set; }
		public string MarkDesc2 { get; set; }
		public string FormulaNo { get; set; }
		public string BondNo { get; set; }
		public string BOINo { get; set; }
		public string BOIQuotaCode { get; set; }
		public string BOIQuotaNo { get; set; }
		public string Code { get; set; }
		public string ExciseDutyType { get; set; }
		public string PermitNo { get; set; }
		public string TbTransNo { get; set; }
		public string GroupCode { get; set; }
		public string DecDesc4 { get; set; }
		public string DecDesc5 { get; set; }
		public DateTime LastUpdate { get; set; }
		public int ProductYear { get; set; }
		public int CalcPriceFrom { get; set; }
		public int BOIType { get; set; }
		public int Compen { get; set; }
		public Double AnnPrice { get; set; }
		public Double SalesPackPerQty { get; set; }
		public Double UnitPrice { get; set; }
		public Double UnitNW { get; set; }

		public List<MasProduct> get()
		{
			var rows = new List<MasProduct>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new MasProduct()
						{
							oid = rd.GetInt32("oid"),
							SubCode = rd.GetString("SubCode"),
							SubDescEng = rd.GetString("SubDescEng"),
							SubDescThai = rd.GetString("SubDescThai"),
							SubLabel = rd.GetString("SubLabel"),
							TariffClass = rd.GetString("TariffClass"),
							TaxNumber = rd.GetString("TaxNumber"),
							TariffSeq = rd.GetString("TariffSeq"),
							TariffStatCode = rd.GetString("TariffStatCode"),
							Remark = rd.GetString("Remark"),
							AFTACode = rd.GetString("AFTACode"),
							ExciseNo = rd.GetString("ExciseNo"),
							RTCCode = rd.GetString("RTCCode"),
							PrivilegeCode = rd.GetString("PrivilegeCode"),
							ExportTariff = rd.GetString("ExportTariff"),
							UNDGNumber = rd.GetString("UNDGNumber"),
							OriginalUnit = rd.GetString("OriginalUnit"),
							WeightUnit = rd.GetString("WeightUnit"),
							PackRatio = rd.GetString("PackRatio"),
							SalesPackUnit = rd.GetString("SalesPackUnit"),
							SalesPrice = rd.GetString("SalesPrice"),
							PackageUnit = rd.GetString("PackageUnit"),
							BrandName = rd.GetString("BrandName"),
							MarkDesc1 = rd.GetString("MarkDesc1"),
							MarkDesc2 = rd.GetString("MarkDesc2"),
							ExciseDutyType = rd.GetString("ExciseDutyType"),
							PermitNo = rd.GetString("PermitNo"),
							TbTransNo = rd.GetString("TbTransNo"),
							GroupCode = rd.GetString("GroupCode"),
							DecDesc4 = rd.GetString("DecDesc4"),
							DecDesc5 = rd.GetString("DecDesc5"),
							LastUpdate = rd.GetDateTime("LastUpdate"),
							ProductYear = rd.GetInt32("ProductYear"),
							CalcPriceFrom = rd.GetInt32("CalcPriceFrom"),
							BOIType = rd.GetInt32("BOIType"),
							Compen = rd.GetInt32("Compen"),
							AnnPrice = rd.GetDouble("AnnPrice"),
							SalesPackPerQty = rd.GetDouble("SalesPackPerQty"),
							UnitPrice = rd.GetDouble("UnitPrice"),
							UnitNW = rd.GetDouble("UnitNW")
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
						dr["SubCode"] = this.SubCode;
						dr["SubDescEng"] = this.SubDescEng;
						dr["SubDescThai"] = this.SubDescThai;
						dr["SubLabel"] = this.SubLabel;
						dr["TariffClass"] = this.TariffClass;
						dr["TaxNumber"] = this.TaxNumber;
						dr["TariffSeq"] = this.TariffSeq;
						dr["TariffStatCode"] = this.TariffStatCode;
						dr["Remark"] = this.Remark;
						dr["AFTACode"] = this.AFTACode;
						dr["ExciseNo"] = this.ExciseNo;
						dr["RTCCode"] = this.RTCCode;
						dr["PrivilegeCode"] = this.PrivilegeCode;
						dr["ExportTariff"] = this.ExportTariff;
						dr["UNDGNumber"] = this.UNDGNumber;
						dr["OriginalUnit"] = this.OriginalUnit;
						dr["WeightUnit"] = this.WeightUnit;
						dr["PackRatio"] = this.PackRatio;
						dr["SalesPackUnit"] = this.SalesPackUnit;
						dr["SalesPrice"] = this.SalesPrice;
						dr["PackageUnit"] = this.PackageUnit;
						dr["BrandName"] = this.BrandName;
						dr["MarkDesc1"] = this.MarkDesc1;
						dr["MarkDesc2"] = this.MarkDesc2;
						dr["FormulaNo"] = this.FormulaNo;
						dr["BondNo"] = this.BondNo;
						dr["BOINo"] = this.BOINo;
						dr["BOIQuotaCode"] = this.BOIQuotaCode;
						dr["BOIQuotaNo"] = this.BOIQuotaNo;
						dr["Code"] = this.Code;
						dr["ExciseDutyType"] = this.ExciseDutyType;
						dr["PermitNo"] = this.PermitNo;
						dr["TbTransNo"] = this.TbTransNo;
						dr["GroupCode"] = this.GroupCode;
						dr["DecDesc4"] = this.DecDesc4;
						dr["DecDesc5"] = this.DecDesc5;

						dr["AnnPrice"] = this.AnnPrice;
						dr["SalesPackPerQty"] = this.SalesPackPerQty;
						dr["UnitPrice"] = this.UnitPrice;
						dr["UnitNW"] = this.UnitNW;

						dr["ProductYear"] = this.ProductYear;
						dr["CalcPriceFrom"] = this.CalcPriceFrom;
						dr["BOIType"] = this.BOIType;
						dr["Compen"] = this.Compen;

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