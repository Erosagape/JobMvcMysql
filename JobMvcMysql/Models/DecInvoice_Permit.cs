using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class DecInvoice_Permit
	{
		public const string tbname = "DecInvoice_Permit";
		public int oid { get; set; }
		public string BranchCode { get; set; }
		public string RefNO { get; set; }
		public string InvNO { get; set; }
		public string PermitNO { get; set; }
		public string IssueBy { get; set; }
		public DateTime IssueDate { get; set; }
		public int InvItemNo { get; set; }
		public int ID { get; set; }

		public List<DecInvoice_Permit> get()
		{
			var rows = new List<DecInvoice_Permit>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new DecInvoice_Permit()
						{
							oid = rd.GetInt32("oid"),
							BranchCode = rd.GetString("BranchCode"),
							RefNO = rd.GetString("RefNO"),
							InvNO = rd.GetString("InvNO"),
							PermitNO = rd.GetString("PermitNO"),
							IssueBy = rd.GetString("IssueBy"),
							IssueDate = rd.GetDateTime("IssueDate"),
							InvItemNo = rd.GetInt32("InvItemNo"),
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
						dr["BranchCode"] = this.BranchCode;
						dr["RefNO"] = this.RefNO;
						dr["InvNO"] = this.InvNO;
						dr["PermitNO"] = this.PermitNO;
						dr["IssueBy"] = this.IssueBy;
						dr["InvItemNo"] = this.InvItemNo;
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