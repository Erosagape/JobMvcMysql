using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class Manager
	{
		public const string tbname = "Manager";
		public int oid { get; set; }
		public string TaxNumber { get; set; }
		public string Name { get; set; }
		public string CardID { get; set; }
		public string LtdPsNation { get; set; }
		public DateTime CardBeginDate { get; set; }
		public DateTime CardFinishDate { get; set; }
		public DateTime LastUpDate { get; set; }
		public int SeqNO { get; set; }
		public int Type { get; set; }
		public int LtdPsOld { get; set; }

		public List<Manager> get()
		{
			var rows = new List<Manager>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new Manager()
						{
							oid = rd.GetInt32("oid"),
							TaxNumber = rd.GetString("TaxNumber"),
							Name = rd.GetString("Name"),
							CardID = rd.GetString("CardID"),
							LtdPsNation = rd.GetString("LtdPsNation"),
							CardBeginDate = rd.GetDateTime("CardBeginDate"),
							CardFinishDate = rd.GetDateTime("CardFinishDate"),
							LastUpDate = rd.GetDateTime("LastUpDate"),
							SeqNO = rd.GetInt32("SeqNO"),
							Type = rd.GetInt32("Type"),
							LtdPsOld = rd.GetInt32("LtdPsOld")
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
						dr["TaxNumber"] = this.TaxNumber;
						dr["Name"] = this.Name;
						dr["CardID"] = this.CardID;
						dr["LtdPsNation"] = this.LtdPsNation;
						dr["SeqNO"] = this.SeqNO;
						dr["Type"] = this.Type;
						dr["LtdPsOld"] = this.LtdPsOld;
						dr["CardBeginDate"] = this.CardBeginDate;
						dr["CardFinishDate"] = this.CardFinishDate;
						dr["LastUpDate"] = this.LastUpDate;

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