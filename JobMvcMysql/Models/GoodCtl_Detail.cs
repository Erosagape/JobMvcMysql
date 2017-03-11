using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class GoodCtl_Detail
	{
		public const string tbname = "GoodCtl_Detail";
		public int oid { get; set; }
		public string BranchCode { get; set; }
		public string RefNO { get; set; }
		public string ContainerNo { get; set; }
		public string DecNO { get; set; }
		public string PdtDescription { get; set; }
		public string LodgePort { get; set; }
		public string DCmpTaxNo { get; set; }
		public string DCmpCode { get; set; }
		public string DCmpBranch { get; set; }
		public string PackageUnit { get; set; }
		public string DGrossWeightUnit { get; set; }
		public string DecRefNo { get; set; }
		public string AdditionDesc { get; set; }
		public string HouseBL { get; set; }
		public string MasterBL { get; set; }
		public int ItemNo { get; set; }
		public int DecItemNo { get; set; }
		public int DecRevised { get; set; }
		public int Revised { get; set; }
		public Double PackageAmount { get; set; }
		public Double DGrossWeight { get; set; }

		public List<GoodCtl_Detail> get()
		{
			var rows = new List<GoodCtl_Detail>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new GoodCtl_Detail()
						{
							oid = rd.GetInt32("oid"),
							BranchCode = rd.GetString("BranchCode"),
							RefNO = rd.GetString("RefNO"),
							ContainerNo = rd.GetString("ContainerNo"),
							DecNO = rd.GetString("DecNO"),
							PdtDescription = rd.GetString("PdtDescription"),
							LodgePort = rd.GetString("LodgePort"),
							DCmpTaxNo = rd.GetString("DCmpTaxNo"),
							DCmpCode = rd.GetString("DCmpCode"),
							DCmpBranch = rd.GetString("DCmpBranch"),
							PackageUnit = rd.GetString("PackageUnit"),
							DGrossWeightUnit = rd.GetString("DGrossWeightUnit"),
							DecRefNo = rd.GetString("DecRefNo"),
							AdditionDesc = rd.GetString("AdditionDesc"),
							HouseBL = rd.GetString("HouseBL"),
							MasterBL = rd.GetString("MasterBL"),
							ItemNo = rd.GetInt32("ItemNo"),
							DecItemNo = rd.GetInt32("DecItemNo"),
							DecRevised = rd.GetInt32("DecRevised"),
							Revised = rd.GetInt32("Revised"),
							PackageAmount = rd.GetDouble("PackageAmount"),
							DGrossWeight = rd.GetDouble("DGrossWeight")
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
						dr["ContainerNo"] = this.ContainerNo;
						dr["DecNO"] = this.DecNO;
						dr["PdtDescription"] = this.PdtDescription;
						dr["LodgePort"] = this.LodgePort;
						dr["DCmpTaxNo"] = this.DCmpTaxNo;
						dr["DCmpCode"] = this.DCmpCode;
						dr["DCmpBranch"] = this.DCmpBranch;
						dr["PackageUnit"] = this.PackageUnit;
						dr["DGrossWeightUnit"] = this.DGrossWeightUnit;
						dr["DecRefNo"] = this.DecRefNo;
						dr["AdditionDesc"] = this.AdditionDesc;
						dr["HouseBL"] = this.HouseBL;
						dr["MasterBL"] = this.MasterBL;
						dr["PackageAmount"] = this.PackageAmount;
						dr["DGrossWeight"] = this.DGrossWeight;
						dr["ItemNo"] = this.ItemNo;
						dr["DecItemNo"] = this.DecItemNo;
						dr["DecRevised"] = this.DecRevised;
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