using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class Consignee
	{
		public const string tbname = "Consignee";
		public int oid { get; set; }
        public string TaxNumber { get; set; }
		public string Code { get; set; }
		public string NameEng { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string CityName { get; set; }		
		public string ZipCode { get; set; }
		public string CountryCode { get; set; }
		public string DestinationPort { get; set; }
		public string Phone { get; set; }
		public string FaxNumber { get; set; }
		public string CommFormName { get; set; }
		public string PackFormName { get; set; }
		public string CustFormName { get; set; }
		public string CommStyle { get; set; }
		public string CustStyle { get; set; }
		public string PackStyle { get; set; }
		public string TAddress { get; set; }
		public string TDistrict { get; set; }
		public string TSubProvince { get; set; }
		public string TProvince { get; set; }
		public string TPostCode { get; set; }
		public string DMailAddress { get; set; }
		public string TProvinceName { get; set; }

		public List<Consignee> get()
		{
			var rows = new List<Consignee>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new Consignee()
						{
							oid = rd.GetInt32("oid"),
                            TaxNumber = rd.GetString("TaxNumber"),
							Code = rd.GetString("Code"),
							NameEng = rd.GetString("NameEng"),
							Address1 = rd.GetString("Address1"),
							Address2 = rd.GetString("Address2"),
							CityName = rd.GetString("CityName"),							
							ZipCode = rd.GetString("ZipCode"),
							CountryCode = rd.GetString("CountryCode"),
							DestinationPort = rd.GetString("DestinationPort"),
							Phone = rd.GetString("Phone"),
							FaxNumber = rd.GetString("FaxNumber"),
							CommFormName = rd.GetString("CommFormName"),
							PackFormName = rd.GetString("PackFormName"),
							CustFormName = rd.GetString("CustFormName"),
							CommStyle = rd.GetString("CommStyle"),
							CustStyle = rd.GetString("CustStyle"),
							PackStyle = rd.GetString("PackStyle"),
							TAddress = rd.GetString("TAddress"),
							TDistrict = rd.GetString("TDistrict"),
							TSubProvince = rd.GetString("TSubProvince"),
							TProvince = rd.GetString("TProvince"),
							TPostCode = rd.GetString("TPostCode"),
							DMailAddress = rd.GetString("DMailAddress"),
							TProvinceName = rd.GetString("TProvinceName")
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
                        dr["TaxNumber"] = this.TaxNumber;
						dr["Code"] = this.Code;
						dr["NameEng"] = this.NameEng;
						dr["Address1"] = this.Address1;
						dr["Address2"] = this.Address2;
						dr["CityName"] = this.CityName;						
						dr["ZipCode"] = this.ZipCode;
						dr["CountryCode"] = this.CountryCode;
						dr["DestinationPort"] = this.DestinationPort;
						dr["Phone"] = this.Phone;
						dr["FaxNumber"] = this.FaxNumber;
						dr["CommFormName"] = this.CommFormName;
						dr["PackFormName"] = this.PackFormName;
						dr["CustFormName"] = this.CustFormName;
						dr["CommStyle"] = this.CommStyle;
						dr["CustStyle"] = this.CustStyle;
						dr["PackStyle"] = this.PackStyle;
						dr["TAddress"] = this.TAddress;
						dr["TDistrict"] = this.TDistrict;
						dr["TSubProvince"] = this.TSubProvince;
						dr["TProvince"] = this.TProvince;
						dr["TPostCode"] = this.TPostCode;
						dr["DMailAddress"] = this.DMailAddress;
						dr["TProvinceName"] = this.TProvinceName;

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