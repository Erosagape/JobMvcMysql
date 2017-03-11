using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class Company
	{
		public const string tbname = "Company";
		public int oid { get; set; }
		public string CustCode { get; set; }
		public string Branch { get; set; }
		public string CustGroup { get; set; }
		public string Title { get; set; }
		public string NameThai { get; set; }
		public string TaxNumber { get; set; }
		public string NameEng { get; set; }
		public string TAddress1 { get; set; }
		public string TAddress2 { get; set; }
		public string EAddress1 { get; set; }
		public string EAddress2 { get; set; }
		public string Phone { get; set; }
		public string FaxNumber { get; set; }
		public string TAddress { get; set; }
		public string TStreet { get; set; }
		public string TDistrict { get; set; }
		public string TSubProvince { get; set; }
		public string TProvince { get; set; }
		public string TPostCode { get; set; }
		public string LoginName { get; set; }
		public string LoginPassword { get; set; }
		public string ManagerCode { get; set; }
		public string CSCodeIM { get; set; }
		public string CSCodeEX { get; set; }
		public string CSCodeOT { get; set; }
		public string GLAccountCode { get; set; }
		public string UsedLanguage { get; set; }
		public string BillToCustCode { get; set; }
		public string BillToBranch { get; set; }
		public string LevelGrade { get; set; }
		public string BillCondition { get; set; }
		public string MapText { get; set; }
		public string MapFileName { get; set; }
		public string CmpType { get; set; }
		public string CmpLevelExp { get; set; }
		public string CmpLevelImp { get; set; }
		public string LnNO { get; set; }
		public string AdjTaxCode { get; set; }
		public string BkAuthorNo { get; set; }
		public string BkAuthorCnn { get; set; }
		public string LtdPsWkName { get; set; }
		public string ConsStatus { get; set; }
		public string CommLevel { get; set; }
		public string DMailAddress { get; set; }
		public string PrivilegeOption { get; set; }
		public string Email { get; set; }
		public string SignPrivilege { get; set; }
		public string ImporterNo { get; set; }
		public string ExporterNo { get; set; }
		public string CustSignMail { get; set; }
		public string Tax13No { get; set; }
		public string TProvinceName { get; set; }
		public string AEOsReferenceNumber { get; set; }
		public string GDEXRptName { get; set; }
		public string GDIMRptName { get; set; }
		public string GOODSRptName { get; set; }

		public int CustType { get; set; }
		public int TermOfPayment { get; set; }
		public int MgrSeq { get; set; }
		public int Is19bis { get; set; }
		public int LevelNoExp { get; set; }
		public int LevelNoImp { get; set; }
        public int GoldCardNO { get; set; }
        public int CustomsBrokerSeq { get; set; }

		public Double CreditLimit { get; set; }
		public Double DutyLimit { get; set; }
		public Double CommRate { get; set; }

		public List<Company> get()
		{
			var rows = new List<Company>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new Company()
						{
							oid = rd.GetInt32("oid"),
							CustCode = rd.GetString("CustCode"),
							Branch = rd.GetString("Branch"),
							CustGroup = rd.GetString("CustGroup"),
							Title = rd.GetString("Title"),
							NameThai = rd.GetString("NameThai"),
							TaxNumber = rd.GetString("TaxNumber"),
							NameEng = rd.GetString("NameEng"),
							TAddress1 = rd.GetString("TAddress1"),
							TAddress2 = rd.GetString("TAddress2"),
							EAddress1 = rd.GetString("EAddress1"),
							EAddress2 = rd.GetString("EAddress2"),
							Phone = rd.GetString("Phone"),
							FaxNumber = rd.GetString("FaxNumber"),
							TAddress = rd.GetString("TAddress"),
							TStreet = rd.GetString("TStreet"),
							TDistrict = rd.GetString("TDistrict"),
							TSubProvince = rd.GetString("TSubProvince"),
							TProvince = rd.GetString("TProvince"),
							TPostCode = rd.GetString("TPostCode"),
							LoginName = rd.GetString("LoginName"),
							LoginPassword = rd.GetString("LoginPassword"),
							ManagerCode = rd.GetString("ManagerCode"),
							CSCodeIM = rd.GetString("CSCodeIM"),
							CSCodeEX = rd.GetString("CSCodeEX"),
							BillCondition = rd.GetString("BillCondition"),
							MapText = rd.GetString("MapText"),
							MapFileName = rd.GetString("MapFileName"),
							CmpType = rd.GetString("CmpType"),
							CmpLevelExp = rd.GetString("CmpLevelExp"),
							CmpLevelImp = rd.GetString("CmpLevelImp"),
							LnNO = rd.GetString("LnNO"),
							AdjTaxCode = rd.GetString("AdjTaxCode"),
							BkAuthorNo = rd.GetString("BkAuthorNo"),
							BkAuthorCnn = rd.GetString("BkAuthorCnn"),
							CSCodeOT = rd.GetString("CSCodeOT"),
							GLAccountCode = rd.GetString("GLAccountCode"),
							UsedLanguage = rd.GetString("UsedLanguage"),
							BillToCustCode = rd.GetString("BillToCustCode"),
							BillToBranch = rd.GetString("BillToBranch"),
							LevelGrade = rd.GetString("LevelGrade"),
							LtdPsWkName = rd.GetString("LtdPsWkName"),
							ConsStatus = rd.GetString("ConsStatus"),
							CommLevel = rd.GetString("CommLevel"),
							DMailAddress = rd.GetString("DMailAddress"),
							PrivilegeOption = rd.GetString("PrivilegeOption"),
							Email = rd.GetString("Email"),
							SignPrivilege = rd.GetString("SignPrivilege"),
							ImporterNo = rd.GetString("ImporterNo"),
							ExporterNo = rd.GetString("ExporterNo"),
							CustSignMail = rd.GetString("CustSignMail"),
							Tax13No = rd.GetString("Tax13No"),
							TProvinceName = rd.GetString("TProvinceName"),
							AEOsReferenceNumber = rd.GetString("AEOsReferenceNumber"),
							GDEXRptName = rd.GetString("GDEXRptName"),
							GDIMRptName = rd.GetString("GDIMRptName"),
							GOODSRptName = rd.GetString("GOODSRptName"),

							CustType = rd.GetInt32("CustType"),
							TermOfPayment = rd.GetInt32("TermOfPayment"),
							MgrSeq = rd.GetInt32("MgrSeq"),
							Is19bis = rd.GetInt32("Is19bis"),
							LevelNoExp = rd.GetInt32("LevelNoExp"),
							LevelNoImp = rd.GetInt32("LevelNoImp"),
                            GoldCardNO = rd.GetInt32("GoldCardNO"),
                            CustomsBrokerSeq = rd.GetInt32("CustomsBrokerSeq"),

							CreditLimit = rd.GetDouble("CreditLimit"),
							DutyLimit = rd.GetDouble("DutyLimit"),
							CommRate = rd.GetDouble("CommRate")
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
						dr["CustCode"] = this.CustCode;
						dr["Branch"] = this.Branch;
						dr["CustGroup"] = this.CustGroup;
						dr["Title"] = this.Title;
						dr["NameThai"] = this.NameThai;
						dr["TaxNumber"] = this.TaxNumber;
						dr["NameEng"] = this.NameEng;
						dr["TAddress1"] = this.TAddress1;
						dr["TAddress2"] = this.TAddress2;
						dr["EAddress1"] = this.EAddress1;
						dr["EAddress2"] = this.EAddress2;
						dr["Phone"] = this.Phone;
						dr["FaxNumber"] = this.FaxNumber;
						dr["TAddress"] = this.TAddress;
						dr["TStreet"] = this.TStreet;
						dr["TDistrict"] = this.TDistrict;
						dr["TSubProvince"] = this.TSubProvince;
						dr["TProvince"] = this.TProvince;
						dr["TPostCode"] = this.TPostCode;
						dr["LoginName"] = this.LoginName;
						dr["LoginPassword"] = this.LoginPassword;
						dr["ManagerCode"] = this.ManagerCode;
						dr["CSCodeIM"] = this.CSCodeIM;
						dr["CSCodeEX"] = this.CSCodeEX;
						dr["CSCodeOT"] = this.CSCodeOT;
						dr["GLAccountCode"] = this.GLAccountCode;
						dr["UsedLanguage"] = this.UsedLanguage;
						dr["BillToCustCode"] = this.BillToCustCode;
						dr["BillToBranch"] = this.BillToBranch;
						dr["LevelGrade"] = this.LevelGrade;
						dr["BillCondition"] = this.BillCondition;
						dr["MapText"] = this.MapText;
						dr["MapFileName"] = this.MapFileName;
						dr["CmpType"] = this.CmpType;
						dr["CmpLevelExp"] = this.CmpLevelExp;
						dr["CmpLevelImp"] = this.CmpLevelImp;
						dr["LnNO"] = this.LnNO;
						dr["AdjTaxCode"] = this.AdjTaxCode;
						dr["BkAuthorNo"] = this.BkAuthorNo;
						dr["BkAuthorCnn"] = this.BkAuthorCnn;
						dr["LtdPsWkName"] = this.LtdPsWkName;
						dr["ConsStatus"] = this.ConsStatus;
						dr["CommLevel"] = this.CommLevel;
						dr["DMailAddress"] = this.DMailAddress;
						dr["PrivilegeOption"] = this.PrivilegeOption;
						dr["Email"] = this.Email;
						dr["SignPrivilege"] = this.SignPrivilege;
						dr["ImporterNo"] = this.ImporterNo;
						dr["ExporterNo"] = this.ExporterNo;
						dr["CustSignMail"] = this.CustSignMail;
						dr["Tax13No"] = this.Tax13No;
						dr["TProvinceName"] = this.TProvinceName;
						dr["AEOsReferenceNumber"] = this.AEOsReferenceNumber;
						dr["GDEXRptName"] = this.GDEXRptName;
						dr["GDIMRptName"] = this.GDIMRptName;
						dr["GOODSRptName"] = this.GOODSRptName;

						dr["CreditLimit"] = this.CreditLimit;
						dr["DutyLimit"] = this.DutyLimit;
						dr["CommRate"] = this.CommRate;

						dr["CustType"] = this.CustType;
						dr["TermOfPayment"] = this.TermOfPayment;
						dr["MgrSeq"] = this.MgrSeq;
						dr["Is19bis"] = this.Is19bis;
						dr["LevelNoExp"] = this.LevelNoExp;
						dr["LevelNoImp"] = this.LevelNoImp;
						dr["GoldCardNO"] = this.GoldCardNO;
						dr["CustomsBrokerSeq"] = this.CustomsBrokerSeq;

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