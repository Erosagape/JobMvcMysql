using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFVSL
	{
		public const string tbname = "RFVSL";
		public int oid { get; set; }
		public string RegsNumber { get; set; }
		public string Name { get; set; }
		public string OwnerTax { get; set; }
		public string NaCountry { get; set; }
		public string CargoType { get; set; }
		public string VesselType { get; set; }
		public string RiskRating { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime FinishDate { get; set; }
		public DateTime LastUpdate { get; set; }
		public int InspecCount { get; set; }
		public Double TareTonnage { get; set; }

		public List<RFVSL> get()
		{
			var rows = new List<RFVSL>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFVSL()
						{
							oid = rd.GetInt32("oid"),
							RegsNumber = rd.GetString("RegsNumber"),
							Name = rd.GetString("Name"),
							OwnerTax = rd.GetString("OwnerTax"),
							NaCountry = rd.GetString("NaCountry"),
							CargoType = rd.GetString("CargoType"),
							VesselType = rd.GetString("VesselType"),
							RiskRating = rd.GetString("RiskRating"),
							StartDate = rd.GetDateTime("StartDate"),
							FinishDate = rd.GetDateTime("FinishDate"),
							LastUpdate = rd.GetDateTime("LastUpdate"),
							InspecCount = rd.GetInt32("InspecCount"),
							TareTonnage = rd.GetDouble("TareTonnage")
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
						dr["RegsNumber"] = this.RegsNumber;
						dr["Name"] = this.Name;
						dr["OwnerTax"] = this.OwnerTax;
						dr["NaCountry"] = this.NaCountry;
						dr["CargoType"] = this.CargoType;
						dr["VesselType"] = this.VesselType;
						dr["RiskRating"] = this.RiskRating;
						dr["TareTonnage"] = this.TareTonnage;
						dr["InspecCount"] = this.InspecCount;
						dr["StartDate"] = this.StartDate;
						dr["FinishDate"] = this.FinishDate;
						dr["LastUpdate"] = this.LastUpdate;

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