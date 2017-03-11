using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class CFlags
	{
		public const string tbname = "CFlag";
		public int oid { get; set; }
		public string CIndex { get; set; }
		public string CValue { get; set; }
		public string CUpdate { get; set; }
		public string CFlag { get; set; }

		public List<CFlags> get()
		{
			var rows = new List<CFlags>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new CFlags()
						{
							oid = rd.GetInt32("oid"),
							CIndex = rd.GetString("CIndex"),
							CValue = rd.GetString("CValue"),
							CUpdate = rd.GetString("CUpdate"),
							CFlag = rd.GetString("CFlag")
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
						dr["CIndex"] = this.CIndex;
						dr["CValue"] = this.CValue;
						dr["CUpdate"] = this.CUpdate;
						dr["CFlag"] = this.CFlag;

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