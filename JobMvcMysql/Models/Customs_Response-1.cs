using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class Customs_Response1
	{
		public const string tbname = "Customs_Response-1";
		public int oid { get; set; }
		public string MailID { get; set; }
		public string RefNO { get; set; }
		public string ResponseDate { get; set; }
		public string ResponseTime { get; set; }
		public string SendFrom { get; set; }
		public string SendTo { get; set; }
		public string SubJect { get; set; }
		public string BodyText { get; set; }
		public string MailType { get; set; }
		public string DocType { get; set; }
		public string RefID { get; set; }
		public string CounterTaxID { get; set; }
		public string MailStatus { get; set; }
		public DateTime LastSendBillingDate { get; set; }
		public DateTime LastResponseBillingDate { get; set; }
		public DateTime DeleteDate { get; set; }
		public int BillingStatus { get; set; }
		public int LineItem { get; set; }
		public Double FileSendSize { get; set; }

		public List<Customs_Response1> get()
		{
			var rows = new List<Customs_Response1>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new Customs_Response1()
						{
							oid = rd.GetInt32("oid"),
							MailID = rd.GetString("MailID"),
							RefNO = rd.GetString("RefNO"),
							ResponseDate = rd.GetString("ResponseDate"),
							ResponseTime = rd.GetString("ResponseTime"),
							SendFrom = rd.GetString("SendFrom"),
							SendTo = rd.GetString("SendTo"),
							SubJect = rd.GetString("SubJect"),
							BodyText = rd.GetString("BodyText"),
							MailType = rd.GetString("MailType"),
							DocType = rd.GetString("DocType"),
							RefID = rd.GetString("RefID"),
							CounterTaxID = rd.GetString("CounterTaxID"),
							MailStatus = rd.GetString("MailStatus"),
							LastSendBillingDate = rd.GetDateTime("LastSendBillingDate"),
							LastResponseBillingDate = rd.GetDateTime("LastResponseBillingDate"),
							DeleteDate = rd.GetDateTime("DeleteDate"),
							BillingStatus = rd.GetInt32("BillingStatus"),
							LineItem = rd.GetInt32("LineItem"),
							FileSendSize = rd.GetDouble("FileSendSize")
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
						dr["MailID"] = this.MailID;
						dr["RefNO"] = this.RefNO;
						dr["ResponseDate"] = this.ResponseDate;
						dr["ResponseTime"] = this.ResponseTime;
						dr["SendFrom"] = this.SendFrom;
						dr["SendTo"] = this.SendTo;
						dr["SubJect"] = this.SubJect;
						dr["BodyText"] = this.BodyText;
						dr["MailType"] = this.MailType;
						dr["DocType"] = this.DocType;
						dr["RefID"] = this.RefID;
						dr["CounterTaxID"] = this.CounterTaxID;
						dr["MailStatus"] = this.MailStatus;
						dr["FileSendSize"] = this.FileSendSize;
						dr["BillingStatus"] = this.BillingStatus;
						dr["LineItem"] = this.LineItem;
						dr["LastSendBillingDate"] = this.LastSendBillingDate;
						dr["LastResponseBillingDate"] = this.LastResponseBillingDate;
						dr["DeleteDate"] = this.DeleteDate;

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