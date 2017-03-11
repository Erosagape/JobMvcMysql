using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class Declare_Permit
	{
		public const string tbname = "Declare_Permit";
		public int oid { get; set; }
		public string BranchCode { get; set; }
		public string RefNO { get; set; }
		public string PermitNO { get; set; }
		public string PermitIssue { get; set; }
		public string IssueDate { get; set; }
		public string PermitBy { get; set; }
		public int DecItemNO { get; set; }
		public int ItemNo { get; set; }
		public int Revised { get; set; }

		public List<Declare_Permit> get()
		{
			var rows = new List<Declare_Permit>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new Declare_Permit()
						{
							oid = rd.GetInt32("oid"),
							BranchCode = rd.GetString("BranchCode"),
							RefNO = rd.GetString("RefNO"),
							PermitNO = rd.GetString("PermitNO"),
							PermitIssue = rd.GetString("PermitIssue"),
							IssueDate = rd.GetString("IssueDate"),
							PermitBy = rd.GetString("PermitBy"),

							DecItemNO = rd.GetInt32("DecItemNO"),
							ItemNo = rd.GetInt32("ItemNo"),
							Revised = rd.GetInt32("Revised")
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
						dr["PermitNO"] = this.PermitNO;
						dr["PermitIssue"] = this.PermitIssue;
						dr["IssueDate"] = this.IssueDate;
						dr["PermitBy"] = this.PermitBy;
						dr["DecItemNO"] = this.DecItemNO;
						dr["ItemNo"] = this.ItemNo;
						dr["Revised"] = this.Revised;


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