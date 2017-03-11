using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class Declare_Detail
	{
		public const string tbname = "Declare_Detail";
		public int oid { get; set; }
		public string BranchCode { get; set; }
		public string RefNO { get; set; }
		public string InvNo { get; set; }
		public string InvItemNO { get; set; }
		public string PrivilegeCode { get; set; }
		public string TariffCode { get; set; }
		public string TariffSeq { get; set; }
		public string StatCode { get; set; }
		public string TariffUnit { get; set; }
		public string DUNDGNumber { get; set; }
		public string InvUnit { get; set; }
		public string PackUnit { get; set; }
		public string DDRemark { get; set; }
		public string DPurchaseCountry { get; set; }
		public string DOriginCountry { get; set; }
		public string ExportTariff { get; set; }
		public string BrandName { get; set; }
		public string PdtCode { get; set; }
		public string CustomsPdtCode { get; set; }
		public string PdtDescription { get; set; }
		public string PdtDescriptionEN { get; set; }
		public string ProductAttribute1 { get; set; }
		public string ProductAttribute2 { get; set; }
		public string DRemark { get; set; }
		public string FormulaNo { get; set; }
		public string ImpLodgedPort { get; set; }
		public string ImpDecNO { get; set; }
		public string ImpRefNo { get; set; }
		public string UNDGNumber { get; set; }
		public string NatureTrans { get; set; }
		public string AHTNCode { get; set; }
		public string ExciseNo { get; set; }
		public string ExciseUnit { get; set; }
		public string ArgumentTariffCode { get; set; }
		public string BIS19TransferNo { get; set; }
		public string BOILicenseNo { get; set; }
		public string BondFormulaNo { get; set; }
		public string PermitNo { get; set; }
		public string CalculateBy { get; set; }
		public string DepositReason { get; set; }
		public string QtyAddUnit { get; set; }
		public string PackAddUnit { get; set; }
		public string GroupCode { get; set; }
		public string PdtSubCode { get; set; }
		public string DutyCalcBy { get; set; }
		public string PdtDescription2 { get; set; }
		public string PdtDescriptionEN2 { get; set; }
		public string Remark2 { get; set; }
		public string ShippingMark2 { get; set; }
		public string ImportTaxIncentivesID { get; set; }
		public string ArgumentTariffSeq { get; set; }
		public string ArgumentExportTariff { get; set; }
		public string OriginCriteria { get; set; }
		public string ArgumentReasonCode { get; set; }
		public string CertExporterNo { get; set; }
		public string ProcedureCode { get; set; }
		public string ValuationCode { get; set; }
		public string ModelNo { get; set; }
		public string ModelVer { get; set; }
		public string ModelCmpTaxNo { get; set; }
		public string ArgumentPrivilegeCode { get; set; }
		public string Royalty { get; set; }
		public string RoyaltyDetail { get; set; }
		public string ItmRemark2 { get; set; }
		public string CmpPdtCode { get; set; }

		public int ItemNO { get; set; }
		public int IsFreeOfCharge { get; set; }
		public int IsComp { get; set; }
		public int IsReImport { get; set; }
		public int IsBOI { get; set; }
		public int IsBond { get; set; }
		public int Is19BIS { get; set; }
		public int IsReExport { get; set; }
		public int IsFreeZone { get; set; }
		public int IsEPZ { get; set; }
		public int IsSeveral { get; set; }
		public int ImpLineNo { get; set; }
		public int ProductYear { get; set; }
		public int Revised { get; set; }
		public int QtyRemark { get; set; }
		public int SeperateItem { get; set; }
		public int ConstantValue { get; set; }
		public int DeductedAmount { get; set; }
		public int ArgumentSpecCalBy { get; set; }

		public Double TariffQty { get; set; }
		public Double InvQty { get; set; }
		public Double DUnitPriceF { get; set; }
		public Double DUnitPriceB { get; set; }
		public Double DCurRate { get; set; }
		public Double DFOBValueF { get; set; }
		public Double DFOBValueB { get; set; }
		public Double DIncreaseAmtF { get; set; }
		public Double DIncreaseAmtB { get; set; }
		public Double DInvAmtF { get; set; }
		public Double DInvAmtB { get; set; }
		public Double DFOBValueAss { get; set; }
		public Double PackAmount { get; set; }

		public Double NetWeight { get; set; }
		public Double GrossWeight { get; set; }
		public Double AssertQty { get; set; }
		public Double ExemptAmtB { get; set; }
		public Double ExciseQty { get; set; }
		public Double ExciseAssQty { get; set; }
		public Double PackAddAmount { get; set; }

		public Double ExpShipping { get; set; }
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
		public Double ArgumentValueRate { get; set; }
		public Double ArgumentSpecRate { get; set; }

		public List<Declare_Detail> get()
		{
			var rows = new List<Declare_Detail>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new Declare_Detail()
						{
							oid = rd.GetInt32("oid"),
							BranchCode = rd.GetString("BranchCode"),
							RefNO = rd.GetString("RefNO"),
							InvNo = rd.GetString("InvNo"),
							InvItemNO = rd.GetString("InvItemNO"),
							PrivilegeCode = rd.GetString("PrivilegeCode"),
							TariffCode = rd.GetString("TariffCode"),
							TariffSeq = rd.GetString("TariffSeq"),
							StatCode = rd.GetString("StatCode"),
							TariffUnit = rd.GetString("TariffUnit"),
							DUNDGNumber = rd.GetString("DUNDGNumber"),
							InvUnit = rd.GetString("InvUnit"),
							PackUnit = rd.GetString("PackUnit"),
							DDRemark = rd.GetString("DDRemark"),
							DPurchaseCountry = rd.GetString("DPurchaseCountry"),
							DOriginCountry = rd.GetString("DOriginCountry"),
							ExportTariff = rd.GetString("ExportTariff"),
							BrandName = rd.GetString("BrandName"),
							PdtCode = rd.GetString("PdtCode"),
							CustomsPdtCode = rd.GetString("CustomsPdtCode"),
							PdtDescription = rd.GetString("PdtDescription"),
							PdtDescriptionEN = rd.GetString("PdtDescriptionEN"),
							ProductAttribute1 = rd.GetString("ProductAttribute1"),
							ProductAttribute2 = rd.GetString("ProductAttribute2"),
							DRemark = rd.GetString("DRemark"),
							AHTNCode = rd.GetString("AHTNCode"),
							ExciseNo = rd.GetString("ExciseNo"),
							ExciseUnit = rd.GetString("ExciseUnit"),
							ArgumentTariffCode = rd.GetString("ArgumentTariffCode"),
							BIS19TransferNo = rd.GetString("BIS19TransferNo"),
							BOILicenseNo = rd.GetString("BOILicenseNo"),
							BondFormulaNo = rd.GetString("BondFormulaNo"),
							PermitNo = rd.GetString("PermitNo"),
							UNDGNumber = rd.GetString("UNDGNumber"),
							CalculateBy = rd.GetString("CalculateBy"),
							FormulaNo = rd.GetString("FormulaNo"),
							ImpLodgedPort = rd.GetString("ImpLodgedPort"),
							ImpDecNO = rd.GetString("ImpDecNO"),
							ImpRefNo = rd.GetString("ImpRefNo"),
							NatureTrans = rd.GetString("NatureTrans"),
							DepositReason = rd.GetString("DepositReason"),
							QtyAddUnit = rd.GetString("QtyAddUnit"),
							PackAddUnit = rd.GetString("PackAddUnit"),
							GroupCode = rd.GetString("GroupCode"),
							PdtSubCode = rd.GetString("PdtSubCode"),
							DutyCalcBy = rd.GetString("DutyCalcBy"),
							PdtDescription2 = rd.GetString("PdtDescription2"),
							PdtDescriptionEN2 = rd.GetString("PdtDescriptionEN2"),
							Remark2 = rd.GetString("Remark2"),
							ShippingMark2 = rd.GetString("ShippingMark2"),
							ImportTaxIncentivesID = rd.GetString("ImportTaxIncentivesID"),
							ArgumentTariffSeq = rd.GetString("ArgumentTariffSeq"),
							ArgumentExportTariff = rd.GetString("ArgumentExportTariff"),
							OriginCriteria = rd.GetString("OriginCriteria"),
							ArgumentReasonCode = rd.GetString("ArgumentReasonCode"),
							CertExporterNo = rd.GetString("CertExporterNo"),
							ProcedureCode = rd.GetString("ProcedureCode"),
							ValuationCode = rd.GetString("ValuationCode"),
							ModelNo = rd.GetString("ModelNo"),
							ModelVer = rd.GetString("ModelVer"),
							ModelCmpTaxNo = rd.GetString("ModelCmpTaxNo"),
							ArgumentPrivilegeCode = rd.GetString("ArgumentPrivilegeCode"),
							Royalty = rd.GetString("Royalty"),
							RoyaltyDetail = rd.GetString("RoyaltyDetail"),
							ItmRemark2 = rd.GetString("ItmRemark2"),
							CmpPdtCode = rd.GetString("CmpPdtCode"),

							ItemNO = rd.GetInt32("ItemNO"),
							IsFreeOfCharge = rd.GetInt32("IsFreeOfCharge"),
							IsComp = rd.GetInt32("IsComp"),
							IsReImport = rd.GetInt32("IsReImport"),
							IsBOI = rd.GetInt32("IsBOI"),
							IsBond = rd.GetInt32("IsBond"),
							Is19BIS = rd.GetInt32("Is19BIS"),
							IsReExport = rd.GetInt32("IsReExport"),
							IsFreeZone = rd.GetInt32("IsFreeZone"),
							IsEPZ = rd.GetInt32("IsEPZ"),
							IsSeveral = rd.GetInt32("IsSeveral"),
							ImpLineNo = rd.GetInt32("ImpLineNo"),
							ProductYear = rd.GetInt32("ProductYear"),
							Revised = rd.GetInt32("Revised"),
							QtyRemark = rd.GetInt32("QtyRemark"),
							SeperateItem = rd.GetInt32("SeperateItem"),
							DeductedAmount = rd.GetInt32("DeductedAmount"),

							InvQty = rd.GetDouble("InvQty"),
							DUnitPriceF = rd.GetDouble("DUnitPriceF"),
							DUnitPriceB = rd.GetDouble("DUnitPriceB"),
							DCurRate = rd.GetDouble("DCurRate"),
							DFOBValueF = rd.GetDouble("DFOBValueF"),
							DFOBValueB = rd.GetDouble("DFOBValueB"),
							DIncreaseAmtF = rd.GetDouble("DIncreaseAmtF"),
							DIncreaseAmtB = rd.GetDouble("DIncreaseAmtB"),
							DInvAmtF = rd.GetDouble("DInvAmtF"),
							DInvAmtB = rd.GetDouble("DInvAmtB"),
							DFOBValueAss = rd.GetDouble("DFOBValueAss"),
							PackAmount = rd.GetDouble("PackAmount"),

							NetWeight = rd.GetDouble("NetWeight"),
							GrossWeight = rd.GetDouble("GrossWeight"),
							TariffQty = rd.GetDouble("TariffQty"),
							AssertQty = rd.GetDouble("AssertQty"),
							ExemptAmtB = rd.GetDouble("ExemptAmtB"),
							ExciseQty = rd.GetDouble("ExciseQty"),
							ExciseAssQty = rd.GetDouble("ExciseAssQty"),
							PackAddAmount = rd.GetDouble("PackAddAmount"),

							ExpShipping = rd.GetDouble("ExpShipping"),
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
							ArgumentSpecRate = rd.GetDouble("ArgumentSpecRate"),
							ArgumentValueRate = rd.GetDouble("ArgumentValueRate")
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
						dr["RefNO"] = this.RefNO;
						dr["InvNo"] = this.InvNo;
						dr["InvItemNO"] = this.InvItemNO;
						dr["PrivilegeCode"] = this.PrivilegeCode;
						dr["TariffCode"] = this.TariffCode;
						dr["TariffSeq"] = this.TariffSeq;
						dr["StatCode"] = this.StatCode;
						dr["TariffUnit"] = this.TariffUnit;
						dr["DUNDGNumber"] = this.DUNDGNumber;
						dr["InvUnit"] = this.InvUnit;
						dr["PackUnit"] = this.PackUnit;
						dr["DDRemark"] = this.DDRemark;
						dr["DPurchaseCountry"] = this.DPurchaseCountry;
						dr["DOriginCountry"] = this.DOriginCountry;
						dr["ExportTariff"] = this.ExportTariff;
						dr["BrandName"] = this.BrandName;
						dr["PdtCode"] = this.PdtCode;
						dr["CustomsPdtCode"] = this.CustomsPdtCode;
						dr["PdtDescription"] = this.PdtDescription;
						dr["PdtDescriptionEN"] = this.PdtDescriptionEN;
						dr["ProductAttribute1"] = this.ProductAttribute1;
						dr["ProductAttribute2"] = this.ProductAttribute2;
						dr["DRemark"] = this.DRemark;
						dr["FormulaNo"] = this.FormulaNo;
						dr["ImpLodgedPort"] = this.ImpLodgedPort;
						dr["ImpDecNO"] = this.ImpDecNO;
						dr["ImpRefNo"] = this.ImpRefNo;
						dr["UNDGNumber"] = this.UNDGNumber;
						dr["NatureTrans"] = this.NatureTrans;
						dr["AHTNCode"] = this.AHTNCode;
						dr["ExciseNo"] = this.ExciseNo;
						dr["ExciseUnit"] = this.ExciseUnit;
						dr["ArgumentTariffCode"] = this.ArgumentTariffCode;
						dr["BIS19TransferNo"] = this.BIS19TransferNo;
						dr["BOILicenseNo"] = this.BOILicenseNo;
						dr["BondFormulaNo"] = this.BondFormulaNo;
						dr["PermitNo"] = this.PermitNo;
						dr["UNDGNumber"] = this.UNDGNumber;
						dr["CalculateBy"] = this.CalculateBy;
						dr["DepositReason"] = this.DepositReason;
						dr["QtyAddUnit"] = this.QtyAddUnit;
						dr["PackAddUnit"] = this.PackAddUnit;
						dr["GroupCode"] = this.GroupCode;
						dr["ExciseNo"] = this.ExciseNo;
						dr["PdtSubCode"] = this.PdtSubCode;
						dr["DutyCalcBy"] = this.DutyCalcBy;
						dr["PdtDescription2"] = this.PdtDescription2;
						dr["PdtDescriptionEN2"] = this.PdtDescriptionEN2;
						dr["Remark2"] = this.Remark2;
						dr["ShippingMark2"] = this.ShippingMark2;
						dr["ImportTaxIncentivesID"] = this.ImportTaxIncentivesID;
						dr["ArgumentTariffCode"] = this.ArgumentTariffCode;
						dr["ArgumentTariffSeq"] = this.ArgumentTariffSeq;
						dr["ArgumentExportTariff"] = this.ArgumentExportTariff;
						dr["OriginCriteria"] = this.OriginCriteria;
						dr["ArgumentReasonCode"] = this.ArgumentReasonCode;
						dr["CertExporterNo"] = this.CertExporterNo;
						dr["ProcedureCode"] = this.ProcedureCode;
						dr["ValuationCode"] = this.ValuationCode;
						dr["ModelNo"] = this.ModelNo;
						dr["ModelVer"] = this.ModelVer;
						dr["ModelCmpTaxNo"] = this.ModelCmpTaxNo;
						dr["ArgumentPrivilegeCode"] = this.ArgumentPrivilegeCode;
						dr["Royalty"] = this.Royalty;
						dr["RoyaltyDetail"] = this.RoyaltyDetail;
						dr["ItmRemark2"] = this.ItmRemark2;
						dr["CmpPdtCode"] = this.CmpPdtCode;
						dr["Remark2"] = this.Remark2;

						dr["ItemNO"] = this.ItemNO;
						dr["IsFreeOfCharge"] = this.IsFreeOfCharge;
						dr["IsComp"] = this.IsComp;
						dr["IsReImport"] = this.IsReImport;
						dr["IsBOI"] = this.IsBOI;
						dr["IsBond"] = this.IsBond;
						dr["Is19BIS"] = this.Is19BIS;
						dr["IsReExport"] = this.IsReExport;
						dr["IsFreeZone"] = this.IsFreeZone;
						dr["IsEPZ"] = this.IsEPZ;
						dr["IsSeveral"] = this.IsSeveral;
						dr["ImpLineNo"] = this.ImpLineNo;
						dr["ProductYear"] = this.ProductYear;
						dr["Revised"] = this.Revised;
						dr["QtyRemark"] = this.QtyRemark;
						dr["SeperateItem"] = this.SeperateItem;
						dr["DeductedAmount"] = this.DeductedAmount;

						dr["TariffQty"] = this.TariffQty;
						dr["InvQty"] = this.InvQty;
						dr["DUnitPriceF"] = this.DUnitPriceF;
						dr["DUnitPriceB"] = this.DUnitPriceB;
						dr["DCurRate"] = this.DCurRate;
						dr["DFOBValueF"] = this.DFOBValueF;
						dr["DFOBValueB"] = this.DFOBValueB;
						dr["DIncreaseAmtF"] = this.DIncreaseAmtF;
						dr["DIncreaseAmtB"] = this.DIncreaseAmtB;
						dr["DInvAmtF"] = this.DInvAmtF;
						dr["DInvAmtB"] = this.DInvAmtB;
						dr["DFOBValueAss"] = this.DFOBValueAss;
						dr["PackAmount"] = this.PackAmount;

						dr["NetWeight"] = this.NetWeight;
						dr["GrossWeight"] = this.GrossWeight;
						dr["AssertQty"] = this.AssertQty;
						dr["ExemptAmtB"] = this.ExemptAmtB;
						dr["ExciseQty"] = this.ExciseQty;
						dr["ExciseAssQty"] = this.ExciseAssQty;
						dr["PackAddAmount"] = this.PackAddAmount;

						dr["ExpShipping"] = this.ExpShipping;
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
						dr["DutyPRatePay"] = this.DutyPRatePay;
						dr["DutySRatePay"] = this.DutySRatePay;
						dr["DutyDeduct"] = this.DutyDeduct;
						dr["WeightPerUnit"] = this.WeightPerUnit;
						dr["WeightPerPack"] = this.WeightPerPack;
						dr["ArgumentValueRate"] = this.ArgumentValueRate;
						dr["ArgumentSpecRate"] = this.ArgumentSpecRate;

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
				return msg;
			}
		}
	}
}