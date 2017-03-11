using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class Declare_Duty
	{
		public const string tbname = "Declare_Duty";
		public int oid { get; set; }
		public string BranchCode { get; set; }
		public string RefNO { get; set; }
		public string DutyType { get; set; }
		public string SpecCalcBy { get; set; }
		public string ArgumentSpecUnit { get; set; }

		public int DecItemNo { get; set; }
		public int ItemNo { get; set; }
		public int IntMonth { get; set; }
		public int Revised { get; set; }

		public Double ValueRate { get; set; }
		public Double SpecRate { get; set; }
		public Double ValueRateP { get; set; }
		public Double SpecRateP { get; set; }
		public Double ExeRate { get; set; }
		public Double DutyAmt { get; set; }
		public Double DutyAmtP { get; set; }
		public Double DepositAmt { get; set; }
		public Double IntRate { get; set; }
		public Double Interest { get; set; }
		public Double ArgumentValueRate { get; set; }
		public Double ArgumentSpecRate { get; set; }

		public List<Declare_Duty> get()
		{
			var rows = new List<Declare_Duty>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new Declare_Duty()
						{
							oid = rd.GetInt32("oid"),
							BranchCode = rd.GetString("BranchCode"),
							RefNO = rd.GetString("RefNO"),
							DutyType = rd.GetString("DutyType"),
							SpecCalcBy = rd.GetString("SpecCalcBy"),
							ArgumentSpecUnit = rd.GetString("ArgumentSpecUnit"),

							DecItemNo = rd.GetInt32("DecItemNo"),
							ItemNo = rd.GetInt32("ItemNo"),
							IntMonth = rd.GetInt32("IntMonth"),
							Revised = rd.GetInt32("Revised"),

							ValueRate = rd.GetDouble("ValueRate"),
							SpecRate = rd.GetDouble("SpecRate"),
							ValueRateP = rd.GetDouble("ValueRateP"),
							SpecRateP = rd.GetDouble("SpecRateP"),
							ExeRate = rd.GetDouble("ExeRate"),
							DutyAmt = rd.GetDouble("DutyAmt"),
							DutyAmtP = rd.GetDouble("DutyAmtP"),
							DepositAmt = rd.GetDouble("DepositAmt"),
							IntRate = rd.GetDouble("IntRate"),
							Interest = rd.GetDouble("Interest"),
							ArgumentValueRate = rd.GetDouble("ArgumentValueRate"),
							ArgumentSpecRate = rd.GetDouble("ArgumentSpecRate")
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
						dr["DutyType"] = this.DutyType;
						dr["SpecCalcBy"] = this.SpecCalcBy;
						dr["ArgumentSpecUnit"] = this.ArgumentSpecUnit;

						dr["ValueRate"] = this.ValueRate;
						dr["SpecRate"] = this.SpecRate;
						dr["ValueRateP"] = this.ValueRateP;
						dr["SpecRateP"] = this.SpecRateP;
						dr["ExeRate"] = this.ExeRate;
						dr["DutyAmt"] = this.DutyAmt;
						dr["DutyAmtP"] = this.DutyAmtP;
						dr["DepositAmt"] = this.DepositAmt;
						dr["IntRate"] = this.IntRate;
						dr["Interest"] = this.Interest;
						dr["ArgumentValueRate"] = this.ArgumentValueRate;
						dr["ArgumentSpecRate"] = this.ArgumentSpecRate;

						dr["DecItemNo"] = this.DecItemNo;
						dr["ItemNo"] = this.ItemNo;
						dr["IntMonth"] = this.IntMonth;
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