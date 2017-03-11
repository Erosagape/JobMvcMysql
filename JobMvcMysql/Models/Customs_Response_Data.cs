using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class Customs_Response_Data
	{
		public const string tbname = "Customs_Response_Data";
		public int oid { get; set; }
		public string MailID { get; set; }
		public string AttachmentFileName { get; set; }
		public string AttachmentData { get; set; }
		public int ProcessTimes { get; set; }

		public List<Customs_Response_Data> get()
		{
			var rows = new List<Customs_Response_Data>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new Customs_Response_Data()
						{
							oid = rd.GetInt32("oid"),
							MailID = rd.GetString("MailID"),
							AttachmentFileName = rd.GetString("AttachmentFileName"),
							AttachmentData = rd.GetString("AttachmentData"),
							ProcessTimes = rd.GetInt32("ProcessTimes")
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
						dr["AttachmentFileName"] = this.AttachmentFileName;
						dr["AttachmentData"] = this.AttachmentData;
						dr["ProcessTimes"] = this.ProcessTimes;

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