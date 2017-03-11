using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class Declare_Remark
	{
		public const string tbname = "Declare_Remark";
		public int oid { get; set; }
		public string BranchCode { get; set; }
		public string RefNO { get; set; }
		public string Title { get; set; }
		public string Dremark { get; set; }
		public string RecBy { get; set; }
		public string OwnerType { get; set; }
		public DateTime RecDate { get; set; }
		public DateTime RecTime { get; set; }
		public int ItemNo { get; set; }
		public int Revised { get; set; }

		public List<Declare_Remark> get()
		{
			var rows = new List<Declare_Remark>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new Declare_Remark()
						{
							oid = rd.GetInt32("oid"),
							BranchCode = rd.GetString("BranchCode"),
							RefNO = rd.GetString("RefNO"),
							Title = rd.GetString("Title"),
							Dremark = rd.GetString("Dremark"),
							RecBy = rd.GetString("RecBy"),
							OwnerType = rd.GetString("OwnerType"),
							RecDate = rd.GetDateTime("RecDate"),
							RecTime = rd.GetDateTime("RecTime"),
							ItemNo = rd.GetInt32("ItemNo"),
							Revised = rd.GetInt32("Revised")
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
						dr["Title"] = this.Title;
						dr["Dremark"] = this.Dremark;
						dr["RecBy"] = this.RecBy;
						dr["OwnerType"] = this.OwnerType;

						dr["ItemNo"] = this.ItemNo;
						dr["Revised"] = this.Revised;

						dr["RecDate"] = this.RecDate;
						dr["RecTime"] = this.RecTime;

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