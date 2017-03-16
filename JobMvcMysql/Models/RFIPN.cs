using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFIPN
	{
		public const string tbname = "RFIPN";
		public int oid { get; set; }
		public string MICode { get; set; }
		public string Message1 { get; set; }
		public string Message2 { get; set; }
		public string Message3 { get; set; }

		public List<RFIPN> get()
		{
			var rows = new List<RFIPN>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFIPN()
						{
							oid = rd.GetInt32("oid"),
							MICode = rd.GetString("MICode"),
							Message1 = rd.GetString("Message1"),
							Message2 = rd.GetString("Message2"),
							Message3 = rd.GetString("Message3")
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
						dr["MICode"] = this.MICode;
						dr["Message1"] = this.Message1;
						dr["Message2"] = this.Message2;
						dr["Message3"] = this.Message3;

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