using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class Declare_Header
	{
		public const string tbname = "DecInvoice_Header";
		public int oid { get; set; }
		public string BranchCode { get; set; }
		public string RefNO { get; set; }
		public string InvNO { get; set; }
		public string TrackingNO { get; set; }
		public string CmpCode { get; set; }
		public string CmpTaxNumber { get; set; }
		public string CmpBranch { get; set; }
		public string SellerStatus { get; set; }
		public string ConsigneeStatus { get; set; }
		public string CommercialLevel { get; set; }
		public string BuyerCode { get; set; }
		public string BuyerName { get; set; }
		public string Street { get; set; }
		public string District { get; set; }
		public string Subprovince { get; set; }
		public string Province { get; set; }
		public string Postcode { get; set; }
		public string EmailAddr { get; set; }
		public string ConsigneeAddr { get; set; }
		public string PurchaseCountry { get; set; }
		public string NotifyPartyCode { get; set; }
		public string NotifyPartyName { get; set; }
		public string NotifyPartyAddr { get; set; }
		public string NotifyPartyEMail { get; set; }
		public string DestinationCountry { get; set; }
		public string IncoTerms { get; set; }
		public string InvCurrency { get; set; }
		public string NetWUnit { get; set; }
		public string CurExpOther { get; set; }
		public string CurExplanding { get; set; }
		public string CurExpInland { get; set; }
		public string CurExpPack { get; set; }
		public string CurExpFwd { get; set; }
		public string CurExpShp { get; set; }
		public string CurExpFrg { get; set; }
		public string CurExpIns { get; set; }
		public string AvgExpOther { get; set; }
		public string AvgExpInland { get; set; }
		public string AvgExplanding { get; set; }
		public string AvgExpFwd { get; set; }
		public string AvgExpPack { get; set; }
		public string AvgExpShp { get; set; }
		public string AvgExpFrg { get; set; }
		public string AvgExpIns { get; set; }
		public string RecByUser { get; set; }
		public string UIDTransmit { get; set; }
		public string SignBy { get; set; }
		public string FileToSend { get; set; }
		public string PoNo { get; set; }
		public string PaymentTerm { get; set; }
		public string OtherChargeDesc { get; set; }
		public string SelfCertRemark { get; set; }
		public string AEOsReferNo { get; set; }
		public string NotifyStreet { get; set; }
		public string NotifyDistrict { get; set; }
		public string NotifySubProvince { get; set; }
		public string NotifyProvince { get; set; }
		public string NotifyPostCode { get; set; }
		public DateTime InvDate { get; set; }
		public DateTime DepartureDate { get; set; }
		public DateTime RecDate { get; set; }
		public DateTime RecTime { get; set; }
		public DateTime SignDate { get; set; }
		public DateTime SignTime { get; set; }
		public int DocStatus { get; set; }
		public int AvgExp2Free { get; set; }
		public int ResponseStatus { get; set; }
		public int IsCancel { get; set; }
		public int InvoiceType { get; set; }
		public int IsNotAutoCal { get; set; }
		public Double InvCurRate { get; set; }
		public Double TotalNetW { get; set; }
		public Double TotalInvoice { get; set; }
		public Double TotalInvTHB { get; set; }
		public Double CurExpOtherRate { get; set; }
		public Double TotalExpOther { get; set; }
		public Double TotalExpOtherTHB { get; set; }
		public Double CurExplandingRate { get; set; }
		public Double TotalExplanding { get; set; }
		public Double TotalExplandingTHB { get; set; }
		public Double CurExpInlandRate { get; set; }
		public Double TotalExpInland { get; set; }
		public Double TotalExpInlandTHB { get; set; }
		public Double CurExpPackRate { get; set; }
		public Double TotalExpPack { get; set; }
		public Double TotalExpPackTHB { get; set; }
		public Double CurExpFwdRate { get; set; }
		public Double TotalExpForward { get; set; }
		public Double TotalExpForwardTHB { get; set; }
		public Double CurExpShpRate { get; set; }
		public Double TotalExpShipping { get; set; }
		public Double TotalExpShippingTHB { get; set; }
		public Double CurExpFrgRate { get; set; }
		public Double TotalExpFreight { get; set; }
		public Double TotalExpFreightTHB { get; set; }
		public Double CurExpInsRate { get; set; }
		public Double TotalExpInsurance { get; set; }
		public Double TotalExpInsuranceTHB { get; set; }
		public Double TotalIncreasedPrice { get; set; }
		public Double TotalIncreasedPriceTHB { get; set; }

		public List<DecInvoice_Header> get()
		{
			var rows = new List<DecInvoice_Header>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new DecInvoice_Header()
						{
							oid = rd.GetInt32("oid"),
							BranchCode = rd.GetString("BranchCode"),
							RefNO = rd.GetString("RefNO"),
							InvNO = rd.GetString("InvNO"),
							TrackingNO = rd.GetString("TrackingNO"),
							CmpCode = rd.GetString("CmpCode"),
							CmpTaxNumber = rd.GetString("CmpTaxNumber"),
							CmpBranch = rd.GetString("CmpBranch"),
							SellerStatus = rd.GetString("SellerStatus"),
							ConsigneeStatus = rd.GetString("ConsigneeStatus"),
							CommercialLevel = rd.GetString("CommercialLevel"),
							BuyerCode = rd.GetString("BuyerCode"),
							BuyerName = rd.GetString("BuyerName"),
							Street = rd.GetString("Street"),
							District = rd.GetString("District"),
							Subprovince = rd.GetString("Subprovince"),
							Province = rd.GetString("Province"),
							Postcode = rd.GetString("Postcode"),
							EmailAddr = rd.GetString("EmailAddr"),
							ConsigneeAddr = rd.GetString("ConsigneeAddr"),
							PurchaseCountry = rd.GetString("PurchaseCountry"),
							NotifyPartyCode = rd.GetString("NotifyPartyCode"),
							NotifyPartyName = rd.GetString("NotifyPartyName"),
							NotifyPartyAddr = rd.GetString("NotifyPartyAddr"),
							NotifyPartyEMail = rd.GetString("NotifyPartyEMail"),
							CurExpInland = rd.GetString("CurExpInland"),
							CurExpPack = rd.GetString("CurExpPack"),
							CurExpFwd = rd.GetString("CurExpFwd"),
							CurExpShp = rd.GetString("CurExpShp"),
							CurExpFrg = rd.GetString("CurExpFrg"),
							CurExpIns = rd.GetString("CurExpIns"),
							AvgExpOther = rd.GetString("AvgExpOther"),
							AvgExpInland = rd.GetString("AvgExpInland"),
							AvgExplanding = rd.GetString("AvgExplanding"),
							AvgExpFwd = rd.GetString("AvgExpFwd"),
							DestinationCountry = rd.GetString("DestinationCountry"),
							IncoTerms = rd.GetString("IncoTerms"),
							InvCurrency = rd.GetString("InvCurrency"),
							NetWUnit = rd.GetString("NetWUnit"),
							CurExpOther = rd.GetString("CurExpOther"),
							CurExplanding = rd.GetString("CurExplanding"),
							AvgExpPack = rd.GetString("AvgExpPack"),
							AvgExpShp = rd.GetString("AvgExpShp"),
							AvgExpFrg = rd.GetString("AvgExpFrg"),
							AvgExpIns = rd.GetString("AvgExpIns"),
							RecByUser = rd.GetString("RecByUser"),
							UIDTransmit = rd.GetString("UIDTransmit"),
							SignBy = rd.GetString("SignBy"),
							FileToSend = rd.GetString("FileToSend"),
							PoNo = rd.GetString("PoNo"),
							PaymentTerm = rd.GetString("PaymentTerm"),
							OtherChargeDesc = rd.GetString("OtherChargeDesc"),
							SelfCertRemark = rd.GetString("SelfCertRemark"),
							AEOsReferNo = rd.GetString("AEOsReferNo"),
							NotifyStreet = rd.GetString("NotifyStreet"),
							NotifyDistrict = rd.GetString("NotifyDistrict"),
							NotifySubProvince = rd.GetString("NotifySubProvince"),
							NotifyProvince = rd.GetString("NotifyProvince"),
							NotifyPostCode = rd.GetString("NotifyPostCode"),

							InvDate = rd.GetDateTime("InvDate"),
							DepartureDate = rd.GetDateTime("DepartureDate"),
							RecDate = rd.GetDateTime("RecDate"),
							RecTime = rd.GetDateTime("RecTime"),
							SignDate = rd.GetDateTime("SignDate"),
							SignTime = rd.GetDateTime("SignTime"),

							DocStatus = rd.GetInt32("DocStatus"),
							AvgExp2Free = rd.GetInt32("AvgExp2Free"),
							ResponseStatus = rd.GetInt32("ResponseStatus"),
							IsCancel = rd.GetInt32("IsCancel"),
							InvoiceType = rd.GetInt32("InvoiceType"),
							IsNotAutoCal = rd.GetInt32("IsNotAutoCal"),

							InvCurRate = rd.GetDouble("InvCurRate"),
							TotalNetW = rd.GetDouble("TotalNetW"),
							TotalInvoice = rd.GetDouble("TotalInvoice"),
							TotalInvTHB = rd.GetDouble("TotalInvTHB"),
							CurExpOtherRate = rd.GetDouble("CurExpOtherRate"),
							TotalExpOther = rd.GetDouble("TotalExpOther"),
							TotalExpOtherTHB = rd.GetDouble("TotalExpOtherTHB"),
							CurExplandingRate = rd.GetDouble("CurExplandingRate"),
							TotalExplanding = rd.GetDouble("TotalExplanding"),
							TotalExplandingTHB = rd.GetDouble("TotalExplandingTHB"),
							CurExpInlandRate = rd.GetDouble("CurExpInlandRate"),
							TotalExpInland = rd.GetDouble("TotalExpInland"),
							TotalExpInlandTHB = rd.GetDouble("TotalExpInlandTHB"),
							CurExpPackRate = rd.GetDouble("CurExpPackRate"),
							TotalExpPack = rd.GetDouble("TotalExpPack"),
							TotalExpPackTHB = rd.GetDouble("TotalExpPackTHB"),
							CurExpFwdRate = rd.GetDouble("CurExpFwdRate"),
							TotalExpForward = rd.GetDouble("TotalExpForward"),
							TotalExpForwardTHB = rd.GetDouble("TotalExpForwardTHB"),
							CurExpShpRate = rd.GetDouble("CurExpShpRate"),
							TotalExpShipping = rd.GetDouble("TotalExpShipping"),
							TotalExpShippingTHB = rd.GetDouble("TotalExpShippingTHB"),
							CurExpFrgRate = rd.GetDouble("CurExpFrgRate"),
							TotalExpFreight = rd.GetDouble("TotalExpFreight"),
							TotalExpFreightTHB = rd.GetDouble("TotalExpFreightTHB"),
							CurExpInsRate = rd.GetDouble("CurExpInsRate"),
							TotalExpInsurance = rd.GetDouble("TotalExpInsurance"),
							TotalExpInsuranceTHB = rd.GetDouble("TotalExpInsuranceTHB"),
							TotalIncreasedPrice = rd.GetDouble("TotalIncreasedPrice"),
							TotalIncreasedPriceTHB = rd.GetDouble("TotalIncreasedPriceTHB")
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
						dr["InvNO"] = this.InvNO;
						dr["TrackingNO"] = this.TrackingNO;
						dr["CmpCode"] = this.CmpCode;
						dr["CmpTaxNumber"] = this.CmpTaxNumber;
						dr["CmpBranch"] = this.CmpBranch;
						dr["SellerStatus"] = this.SellerStatus;
						dr["ConsigneeStatus"] = this.ConsigneeStatus;
						dr["CommercialLevel"] = this.CommercialLevel;
						dr["BuyerCode"] = this.BuyerCode;
						dr["BuyerName"] = this.BuyerName;
						dr["Street"] = this.Street;
						dr["District"] = this.District;
						dr["Subprovince"] = this.Subprovince;
						dr["Province"] = this.Province;
						dr["Postcode"] = this.Postcode;
						dr["EmailAddr"] = this.EmailAddr;
						dr["ConsigneeAddr"] = this.ConsigneeAddr;
						dr["PurchaseCountry"] = this.PurchaseCountry;
						dr["NotifyPartyCode"] = this.NotifyPartyCode;
						dr["NotifyPartyName"] = this.NotifyPartyName;
						dr["NotifyPartyAddr"] = this.NotifyPartyAddr;
						dr["NotifyPartyEMail"] = this.NotifyPartyEMail;
						dr["DestinationCountry"] = this.DestinationCountry;
						dr["IncoTerms"] = this.IncoTerms;
						dr["InvCurrency"] = this.InvCurrency;
						dr["NetWUnit"] = this.NetWUnit;
						dr["CurExpOther"] = this.CurExpOther;
						dr["CurExplanding"] = this.CurExplanding;
						dr["CurExpInland"] = this.CurExpInland;
						dr["CurExpPack"] = this.CurExpPack;
						dr["CurExpFwd"] = this.CurExpFwd;
						dr["CurExpShp"] = this.CurExpShp;
						dr["CurExpFrg"] = this.CurExpFrg;
						dr["CurExpIns"] = this.CurExpIns;
						dr["AvgExpOther"] = this.AvgExpOther;
						dr["AvgExpInland"] = this.AvgExpInland;
						dr["AvgExplanding"] = this.AvgExplanding;
						dr["AvgExpFwd"] = this.AvgExpFwd;
						dr["AvgExpPack"] = this.AvgExpPack;
						dr["AvgExpShp"] = this.AvgExpShp;
						dr["AvgExpFrg"] = this.AvgExpFrg;
						dr["AvgExpIns"] = this.AvgExpIns;
						dr["RecByUser"] = this.RecByUser;
						dr["UIDTransmit"] = this.UIDTransmit;
						dr["SignBy"] = this.SignBy;
						dr["FileToSend"] = this.FileToSend;
						dr["PoNo"] = this.PoNo;
						dr["PaymentTerm"] = this.PaymentTerm;
						dr["OtherChargeDesc"] = this.OtherChargeDesc;
						dr["SelfCertRemark"] = this.SelfCertRemark;
						dr["AEOsReferNo"] = this.AEOsReferNo;
						dr["NotifyStreet"] = this.NotifyStreet;
						dr["NotifyDistrict"] = this.NotifyDistrict;
						dr["NotifySubProvince"] = this.NotifySubProvince;
						dr["NotifyProvince"] = this.NotifyProvince;
						dr["NotifyPostCode"] = this.NotifyPostCode;

						dr["InvCurRate"] = this.InvCurRate;
						dr["TotalNetW"] = this.TotalNetW;
						dr["TotalInvoice"] = this.TotalInvoice;
						dr["TotalInvTHB"] = this.TotalInvTHB;
						dr["CurExpOtherRate"] = this.CurExpOtherRate;
						dr["TotalExpOther"] = this.TotalExpOther;
						dr["TotalExpOtherTHB"] = this.TotalExpOtherTHB;
						dr["CurExplandingRate"] = this.CurExplandingRate;
						dr["TotalExplanding"] = this.TotalExplanding;
						dr["TotalExplandingTHB"] = this.TotalExplandingTHB;
						dr["CurExpInlandRate"] = this.CurExpInlandRate;
						dr["TotalExpInland"] = this.TotalExpInland;
						dr["TotalExpInlandTHB"] = this.TotalExpInlandTHB;
						dr["CurExpPackRate"] = this.CurExpPackRate;
						dr["TotalExpPack"] = this.TotalExpPack;
						dr["TotalExpPackTHB"] = this.TotalExpPackTHB;
						dr["CurExpFwdRate"] = this.CurExpFwdRate;
						dr["TotalExpForward"] = this.TotalExpForward;
						dr["TotalExpForwardTHB"] = this.TotalExpForwardTHB;
						dr["CurExpShpRate"] = this.CurExpShpRate;
						dr["TotalExpShipping"] = this.TotalExpShipping;
						dr["TotalExpShippingTHB"] = this.TotalExpShippingTHB;
						dr["CurExpFrgRate"] = this.CurExpFrgRate;
						dr["TotalExpFreight"] = this.TotalExpFreight;
						dr["TotalExpFreightTHB"] = this.TotalExpFreightTHB;
						dr["CurExpInsRate"] = this.CurExpInsRate;
						dr["TotalExpInsurance"] = this.TotalExpInsurance;
						dr["TotalExpInsuranceTHB"] = this.TotalExpInsuranceTHB;
						dr["TotalIncreasedPrice"] = this.TotalIncreasedPrice;
						dr["TotalIncreasedPriceTHB"] = this.TotalIncreasedPriceTHB;

						dr["DocStatus"] = this.DocStatus;
						dr["ResponseStatus"] = this.ResponseStatus;
						dr["IsCancel"] = this.IsCancel;
						dr["InvoiceType"] = this.InvoiceType;
						dr["IsNotAutoCal"] = this.IsNotAutoCal;

						dr["InvDate"] = this.InvDate;
						dr["DepartureDate"] = this.DepartureDate;
						dr["RecDate"] = this.RecDate;
						dr["RecTime"] = this.RecTime;
						dr["SignDate"] = this.SignDate;
						dr["SignTime"] = this.SignTime;

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