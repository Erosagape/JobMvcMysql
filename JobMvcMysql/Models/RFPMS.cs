using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFPMS
	{
		public const string tbname = "RFPMS";
		public int oid { get; set; }
		public string PermitID { get; set; }
		public string PermitIssue { get; set; }
		public string TaxNumber { get; set; }
		public string TariffClass { get; set; }
		public string InvoiceNumber { get; set; }
		public string PermitDesc1 { get; set; }
		public string PermitDesc2 { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime FinishDate { get; set; }
		public DateTime InvoiceDate { get; set; }
		public DateTime LastUpdate { get; set; }

		public List<RFPMS> get()
		{
			var rows = new List<RFPMS>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFPMS()
						{
							oid = rd.GetInt32("oid"),
							PermitID = rd.GetString("PermitID"),
							PermitIssue = rd.GetString("PermitIssue"),
							TaxNumber = rd.GetString("TaxNumber"),
							TariffClass = rd.GetString("TariffClass"),
							InvoiceNumber = rd.GetString("InvoiceNumber"),
							PermitDesc1 = rd.GetString("PermitDesc1"),
							PermitDesc2 = rd.GetString("PermitDesc2"),
							StartDate = rd.GetDateTime("StartDate"),
							FinishDate = rd.GetDateTime("FinishDate"),
							InvoiceDate = rd.GetDateTime("InvoiceDate"),
							LastUpdate = rd.GetDateTime("LastUpdate")
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
						dr["PermitID"] = this.PermitID;
						dr["PermitIssue"] = this.PermitIssue;
						dr["TaxNumber"] = this.TaxNumber;
						dr["TariffClass"] = this.TariffClass;
						dr["InvoiceNumber"] = this.InvoiceNumber;
						dr["PermitDesc1"] = this.PermitDesc1;
						dr["PermitDesc2"] = this.PermitDesc2;
						dr["StartDate"] = this.StartDate;
						dr["FinishDate"] = this.FinishDate;
						dr["InvoiceDate"] = this.InvoiceDate;
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