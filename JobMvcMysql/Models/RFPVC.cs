using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFPVC
	{
		public const string tbname = "RFPVC";
		public int oid { get; set; }
		public string PrivilegeCode { get; set; }
		public string Description { get; set; }
		public string AnnualNo { get; set; }
		public string AnnualDescription { get; set; }
		public DateTime AnnualDate { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime FinishDate { get; set; }

		public List<RFPVC> get()
		{
			var rows = new List<RFPVC>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFPVC()
						{
							oid = rd.GetInt32("oid"),
							PrivilegeCode = rd.GetString("PrivilegeCode"),
							Description = rd.GetString("Description"),
							AnnualNo = rd.GetString("AnnualNo"),
							AnnualDescription = rd.GetString("AnnualDescription")
							AnnualDate = rd.GetDateTime("AnnualDate"),
							StartDate = rd.GetDateTime("StartDate"),
							FinishDate = rd.GetDateTime("FinishDate")
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
						dr["PrivilegeCode"] = this.PrivilegeCode;
						dr["Description"] = this.Description;
						dr["AnnualNo"] = this.AnnualNo;
						dr["AnnualDescription"] = this.AnnualDescription;
						dr["AnnualDate"] = this.AnnualDate;
						dr["StartDate"] = this.StartDate;
						dr["FinishDate"] = this.FinishDate;

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