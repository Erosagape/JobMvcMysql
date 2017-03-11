using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class Employee_master
	{
		public const string tbname = "Employee_master";
		public int oid { get; set; }
		public string Emp_id { get; set; }
		public string Emp_Ttitle { get; set; }
		public string Emp_Tfname { get; set; }
		public string Emp_Tlname { get; set; }
		public string Emp_Etitle { get; set; }
		public string Emp_Efname { get; set; }
		public string Emp_Elname { get; set; }
		public string Emp_Gender { get; set; }
		public string Emp_CitizenId { get; set; }
		public string Emp_TaxId { get; set; }
		public string Emp_SocialId { get; set; }
		public string Emp_PaPaFullname { get; set; }
		public string Emp_MamaFullname { get; set; }
		public string Emp_RegisHomeno { get; set; }
		public string Emp_RegisBuilding { get; set; }
		public string Emp_RegisFloor { get; set; }
		public string Emp_RegisRoom { get; set; }
		public string Emp_RegisMooBan { get; set; }
		public string Emp_RegisSoi { get; set; }
		public string Emp_RegisRoad { get; set; }
		public string Emp_RegisTumbol { get; set; }
		public string Emp_RegisAmphur { get; set; }
		public string Emp_RegisProvince { get; set; }
		public string Emp_RegisZipcode { get; set; }
		public string Emp_RegisTel { get; set; }
		public string Emp_CurrHomeno { get; set; }
		public string Emp_CurrBuilding { get; set; }
		public string Emp_CurrFloor { get; set; }
		public string Emp_CurrRoom { get; set; }
		public string Emp_CurrMooBan { get; set; }
		public string Emp_CurrSoi { get; set; }
		public string Emp_CurrRoad { get; set; }
		public string Emp_CurrTumbol { get; set; }
		public string Emp_CurrAmphur { get; set; }
		public string Emp_CurrProvince { get; set; }
		public string Emp_CurrZipcode { get; set; }
		public string Emp_CurrTel { get; set; }
		public string Emp_Nationality { get; set; }
		public string Emp_Race { get; set; }
		public string Emp_Religion { get; set; }
		public string Emp_pictures { get; set; }
		public string Emp_BankNo { get; set; }
		public string Emp_EmpType_id { get; set; }
		public string Emp_Unit_id { get; set; }
		public string Emp_EduDegree { get; set; }
		public string Emp_EduInstitute { get; set; }
		public string Emp_workstatus { get; set; }
		public string Emp_exitstatus { get; set; }
		public string Emp_SpouseFullName { get; set; }
		public string Emp_PassWord { get; set; }
		public string Emp_BarCode { get; set; }
		public string Emp_Signature { get; set; }
		public string Emp_Description { get; set; }
		public DateTime Emp_Bdate { get; set; }
		public DateTime Emp_FirstDate { get; set; }
		public DateTime Emp_StartDate { get; set; }
		public DateTime Emp_exitdate { get; set; }
		public DateTime Emp_date { get; set; }
		public int Emp_TaxMarried { get; set; }
		public int Emp_TaxChild { get; set; }
		public int Emp_TaxChildEd { get; set; }
		public int Emp_TaxParentCount { get; set; }
		public int Emp_TeacherStatus { get; set; }
		public int Emp_TaxNo { get; set; }
		public Double Emp_FirstSalary { get; set; }
		public Double Emp_CurrSalary { get; set; }
		public Double Emp_TaxInsurance { get; set; }
		public Double Emp_TaxHouseInt { get; set; }
		public Double Emp_TaxDonation { get; set; }
		public Double Emp_TaxFund { get; set; }
		public Double Emp_TaxParent { get; set; }

		public List<Employee_master> get()
		{
			var rows = new List<Employee_master>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new Employee_master()
						{
							oid = rd.GetInt32("oid"),
							Emp_id = rd.GetString("Emp_id"),
							Emp_Ttitle = rd.GetString("Emp_Ttitle"),
							Emp_Tfname = rd.GetString("Emp_Tfname"),
							Emp_Tlname = rd.GetString("Emp_Tlname"),
							Emp_Etitle = rd.GetString("Emp_Etitle"),
							Emp_Efname = rd.GetString("Emp_Efname"),
							Emp_Elname = rd.GetString("Emp_Elname"),
							Emp_Gender = rd.GetString("Emp_Gender"),
							Emp_CitizenId = rd.GetString("Emp_CitizenId"),
							Emp_TaxId = rd.GetString("Emp_TaxId"),
							Emp_SocialId = rd.GetString("Emp_SocialId"),
							Emp_PaPaFullname = rd.GetString("Emp_PaPaFullname"),
							Emp_MamaFullname = rd.GetString("Emp_MamaFullname"),
							Emp_RegisHomeno = rd.GetString("Emp_RegisHomeno"),
							Emp_RegisBuilding = rd.GetString("Emp_RegisBuilding"),
							Emp_RegisFloor = rd.GetString("Emp_RegisFloor"),
							Emp_RegisRoom = rd.GetString("Emp_RegisRoom"),
							Emp_RegisMooBan = rd.GetString("Emp_RegisMooBan"),
							Emp_RegisSoi = rd.GetString("Emp_RegisSoi"),
							Emp_RegisRoad = rd.GetString("Emp_RegisRoad"),
							Emp_RegisTumbol = rd.GetString("Emp_RegisTumbol"),
							Emp_RegisAmphur = rd.GetString("Emp_RegisAmphur"),
							Emp_RegisProvince = rd.GetString("Emp_RegisProvince"),
							Emp_RegisZipcode = rd.GetString("Emp_RegisZipcode"),
							Emp_CurrSoi = rd.GetString("Emp_CurrSoi"),
							Emp_CurrRoad = rd.GetString("Emp_CurrRoad"),
							Emp_CurrTumbol = rd.GetString("Emp_CurrTumbol"),
							Emp_CurrAmphur = rd.GetString("Emp_CurrAmphur"),
							Emp_CurrProvince = rd.GetString("Emp_CurrProvince"),
							Emp_CurrZipcode = rd.GetString("Emp_CurrZipcode"),
							Emp_CurrTel = rd.GetString("Emp_CurrTel"),
							Emp_Nationality = rd.GetString("Emp_Nationality"),
							Emp_Race = rd.GetString("Emp_Race"),
							Emp_Religion = rd.GetString("Emp_Religion"),
							Emp_RegisTel = rd.GetString("Emp_RegisTel"),
							Emp_CurrHomeno = rd.GetString("Emp_CurrHomeno"),
							Emp_CurrBuilding = rd.GetString("Emp_CurrBuilding"),
							Emp_CurrFloor = rd.GetString("Emp_CurrFloor"),
							Emp_CurrRoom = rd.GetString("Emp_CurrRoom"),
							Emp_CurrMooBan = rd.GetString("Emp_CurrMooBan"),
							Emp_pictures = rd.GetString("Emp_pictures"),
							Emp_BankNo = rd.GetString("Emp_BankNo"),
							Emp_EmpType_id = rd.GetString("Emp_EmpType_id"),
							Emp_Unit_id = rd.GetString("Emp_Unit_id"),
							Emp_EduDegree = rd.GetString("Emp_EduDegree"),
							Emp_EduInstitute = rd.GetString("Emp_EduInstitute"),
							Emp_workstatus = rd.GetString("Emp_workstatus"),
							Emp_exitstatus = rd.GetString("Emp_exitstatus"),
							Emp_SpouseFullName = rd.GetString("Emp_SpouseFullName"),
							Emp_PassWord = rd.GetString("Emp_PassWord"),
							Emp_BarCode = rd.GetString("Emp_BarCode"),
							Emp_Signature = rd.GetString("Emp_Signature"),
							Emp_Description = rd.GetString("Emp_Description"),

							Emp_Bdate = rd.GetDateTime("Emp_Bdate"),
							Emp_FirstDate = rd.GetDateTime("Emp_FirstDate"),
							Emp_StartDate = rd.GetDateTime("Emp_StartDate"),
							Emp_exitdate = rd.GetDateTime("Emp_exitdate"),
							Emp_date = rd.GetDateTime("Emp_date"),

							Emp_TaxMarried = rd.GetInt32("Emp_TaxMarried"),
							Emp_TaxChild = rd.GetInt32("Emp_TaxChild"),
							Emp_TaxChildEd = rd.GetInt32("Emp_TaxChildEd"),
							Emp_TaxParentCount = rd.GetInt32("Emp_TaxParentCount"),
							Emp_TeacherStatus = rd.GetInt32("Emp_TeacherStatus"),
							Emp_TaxNo = rd.GetInt32("Emp_TaxNo"),

							Emp_FirstSalary = rd.GetDouble("Emp_FirstSalary"),
							Emp_CurrSalary = rd.GetDouble("Emp_CurrSalary"),
							Emp_TaxInsurance = rd.GetDouble("Emp_TaxInsurance"),
							Emp_TaxHouseInt = rd.GetDouble("Emp_TaxHouseInt"),
							Emp_TaxDonation = rd.GetDouble("Emp_TaxDonation"),
							Emp_TaxFund = rd.GetDouble("Emp_TaxFund"),
							Emp_TaxParent = rd.GetDouble("Emp_TaxParent")
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
						dr["Emp_id"] = this.Emp_id;
						dr["Emp_Ttitle"] = this.Emp_Ttitle;
						dr["Emp_Tfname"] = this.Emp_Tfname;
						dr["Emp_Tlname"] = this.Emp_Tlname;
						dr["Emp_Etitle"] = this.Emp_Etitle;
						dr["Emp_Efname"] = this.Emp_Efname;
						dr["Emp_Elname"] = this.Emp_Elname;
						dr["Emp_Gender"] = this.Emp_Gender;
						dr["Emp_CitizenId"] = this.Emp_CitizenId;
						dr["Emp_TaxId"] = this.Emp_TaxId;
						dr["Emp_SocialId"] = this.Emp_SocialId;
						dr["Emp_PaPaFullname"] = this.Emp_PaPaFullname;
						dr["Emp_MamaFullname"] = this.Emp_MamaFullname;
						dr["Emp_RegisHomeno"] = this.Emp_RegisHomeno;
						dr["Emp_RegisBuilding"] = this.Emp_RegisBuilding;
						dr["Emp_RegisFloor"] = this.Emp_RegisFloor;
						dr["Emp_RegisRoom"] = this.Emp_RegisRoom;
						dr["Emp_RegisMooBan"] = this.Emp_RegisMooBan;
						dr["Emp_RegisSoi"] = this.Emp_RegisSoi;
						dr["Emp_RegisRoad"] = this.Emp_RegisRoad;
						dr["Emp_RegisTumbol"] = this.Emp_RegisTumbol;
						dr["Emp_RegisAmphur"] = this.Emp_RegisAmphur;
						dr["Emp_RegisProvince"] = this.Emp_RegisProvince;
						dr["Emp_RegisZipcode"] = this.Emp_RegisZipcode;
						dr["Emp_RegisTel"] = this.Emp_RegisTel;
						dr["Emp_CurrHomeno"] = this.Emp_CurrHomeno;
						dr["Emp_CurrBuilding"] = this.Emp_CurrBuilding;
						dr["Emp_CurrFloor"] = this.Emp_CurrFloor;
						dr["Emp_CurrRoom"] = this.Emp_CurrRoom;
						dr["Emp_CurrMooBan"] = this.Emp_CurrMooBan;
						dr["Emp_CurrSoi"] = this.Emp_CurrSoi;
						dr["Emp_CurrRoad"] = this.Emp_CurrRoad;
						dr["Emp_CurrTumbol"] = this.Emp_CurrTumbol;
						dr["Emp_CurrAmphur"] = this.Emp_CurrAmphur;
						dr["Emp_CurrProvince"] = this.Emp_CurrProvince;
						dr["Emp_CurrZipcode"] = this.Emp_CurrZipcode;
						dr["Emp_CurrTel"] = this.Emp_CurrTel;
						dr["Emp_Nationality"] = this.Emp_Nationality;
						dr["Emp_Race"] = this.Emp_Race;
						dr["Emp_Religion"] = this.Emp_Religion;
						dr["Emp_pictures"] = this.Emp_pictures;
						dr["Emp_BankNo"] = this.Emp_BankNo;
						dr["Emp_EmpType_id"] = this.Emp_EmpType_id;
						dr["Emp_Unit_id"] = this.Emp_Unit_id;
						dr["Emp_EduDegree"] = this.Emp_EduDegree;
						dr["Emp_EduInstitute"] = this.Emp_EduInstitute;
						dr["Emp_workstatus"] = this.Emp_workstatus;
						dr["Emp_exitstatus"] = this.Emp_exitstatus;
						dr["Emp_SpouseFullName"] = this.Emp_SpouseFullName;
						dr["Emp_PassWord"] = this.Emp_PassWord;
						dr["Emp_BarCode"] = this.Emp_BarCode;
						dr["Emp_Signature"] = this.Emp_Signature;
						dr["Emp_Description"] = this.Emp_Description;

						dr["Emp_FirstSalary"] = this.Emp_FirstSalary;
						dr["Emp_CurrSalary"] = this.Emp_CurrSalary;
						dr["Emp_TaxInsurance"] = this.Emp_TaxInsurance;
						dr["Emp_TaxHouseInt"] = this.Emp_TaxHouseInt;
						dr["Emp_TaxDonation"] = this.Emp_TaxDonation;
						dr["Emp_TaxFund"] = this.Emp_TaxFund;
						dr["Emp_TaxParent"] = this.Emp_TaxParent;

						dr["Emp_TaxMarried"] = this.Emp_TaxMarried;
						dr["Emp_TaxChild"] = this.Emp_TaxChild;
						dr["Emp_TaxChildEd"] = this.Emp_TaxChildEd;
						dr["Emp_TaxParentCount"] = this.Emp_TaxParentCount;
						dr["Emp_TeacherStatus"] = this.Emp_TeacherStatus;
						dr["Emp_TaxNo"] = this.Emp_TaxNo;

						dr["Emp_Bdate"] = this.Emp_Bdate;
						dr["Emp_FirstDate"] = this.Emp_FirstDate;
						dr["Emp_StartDate"] = this.Emp_StartDate;
						dr["Emp_exitdate"] = this.Emp_exitdate;
						dr["Emp_date"] = this.Emp_date;

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