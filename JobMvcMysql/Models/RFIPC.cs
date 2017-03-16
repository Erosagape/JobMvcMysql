using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFIPC
	{
		public const string tbname = "RFIPC";
		public int oid { get; set; }
		public string PortCode { get; set; }
		public string PortName { get; set; }
        public string CountryCode { get; set; }

		public List<RFIPC> get()
		{
			var rows = new List<RFIPC>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFIPC()
						{
							oid = rd.GetInt32("oid"),
							PortCode = rd.GetString("PortCode"),
                            CountryCode = rd.GetString("CountryCode"),
							PortName = rd.GetString("PortName")
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
						dr["PortCode"] = this.PortCode;
						dr["PortName"] = this.PortName;
                        dr["CountryCode"] = this.CountryCode;

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