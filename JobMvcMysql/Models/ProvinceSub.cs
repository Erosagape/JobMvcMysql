using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class ProvinceSub
	{
		public const string tbname = "ProvinceSub";
		public int oid { get; set; }
		public string ProvinceCode { get; set; }
		public string SubProvince { get; set; }
		public string District { get; set; }
		public string PostCode { get; set; }

		public List<ProvinceSub> get()
		{
			var rows = new List<ProvinceSub>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new ProvinceSub()
						{
							oid = rd.GetInt32("oid"),
							ProvinceCode = rd.GetString("ProvinceCode"),
							SubProvince = rd.GetString("SubProvince"),
							District = rd.GetString("District"),
							PostCode = rd.GetString("PostCode")
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
						dr["ProvinceCode"] = this.ProvinceCode;
						dr["SubProvince"] = this.SubProvince;
						dr["District"] = this.District;
						dr["PostCode"] = this.PostCode;

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