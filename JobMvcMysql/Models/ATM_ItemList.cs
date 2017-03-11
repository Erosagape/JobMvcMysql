using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class ATM_ItemList
	{
		public const string tbname = "ATM_ItemList";
		public int oid { get; set; }
		public string RefVer { get; set; }
		public string RefNo { get; set; }
		public string DocType { get; set; }
		public string DocStatus { get; set; }
		public string DocRejectReason { get; set; }
		public string ProveBy { get; set; }
		public string RejectBy { get; set; }
		public string SignBy { get; set; }
		
		public DateTime RefDate { get; set; }
		public DateTime ProveDate { get; set; }
		public DateTime RejectDate { get; set; }
		public DateTime SignDate { get; set; }

		public List<ATM_ItemList> get()
		{
			var rows = new List<ATM_ItemList>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new ATM_ItemList()
						{
							oid = rd.GetInt32("oid"),
                            RefNo = rd.GetString("RefNo"),
							RefVer = rd.GetString("RefVer"),							
							DocType = rd.GetString("DocType"),
							DocStatus = rd.GetString("DocStatus"),
							DocRejectReason = rd.GetString("DocRejectReason"),
							ProveBy = rd.GetString("ProveBy"),
							RejectBy = rd.GetString("RejectBy"),
							SignBy = rd.GetString("SignBy"),

							RefDate = rd.GetDateTime("RefDate"),
							ProveDate = rd.GetDateTime("ProveDate"),
							RejectDate = rd.GetDateTime("RejectDate"),
							SignDate = rd.GetDateTime("SignDate")
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
						dr["RefVer"] = this.RefVer;
						dr["RefNo"] = this.RefNo;
						dr["DocType"] = this.DocType;
						dr["DocStatus"] = this.DocStatus;
						dr["DocRejectReason"] = this.DocRejectReason;
						dr["ProveBy"] = this.ProveBy;
						dr["RejectBy"] = this.RejectBy;
						dr["SignBy"] = this.SignBy;

						dr["RefDate"] = this.RefDate;
						dr["ProveDate"] = this.ProveDate;
						dr["RejectDate"] = this.RejectDate;
						dr["SignDate"] = this.SignDate;

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