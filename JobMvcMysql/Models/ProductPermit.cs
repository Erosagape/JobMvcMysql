using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class ProductPermit
	{
		public const string tbname = "ProductPermit";
		public int oid { get; set; }
		public string TaxNumber { get; set; }
		public string SubCode { get; set; }
		public string PermitNo { get; set; }
		public string IssueBy { get; set; }
		public string AutoLoad { get; set; }
		public DateTime IssueDate { get; set; }
		public int ID { get; set; }

		public List<ProductPermit> get()
		{
			var rows = new List<ProductPermit>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new ProductPermit()
						{
							oid = rd.GetInt32("oid"),
							TaxNumber = rd.GetString("TaxNumber"),
							SubCode = rd.GetString("SubCode"),
							PermitNo = rd.GetString("PermitNo"),
							IssueBy = rd.GetString("IssueBy"),
							AutoLoad = rd.GetString("AutoLoad"),
							IssueDate = rd.GetDateTime("IssueDate"),
							ID = rd.GetInt32("ID")
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
						dr["SubCode"] = this.SubCode;
						dr["PermitNo"] = this.PermitNo;
						dr["IssueBy"] = this.IssueBy;
						dr["AutoLoad"] = this.AutoLoad;
						dr["ID"] = this.ID;
						dr["IssueDate"] = this.IssueDate;

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