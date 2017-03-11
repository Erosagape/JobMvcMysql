using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class BookAccount
	{
		public const string tbname = "BookAccount";
		public int oid { get; set; }
		public string BranchCode { get; set; }
		public string BookCode { get; set; }
		public string BookName { get; set; }
		public string BankCode { get; set; }
		public string BankBranch { get; set; }
		public string ACType { get; set; }
		public string TAddress1 { get; set; }
		public string TAddress2 { get; set; }
		public string EAddress1 { get; set; }
		public string EAddress2 { get; set; }
		public string Phone { get; set; }
		public string FaxNumber { get; set; }
		public int IsLocal { get; set; }

		public List<BookAccount> get()
		{
			var rows = new List<BookAccount>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new BookAccount()
						{
							oid = rd.GetInt32("oid"),
							BranchCode = rd.GetString("BranchCode"),
							BookCode = rd.GetString("BookCode"),
							BookName = rd.GetString("BookName"),
							BankCode = rd.GetString("BankCode"),
							BankBranch = rd.GetString("BankBranch"),
							ACType = rd.GetString("ACType"),
							TAddress1 = rd.GetString("TAddress1"),
							TAddress2 = rd.GetString("TAddress2"),
							EAddress1 = rd.GetString("EAddress1"),
							EAddress2 = rd.GetString("EAddress2"),
							Phone = rd.GetString("Phone"),
							FaxNumber = rd.GetString("FaxNumber"),
							IsLocal = rd.GetInt32("IsLocal")
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
						dr["BookCode"] = this.BookCode;
						dr["BookName"] = this.BookName;
						dr["BankCode"] = this.BankCode;
						dr["BankBranch"] = this.BankBranch;
						dr["ACType"] = this.ACType;
						dr["TAddress1"] = this.TAddress1;
						dr["TAddress2"] = this.TAddress2;
						dr["EAddress1"] = this.EAddress1;
						dr["EAddress2"] = this.EAddress2;
						dr["Phone"] = this.Phone;
						dr["FaxNumber"] = this.FaxNumber;
						dr["IsLocal"] = this.IsLocal;
                        
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