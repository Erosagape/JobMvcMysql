using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class MasAuthority
	{
		public const string tbname = "MasAuthority";
		public int oid { get; set; }
		public string AuthorityID { get; set; }
		public string AuthorityName { get; set; }
		public string AuthorityTaxNo { get; set; }
		public string AuthorityNSWID { get; set; }
		public string AuthorityNSWID_TEST { get; set; }

		public List<MasAuthority> get()
		{
			var rows = new List<MasAuthority>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new MasAuthority()
						{
							oid = rd.GetInt32("oid"),
							AuthorityID = rd.GetString("AuthorityID"),
							AuthorityName = rd.GetString("AuthorityName"),
							AuthorityTaxNo = rd.GetString("AuthorityTaxNo"),
							AuthorityNSWID = rd.GetString("AuthorityNSWID"),
							AuthorityNSWID_TEST = rd.GetString("AuthorityNSWID_TEST")
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
						dr["AuthorityID"] = this.AuthorityID;
						dr["AuthorityName"] = this.AuthorityName;
						dr["AuthorityTaxNo"] = this.AuthorityTaxNo;
						dr["AuthorityNSWID"] = this.AuthorityNSWID;
						dr["AuthorityNSWID_TEST"] = this.AuthorityNSWID_TEST;

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