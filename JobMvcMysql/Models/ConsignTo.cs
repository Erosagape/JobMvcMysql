using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class ConsignTo
	{
		public const string tbname = "ConsignTo";
		public int oid { get; set; }
		public string ConCode { get; set; }
		public string ConTo { get; set; }
		public string NameEng { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string TaxNumber { get; set; }
		public string CountryCode { get; set; }
		public string ZipCode { get; set; }
		public string CityName { get; set; }
		public string DestinationPort { get; set; }
		public string Phone { get; set; }
		public string FaxNumber { get; set; }
		public string EMailAddress { get; set; }
		public string Address3 { get; set; }

		public List<ConsignTo> get()
		{
			var rows = new List<ConsignTo>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new ConsignTo()
						{
							oid = rd.GetInt32("oid"),
                            TaxNumber = rd.GetString("TaxNumber"),
							ConCode = rd.GetString("ConCode"),
							ConTo = rd.GetString("ConTo"),
							NameEng = rd.GetString("NameEng"),
							Address1 = rd.GetString("Address1"),
							Address2 = rd.GetString("Address2"),							
							CountryCode = rd.GetString("CountryCode"),
							ZipCode = rd.GetString("ZipCode"),
							CityName = rd.GetString("CityName"),
							DestinationPort = rd.GetString("DestinationPort"),
							Phone = rd.GetString("Phone"),
							FaxNumber = rd.GetString("FaxNumber"),
							EMailAddress = rd.GetString("EMailAddress"),
							Address3 = rd.GetString("Address3")
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
						dr["ConCode"] = this.ConCode;
						dr["ConTo"] = this.ConTo;
						dr["NameEng"] = this.NameEng;
						dr["Address1"] = this.Address1;
						dr["Address2"] = this.Address2;						
						dr["CountryCode"] = this.CountryCode;
						dr["ZipCode"] = this.ZipCode;
						dr["CityName"] = this.CityName;
						dr["DestinationPort"] = this.DestinationPort;
						dr["Phone"] = this.Phone;
						dr["FaxNumber"] = this.FaxNumber;
						dr["EMailAddress"] = this.EMailAddress;
						dr["Address3"] = this.Address3;

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