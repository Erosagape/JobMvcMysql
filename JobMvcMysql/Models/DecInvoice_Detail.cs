using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class DecInvoice_Detail
	{
		public const string tbname = "DecInvoice_Detail";
		public int oid { get; set; }
		public string BranchCode { get; set; }
		public int ItemNO { get; set; }
		public int IsFreeOfChage { get; set; }
		public int ProductYear { get; set; }
		public int IncreasedPrice { get; set; }
		public int IncreasedPriceTHB { get; set; }
		public int DeclareLineNo { get; set; }
		public Double NetWeight { get; set; }
		public Double GrossWeight { get; set; }
		public Double TariffQty { get; set; }
		public Double ConstantValue { get; set; }
		public Double SalesPackQty { get; set; }
		public Double SalesPrice { get; set; }
		public Double SalesTotalPrice { get; set; }
		public Double SalesNetPriceTHB { get; set; }
		public Double SalesFOBPriceTHB { get; set; }
		public Double PackAmount { get; set; }
		public Double ExpShipping { get; set; }
		public string RefNO { get; set; }
		public string InvNO { get; set; }
		public string GroupCode { get; set; }
		public string PdtCode { get; set; }
		public string PdtSubCode { get; set; }
		public string BrandName { get; set; }
		public string ShippingMark { get; set; }
		public string PdtDescription { get; set; }
		public string PdtDescriptionEN { get; set; }
		public string DRemark { get; set; }
		public string DPurchaseCountry { get; set; }
		public string DOriginCountry { get; set; }
		public string ProductAttribute1 { get; set; }
		public string ProductAttribute2 { get; set; }
		public string SeperateItem { get; set; }
		public string TariffCode { get; set; }
		public string TariffSeq { get; set; }
		public string StatCode { get; set; }
		public string RTCProductCode { get; set; }
		public string WeightUnit { get; set; }
		public string TariffUnit { get; set; }
		public string SalesPackUnit { get; set; }
		public string PackUnit { get; set; }
		public string FormulaNo { get; set; }
		public string BIS19TransferNo { get; set; }
		public string BOILicenseNo { get; set; }
		public string BondFormulaNo { get; set; }
		public string PermitNo { get; set; }
		public string DutyCalcBy { get; set; }
		public string ItmOther1 { get; set; }
		public string ItmOther2 { get; set; }
		public string ItmOther3 { get; set; }
		public string ItmOther4 { get; set; }
		public string ItmOther5 { get; set; }
		public string ItmOther6 { get; set; }
		public string ItmOther7 { get; set; }
		public string ItmOther8 { get; set; }
		public string ItmOther9 { get; set; }
		public string ItmOther10 { get; set; }
		public string SalesPackAddUnit { get; set; }
		public string PackAddUnit { get; set; }
		public string ModelVer { get; set; }
		public string ModelCmpTaxNo { get; set; }
		public string Royalty { get; set; }
		public string RoyaltyDetail { get; set; }
		public Double ExpFreight { get; set; }
		public Double ExpInsurance { get; set; }
		public Double ExpForward { get; set; }
		public Double ExpInLand { get; set; }
		public Double ExpLanding { get; set; }
		public Double ExpPacking { get; set; }
		public Double ExpOther { get; set; }
		public Double ExpShippingTHB { get; set; }
		public Double ExpFreightTHB { get; set; }
		public Double ExpInsuranceTHB { get; set; }
		public Double ExpForwardTHB { get; set; }
		public Double ExpInLandTHB { get; set; }
		public Double ExpLandingTHB { get; set; }
		public Double ExpPackingTHB { get; set; }
		public Double ExpOtherTHB { get; set; }
		public Double DutyPRatePay { get; set; }
		public Double DutySRatePay { get; set; }
		public Double DutyDeduct { get; set; }
		public Double WeightPerUnit { get; set; }
		public Double WeightPerPack { get; set; }
		public Double SalesPackAddQty { get; set; }
		public Double PackAddAmount { get; set; }

		public List<DecInvoice_Detail> get()
		{
			var rows = new List<DecInvoice_Detail>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new DecInvoice_Detail()
						{
							oid = rd.GetInt32("oid"),
							BranchCode = rd.GetString("BranchCode"),
							ItemNO = rd.GetInt32("ItemNO"),
							IsFreeOfChage = rd.GetInt32("IsFreeOfChage"),
							ProductYear = rd.GetInt32("ProductYear"),
							IncreasedPrice = rd.GetInt32("IncreasedPrice"),
							IncreasedPriceTHB = rd.GetInt32("IncreasedPriceTHB"),
							DeclareLineNo = rd.GetInt32("DeclareLineNo"),
							NetWeight = rd.GetDouble("NetWeight"),
							GrossWeight = rd.GetDouble("GrossWeight"),
							TariffQty = rd.GetDouble("TariffQty"),
							ConstantValue = rd.GetDouble("ConstantValue"),
							SalesPackQty = rd.GetDouble("SalesPackQty"),
							SalesPrice = rd.GetDouble("SalesPrice"),
							SalesTotalPrice = rd.GetDouble("SalesTotalPrice"),
							SalesNetPriceTHB = rd.GetDouble("SalesNetPriceTHB"),
							SalesFOBPriceTHB = rd.GetDouble("SalesFOBPriceTHB"),
							PackAmount = rd.GetDouble("PackAmount"),
							ExpShipping = rd.GetDouble("ExpShipping"),
							RefNO = rd.GetString("RefNO"),
							InvNO = rd.GetString("InvNO"),
							GroupCode = rd.GetString("GroupCode"),
							PdtCode = rd.GetString("PdtCode"),
							PdtSubCode = rd.GetString("PdtSubCode"),
							BrandName = rd.GetString("BrandName"),
							ShippingMark = rd.GetString("ShippingMark"),
							PdtDescription = rd.GetString("PdtDescription"),
							PdtDescriptionEN = rd.GetString("PdtDescriptionEN"),
							DRemark = rd.GetString("DRemark"),
							DPurchaseCountry = rd.GetString("DPurchaseCountry"),
							DOriginCountry = rd.GetString("DOriginCountry"),
							ProductAttribute1 = rd.GetString("ProductAttribute1"),
							ProductAttribute2 = rd.GetString("ProductAttribute2"),
							SeperateItem = rd.GetString("SeperateItem"),
							TariffCode = rd.GetString("TariffCode"),
							TariffSeq = rd.GetString("TariffSeq"),
							StatCode = rd.GetString("StatCode"),
							RTCProductCode = rd.GetString("RTCProductCode"),
							WeightUnit = rd.GetString("WeightUnit"),
							TariffUnit = rd.GetString("TariffUnit"),
							SalesPackUnit = rd.GetString("SalesPackUnit"),
							PackUnit = rd.GetString("PackUnit"),
							ItmOther1 = rd.GetString("ItmOther1"),
							ItmOther2 = rd.GetString("ItmOther2"),
							ItmOther3 = rd.GetString("ItmOther3"),
							ItmOther4 = rd.GetString("ItmOther4"),
							ItmOther5 = rd.GetString("ItmOther5"),
							ItmOther6 = rd.GetString("ItmOther6"),
							ItmOther7 = rd.GetString("ItmOther7"),
							ItmOther8 = rd.GetString("ItmOther8"),
							ItmOther9 = rd.GetString("ItmOther9"),
							ItmOther10 = rd.GetString("ItmOther10"),
							FormulaNo = rd.GetString("FormulaNo"),
							BIS19TransferNo = rd.GetString("BIS19TransferNo"),
							BOILicenseNo = rd.GetString("BOILicenseNo"),
							BondFormulaNo = rd.GetString("BondFormulaNo"),
							PermitNo = rd.GetString("PermitNo"),
							DutyCalcBy = rd.GetString("DutyCalcBy"),
							SalesPackAddUnit = rd.GetString("SalesPackAddUnit"),
							PackAddUnit = rd.GetString("PackAddUnit"),
							ModelVer = rd.GetString("ModelVer"),
							ModelCmpTaxNo = rd.GetString("ModelCmpTaxNo"),
							Royalty = rd.GetString("Royalty"),
							RoyaltyDetail = rd.GetString("RoyaltyDetail"),
							ExpFreight = rd.GetDouble("ExpFreight"),
							ExpInsurance = rd.GetDouble("ExpInsurance"),
							ExpForward = rd.GetDouble("ExpForward"),
							ExpInLand = rd.GetDouble("ExpInLand"),
							ExpLanding = rd.GetDouble("ExpLanding"),
							ExpPacking = rd.GetDouble("ExpPacking"),
							ExpOther = rd.GetDouble("ExpOther"),
							ExpShippingTHB = rd.GetDouble("ExpShippingTHB"),
							ExpFreightTHB = rd.GetDouble("ExpFreightTHB"),
							ExpInsuranceTHB = rd.GetDouble("ExpInsuranceTHB"),
							ExpForwardTHB = rd.GetDouble("ExpForwardTHB"),
							ExpInLandTHB = rd.GetDouble("ExpInLandTHB"),
							ExpLandingTHB = rd.GetDouble("ExpLandingTHB"),
							ExpPackingTHB = rd.GetDouble("ExpPackingTHB"),
							ExpOtherTHB = rd.GetDouble("ExpOtherTHB"),
							DutyPRatePay = rd.GetDouble("DutyPRatePay"),
							DutySRatePay = rd.GetDouble("DutySRatePay"),
							DutyDeduct = rd.GetDouble("DutyDeduct"),
							WeightPerUnit = rd.GetDouble("WeightPerUnit"),
							WeightPerPack = rd.GetDouble("WeightPerPack"),
							SalesPackAddQty = rd.GetDouble("SalesPackAddQty"),
							PackAddAmount = rd.GetDouble("PackAddAmount")							                  
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
						dr["BranchCode"] = this.BranchCode;
						dr["ItemNO"] = this.ItemNO;
						dr["IsFreeOfChage"] = this.IsFreeOfChage;
						dr["ProductYear"] = this.ProductYear;
						dr["NetWeight"] = this.NetWeight;
						dr["GrossWeight"] = this.GrossWeight;
						dr["TariffQty"] = this.TariffQty;
						dr["ConstantValue"] = this.ConstantValue;
						dr["SalesPackQty"] = this.SalesPackQty;
						dr["SalesPrice"] = this.SalesPrice;
						dr["SalesTotalPrice"] = this.SalesTotalPrice;
						dr["SalesNetPriceTHB"] = this.SalesNetPriceTHB;
						dr["SalesFOBPriceTHB"] = this.SalesFOBPriceTHB;
						dr["PackAmount"] = this.PackAmount;
						dr["ExpShipping"] = this.ExpShipping;
						dr["RefNO"] = this.RefNO;
						dr["InvNO"] = this.InvNO;
						dr["GroupCode"] = this.GroupCode;
						dr["PdtCode"] = this.PdtCode;
						dr["PdtSubCode"] = this.PdtSubCode;
						dr["BrandName"] = this.BrandName;
						dr["ShippingMark"] = this.ShippingMark;
						dr["PdtDescription"] = this.PdtDescription;
						dr["PdtDescriptionEN"] = this.PdtDescriptionEN;
						dr["DRemark"] = this.DRemark;
						dr["DPurchaseCountry"] = this.DPurchaseCountry;
						dr["DOriginCountry"] = this.DOriginCountry;
						dr["ProductAttribute1"] = this.ProductAttribute1;
						dr["ProductAttribute2"] = this.ProductAttribute2;
						dr["SeperateItem"] = this.SeperateItem;
						dr["TariffCode"] = this.TariffCode;
						dr["TariffSeq"] = this.TariffSeq;
						dr["StatCode"] = this.StatCode;
						dr["RTCProductCode"] = this.RTCProductCode;
						dr["WeightUnit"] = this.WeightUnit;
						dr["TariffUnit"] = this.TariffUnit;
						dr["SalesPackUnit"] = this.SalesPackUnit;
						dr["PackUnit"] = this.PackUnit;
						dr["ExpFreight"] = this.ExpFreight;
						dr["ExpInsurance"] = this.ExpInsurance;
						dr["ExpForward"] = this.ExpForward;
						dr["ExpInLand"] = this.ExpInLand;
						dr["ExpLanding"] = this.ExpLanding;
						dr["ExpPacking"] = this.ExpPacking;
						dr["ExpOther"] = this.ExpOther;
						dr["ExpShippingTHB"] = this.ExpShippingTHB;
						dr["ExpFreightTHB"] = this.ExpFreightTHB;
						dr["ExpInsuranceTHB"] = this.ExpInsuranceTHB;
						dr["ExpForwardTHB"] = this.ExpForwardTHB;
						dr["ExpInLandTHB"] = this.ExpInLandTHB;
						dr["ExpLandingTHB"] = this.ExpLandingTHB;
						dr["ExpPackingTHB"] = this.ExpPackingTHB;
						dr["ExpOtherTHB"] = this.ExpOtherTHB;
						dr["IncreasedPrice"] = this.IncreasedPrice;
						dr["IncreasedPriceTHB"] = this.IncreasedPriceTHB;
						dr["DeclareLineNo"] = this.DeclareLineNo;
						dr["FormulaNo"] = this.FormulaNo;
						dr["BIS19TransferNo"] = this.BIS19TransferNo;
						dr["BOILicenseNo"] = this.BOILicenseNo;
						dr["BondFormulaNo"] = this.BondFormulaNo;
						dr["PermitNo"] = this.PermitNo;
						dr["DutyCalcBy"] = this.DutyCalcBy;
						dr["DutyPRatePay"] = this.DutyPRatePay;
						dr["DutySRatePay"] = this.DutySRatePay;
						dr["DutyDeduct"] = this.DutyDeduct;
						dr["WeightPerUnit"] = this.WeightPerUnit;
						dr["WeightPerPack"] = this.WeightPerPack;
						dr["ItmOther1"] = this.ItmOther1;
						dr["ItmOther2"] = this.ItmOther2;
						dr["ItmOther3"] = this.ItmOther3;
						dr["ItmOther4"] = this.ItmOther4;
						dr["ItmOther5"] = this.ItmOther5;
						dr["ItmOther6"] = this.ItmOther6;
						dr["ItmOther7"] = this.ItmOther7;
						dr["ItmOther8"] = this.ItmOther8;
						dr["ItmOther9"] = this.ItmOther9;
						dr["ItmOther10"] = this.ItmOther10;
						dr["SalesPackAddUnit"] = this.SalesPackAddUnit;
						dr["SalesPackAddQty"] = this.SalesPackAddQty;
						dr["PackAddAmount"] = this.PackAddAmount;
						dr["PackAddUnit"] = this.PackAddUnit;
						dr["ModelVer"] = this.ModelVer;
						dr["ModelCmpTaxNo"] = this.ModelCmpTaxNo;
						dr["Royalty"] = this.Royalty;
						dr["RoyaltyDetail"] = this.RoyaltyDetail;

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
