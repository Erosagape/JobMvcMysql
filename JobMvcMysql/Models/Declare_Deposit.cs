using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class Declare_Deposit
	{
		public const string tbname = "Declare_Deposit";
		public int oid { get; set; }
		public string BranchCode { get; set; }
		public string RefNO { get; set; }
		public string DepositReason { get; set; }
		public string DutyType { get; set; }
		public int DecItemNo { get; set; }
		public int ItemNo { get; set; }
		public int DepositItemNo { get; set; }
		public int Revised { get; set; }
		public Double DepositAmt { get; set; }

		public List<Declare_Deposit> get()
		{
			var rows = new List<Declare_Deposit>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new Declare_Deposit()
						{
							oid = rd.GetInt32("oid"),
							BranchCode = rd.GetString("BranchCode"),
							RefNO = rd.GetString("RefNO"),
							DepositReason = rd.GetString("DepositReason"),
							DutyType = rd.GetString("DutyType"),
							DecItemNo = rd.GetInt32("DecItemNo"),
							ItemNo = rd.GetInt32("ItemNo"),
							DepositItemNo = rd.GetInt32("DepositItemNo"),
							Revised = rd.GetInt32("Revised"),
							DepositAmt = rd.GetDouble("DepositAmt")
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
						dr["DepositReason"] = this.DepositReason;
						dr["DutyType"] = this.DutyType;
						dr["DepositAmt"] = this.DepositAmt;
						dr["DecItemNo"] = this.DecItemNo;
						dr["ItemNo"] = this.ItemNo;
						dr["DepositItemNo"] = this.DepositItemNo;
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