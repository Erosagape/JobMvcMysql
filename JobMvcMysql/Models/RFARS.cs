using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFARS
	{
		public const string tbname = "RFARS";
		public int oid { get; set; }
		public string AreaCode { get; set; }
		public string AreaName { get; set; }
		public string AccNo { get; set; }
		public string Payee { get; set; }
		public string BankCode { get; set; }
		public string AcType { get; set; }

		public List<RFARS> get()
		{
			var rows = new List<RFARS>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFARS()
						{
							oid = rd.GetInt32("oid"),
							AreaCode = rd.GetString("AreaCode"),
							AreaName = rd.GetString("AreaName"),
							AccNo = rd.GetString("AccNo"),
							Payee = rd.GetString("Payee"),
							BankCode = rd.GetString("BankCode"),
							AcType = rd.GetString("AcType")
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
						dr["AreaCode"] = this.AreaCode;
						dr["AreaName"] = this.AreaName;
						dr["AccNo"] = this.AccNo;
						dr["Payee"] = this.Payee;
						dr["BankCode"] = this.BankCode;
						dr["AcType"] = this.AcType;

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