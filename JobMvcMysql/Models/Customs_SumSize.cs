using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class Customs_SumSize
	{
		public const string tbname = "Customs_SumSize";
		public int oid { get; set; }
		public string RefID { get; set; }
		public string CounterTaxID { get; set; }
		public string DocType { get; set; }
		public DateTime LastSendDate { get; set; }
		public DateTime LastResponseDate { get; set; }
		public int SumMonth { get; set; }
		public int SumYear { get; set; }
		public int BillingStatus { get; set; }
		public Double TotalFileSize { get; set; }

		public List<Customs_SumSize> get()
		{
			var rows = new List<Customs_SumSize>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new Customs_SumSize()
						{
							oid = rd.GetInt32("oid"),
							RefID = rd.GetString("RefID"),
							CounterTaxID = rd.GetString("CounterTaxID"),
							DocType = rd.GetString("DocType"),
							LastSendDate = rd.GetDateTime("LastSendDate"),
							LastResponseDate = rd.GetDateTime("LastResponseDate"),
							SumMonth = rd.GetInt32("SumMonth"),
							SumYear = rd.GetInt32("SumYear"),
							BillingStatus = rd.GetInt32("BillingStatus"),
							TotalFileSize = rd.GetDouble("TotalFileSize")
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
						dr["RefID"] = this.RefID;
						dr["CounterTaxID"] = this.CounterTaxID;
						dr["DocType"] = this.DocType;
						dr["TotalFileSize"] = this.TotalFileSize;
						dr["SumMonth"] = this.SumMonth;
						dr["SumYear"] = this.SumYear;
						dr["BillingStatus"] = this.BillingStatus;
						dr["LastSendDate"] = this.LastSendDate;
						dr["LastResponseDate"] = this.LastResponseDate;

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