using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFBOI
	{
		public const string tbname = "RFBOI";
		public int oid { get; set; }
		public string BOINumber { get; set; }
		public string BOI_Expand { get; set; }
		public string RefNumber { get; set; }
		public string TaxNumber1 { get; set; }
		public string TaxNumber2 { get; set; }
		public string TaxNumber3 { get; set; }
		public string TaxNumber4 { get; set; }
		public string UID { get; set; }
		public DateTime IssuedDate { get; set; }
		public DateTime MachineEffDate { get; set; }
		public DateTime RecDate { get; set; }
		public DateTime RecTime { get; set; }
		public DateTime MachineExpDate { get; set; }
		public DateTime RawMatEffDate { get; set; }
        public DateTime RawMatExpDate { get; set; }
		public Double GoodType1 { get; set; }
		public Double GoodType2 { get; set; }
		public Double GoodType3 { get; set; }

		public List<RFBOI> get()
		{
			var rows = new List<RFBOI>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFBOI()
						{
							oid = rd.GetInt32("oid"),
							BOINumber = rd.GetString("BOINumber"),
							BOI_Expand = rd.GetString("BOI_Expand"),
							RefNumber = rd.GetString("RefNumber"),
							TaxNumber1 = rd.GetString("TaxNumber1"),
							TaxNumber2 = rd.GetString("TaxNumber2"),
							TaxNumber3 = rd.GetString("TaxNumber3"),
							TaxNumber4 = rd.GetString("TaxNumber4"),
							UID = rd.GetString("UID"),

							IssuedDate = rd.GetDateTime("IssuedDate"),
							MachineEffDate = rd.GetDateTime("MachineEffDate"),
							RecDate = rd.GetDateTime("RecDate"),
							RecTime = rd.GetDateTime("RecTime"),
							MachineExpDate = rd.GetDateTime("MachineExpDate"),
							RawMatEffDate = rd.GetDateTime("RawMatEffDate"),
                            RawMatExpDate = rd.GetDateTime("RawMatExpDate"),

							GoodType1 = rd.GetDouble("GoodType1"),
							GoodType2 = rd.GetDouble("GoodType2"),
							GoodType3 = rd.GetDouble("GoodType3")
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
						dr["BOINumber"] = this.BOINumber;
						dr["BOI_Expand"] = this.BOI_Expand;
						dr["RefNumber"] = this.RefNumber;
						dr["TaxNumber1"] = this.TaxNumber1;
						dr["TaxNumber2"] = this.TaxNumber2;
						dr["TaxNumber3"] = this.TaxNumber3;
						dr["TaxNumber4"] = this.TaxNumber4;
						dr["UID"] = this.UID;
						dr["GoodType1"] = this.GoodType1;
						dr["GoodType2"] = this.GoodType2;
						dr["GoodType3"] = this.GoodType3;
						dr["IssuedDate"] = this.IssuedDate;
						dr["MachineEffDate"] = this.MachineEffDate;
						dr["RecDate"] = this.RecDate;
						dr["RecTime"] = this.RecTime;
						dr["MachineExpDate"] = this.MachineExpDate;
						dr["RawMatEffDate"] = this.RawMatEffDate;
                        dr["RawMatExpDate"] = this.RawMatExpDate;

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