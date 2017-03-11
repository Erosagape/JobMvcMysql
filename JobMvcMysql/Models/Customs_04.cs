using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class Customs_04
	{
		public const string tbname = "Customs_04";
		public int oid { get; set; }
		public string CusresFileName { get; set; }
		public string CusType { get; set; }
		public string Status { get; set; }
		public string RefNo { get; set; }
		public string AuditTime { get; set; }
		public string ContainerNo { get; set; }
		public string Vessel { get; set; }
		public string DecNo { get; set; }

		public List<Customs_04> get()
		{
			var rows = new List<Customs_04>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new Customs_04()
						{
							oid = rd.GetInt32("oid"),
							CusresFileName = rd.GetString("CusresFileName"),
							CusType = rd.GetString("CusType"),
							Status = rd.GetString("Status"),
							RefNo = rd.GetString("RefNo"),
							AuditTime = rd.GetString("AuditTime"),
							ContainerNo = rd.GetString("ContainerNo"),
							Vessel = rd.GetString("Vessel"),
							DecNo = rd.GetString("DecNo")
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
						dr["CusresFileName"] = this.CusresFileName;
						dr["CusType"] = this.CusType;
						dr["Status"] = this.Status;
						dr["RefNo"] = this.RefNo;
						dr["AuditTime"] = this.AuditTime;
						dr["ContainerNo"] = this.ContainerNo;
						dr["Vessel"] = this.Vessel;
						dr["DecNo"] = this.DecNo;

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