using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class RFBQT
	{
		public const string tbname = "RFBQT";
		public int oid { get; set; }
		public string BOIQTANUM { get; set; }
		public string CAT { get; set; }
		public string CMPTAXNUM1 { get; set; }
		public string CMPTAXNUM2 { get; set; }
		public string CMPTAXNUM3 { get; set; }
		public string REFBQTNUM { get; set; }
		public string IVCNUM1 { get; set; }
		public string IVCNUM2 { get; set; }
		public string IVCNUM3 { get; set; }
		public string IVCNUM4 { get; set; }
		public string BOINUM1 { get; set; }
		public string BOINUM2 { get; set; }
		public string BOINUM3 { get; set; }
		public string BOINUM4 { get; set; }
		public string DTEEPR { get; set; }
		public string UIDCTEAMN { get; set; }
		public DateTime DTEISU { get; set; }
		public DateTime DTEREFBQT { get; set; }
		public DateTime DTEIVC1 { get; set; }
		public DateTime DTEIVC2 { get; set; }
		public DateTime DTEIVC3 { get; set; }
		public DateTime DTEIVC4 { get; set; }
        public DateTime DTEBOI1 { get; set; }
        public DateTime DTEBOI2 { get; set; }
        public DateTime DTEBOI3 { get; set; }
        public DateTime DTEBOI4 { get; set; }
        public DateTime DTEEFV { get; set; }
        public DateTime DTECTEAMN { get; set; }
        public DateTime TMECTEAMN { get; set; }
		public int BOIQTATYP { get; set; }
		public Double BOIEMTRTE { get; set; }

		public List<RFBQT> get()
		{
			var rows = new List<RFBQT>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new RFBQT()
						{
							oid = rd.GetInt32("oid"),
							BOIQTANUM = rd.GetString("BOIQTANUM"),
							CAT = rd.GetString("CAT"),
							CMPTAXNUM1 = rd.GetString("CMPTAXNUM1"),
							CMPTAXNUM2 = rd.GetString("CMPTAXNUM2"),
							CMPTAXNUM3 = rd.GetString("CMPTAXNUM3"),
							REFBQTNUM = rd.GetString("REFBQTNUM"),
							IVCNUM1 = rd.GetString("IVCNUM1"),
							IVCNUM2 = rd.GetString("IVCNUM2"),
							IVCNUM3 = rd.GetString("IVCNUM3"),
							IVCNUM4 = rd.GetString("IVCNUM4"),
							BOINUM1 = rd.GetString("BOINUM1"),
							BOINUM2 = rd.GetString("BOINUM2"),
							BOINUM3 = rd.GetString("BOINUM3"),
							BOINUM4 = rd.GetString("BOINUM4"),
							DTEEPR = rd.GetString("DTEEPR"),
							UIDCTEAMN = rd.GetString("UIDCTEAMN"),
							DTEISU = rd.GetDateTime("DTEISU"),
							DTEREFBQT = rd.GetDateTime("DTEREFBQT"),
							DTEIVC1 = rd.GetDateTime("DTEIVC1"),
							DTEIVC2 = rd.GetDateTime("DTEIVC2"),
							DTEIVC3 = rd.GetDateTime("DTEIVC3"),
							DTEIVC4 = rd.GetDateTime("DTEIVC4"),
                            DTEBOI1 = rd.GetDateTime("DTEBOI1"),
                            DTEBOI2 = rd.GetDateTime("DTEBOI2"),
                            DTEBOI3 = rd.GetDateTime("DTEBOI3"),
                            DTEBOI4 = rd.GetDateTime("DTEBOI4"),
                            DTEEFV = rd.GetDateTime("DTEEFV"),
                            DTECTEAMN = rd.GetDateTime("DTECTEAMN"),
                            TMECTEAMN = rd.GetDateTime("TMECTEAMN"),

							BOIQTATYP = rd.GetInt32("BOIQTATYP"),
							BOIEMTRTE = rd.GetDouble("BOIEMTRTE")
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
						dr["BOIQTANUM"] = this.BOIQTANUM;
						dr["CAT"] = this.CAT;
						dr["CMPTAXNUM1"] = this.CMPTAXNUM1;
						dr["CMPTAXNUM2"] = this.CMPTAXNUM2;
						dr["CMPTAXNUM3"] = this.CMPTAXNUM3;
						dr["REFBQTNUM"] = this.REFBQTNUM;
						dr["IVCNUM1"] = this.IVCNUM1;
						dr["IVCNUM2"] = this.IVCNUM2;
						dr["IVCNUM3"] = this.IVCNUM3;
						dr["IVCNUM4"] = this.IVCNUM4;
						dr["BOINUM1"] = this.BOINUM1;
						dr["BOINUM2"] = this.BOINUM2;
						dr["BOINUM3"] = this.BOINUM3;
						dr["BOINUM4"] = this.BOINUM4;
						dr["DTEEPR"] = this.DTEEPR;
						dr["UIDCTEAMN"] = this.UIDCTEAMN;
						dr["BOIEMTRTE"] = this.BOIEMTRTE;
						dr["BOIQTATYP"] = this.BOIQTATYP;
						dr["DTEISU"] = this.DTEISU;
						dr["DTEREFBQT"] = this.DTEREFBQT;
						dr["DTEIVC1"] = this.DTEIVC1;
						dr["DTEIVC2"] = this.DTEIVC2;
						dr["DTEIVC3"] = this.DTEIVC3;
						dr["DTEIVC4"] = this.DTEIVC4;
                        dr["DTEBOI1"] = this.DTEBOI1;
                        dr["DTEBOI2"] = this.DTEBOI2;
                        dr["DTEBOI3"] = this.DTEBOI3;
                        dr["DTEBOI4"] = this.DTEBOI4;
                        dr["DTEEFV"] = this.DTEEFV;
                        dr["DTECTEAMN"] = this.DTECTEAMN;
                        dr["TMECTEAMN"] = this.TMECTEAMN;

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