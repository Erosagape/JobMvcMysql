using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class Reference_Table
	{
		public const string tbname = "Reference_Table";
		public int oid { get; set; }
		public string FileName { get; set; }
		public string FileDownload { get; set; }
		public string FileDescription { get; set; }
		public string TableName { get; set; }
		public int Selected { get; set; }
		public int DeletedBefore { get; set; }

		public List<Reference_Table> get()
		{
			var rows = new List<Reference_Table>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new Reference_Table()
						{
							oid = rd.GetInt32("oid"),
							FileName = rd.GetString("FileName"),
							FileDownload = rd.GetString("FileDownload"),
							FileDescription = rd.GetString("FileDescription"),
							TableName = rd.GetString("TableName"),
							Selected = rd.GetInt32("Selected"),
							DeletedBefore = rd.GetInt32("DeletedBefore")
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
						dr["FileName"] = this.FileName;
						dr["FileDownload"] = this.FileDownload;
						dr["FileDescription"] = this.FileDescription;
						dr["TableName"] = this.TableName;
						dr["Selected"] = this.Selected;
						dr["DeletedBefore"] = this.DeletedBefore;

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