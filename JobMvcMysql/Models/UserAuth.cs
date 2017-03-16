using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class UserAuth
	{
		public const string tbname = "UserAuth";
		public int oid { get; set; }
		public string UserID { get; set; }
		public string AppID { get; set; }
		public string Author { get; set; }
		public int MenuID { get; set; }

		public List<UserAuth> get()
		{
			var rows = new List<UserAuth>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new UserAuth()
						{
							oid = rd.GetInt32("oid"),
							UserID = rd.GetString("UserID"),
							AppID = rd.GetString("AppID"),
							Author = rd.GetString("Author"),
							MenuID = rd.GetInt32("MenuID")
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
						dr["UserID"] = this.UserID;
						dr["AppID"] = this.AppID;
						dr["Author"] = this.Author;
						dr["MenuID"] = this.MenuID;

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