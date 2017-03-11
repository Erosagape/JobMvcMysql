using System.Collections.Generic;
using System;
namespace JobMvcMysql
{
	public class GoodCtl_Header
	{
		public const string tbname = "GoodCtl_Header";
		public int oid { get; set; }	
        public string BranchCode { get; set; }
		public string RefNO { get; set; }
		public string ContainerNo { get; set; }
		public string ContainerType { get; set; }
		public string ContainerCode { get; set; }
		public string CarLicense { get; set; }
		public string CarProvince { get; set; }
		public string VesselName { get; set; }
		public string Voyage { get; set; }
		public string CompanyTaxNo { get; set; }
		public string CompanyCode { get; set; }
		public string CompanyBranch { get; set; }
		public string DepartureDate { get; set; }
		public string LoadPort { get; set; }
		public string ReleasePort { get; set; }
		public string TransportMode { get; set; }
		public string DischargePort { get; set; }
		public string SealNo1 { get; set; }
		public string SealNo2 { get; set; }
		public string SealNo3 { get; set; }
		public string UIDTransmit { get; set; }
		public string DateTransmit { get; set; }
		public string TimeTransmit { get; set; }
		public string RecByUser { get; set; }
		public string CancelReson { get; set; }
		public string CancelBy { get; set; }
		public string CancelProve { get; set; }
        public string SignBy { get; set; }
		public string FileToSend { get; set; }
		public string GoodCtlListNo { get; set; }
		public string RevisedReason { get; set; }
		public string RevisedCode { get; set; }
		public string TrailerLicense { get; set; }
		public string TrailerProvince { get; set; }
		public string PackingPort { get; set; }
		public string CarCountry { get; set; }
		public string TrailerCountry { get; set; }
		public string MovementMode { get; set; }
		public string eSealNo { get; set; }
		public string GPSID { get; set; }
		public string VGMWeight { get; set; }
		public string VGMAuthorizeName { get; set; }
		public string BookingNo { get; set; }
		public string VGMWeightUnit { get; set; }
		public string GoodsCargoType { get; set; }
		public string UNDGNumber { get; set; }
		public string IMOClass { get; set; }
		public string ContainerIndicator { get; set; }
		public string OperatorTaxNo { get; set; }
		public string OperatorBranch { get; set; }
		public string OperatorCode { get; set; }
		public string TransitPort { get; set; }
		public string FinalPort { get; set; }
		public string IsReeferDry { get; set; }
		public string ReeferTemp { get; set; }
		public string VentDesc { get; set; }
        public string VentUnit { get; set; }
        public string Overheight { get; set; }
        public string OverlengthFore { get; set; }
        public string OverlengthAfter { get; set; }
        public string OverwidthR { get; set; }
        public string OverwidthL { get; set; }
        public string Remark { get; set; }
		public DateTime AcceptDate { get; set; }
		public DateTime AcceptTime { get; set; }
		public DateTime RecDate { get; set; }
		public DateTime RecTime { get; set; }
		public DateTime SignDate { get; set; }
		public DateTime SignTime { get; set; }
        public DateTime CancelProveDate { get; set; }
		public DateTime CancelProveTime { get; set; }
		public DateTime CancelDate { get; set; }
		public DateTime CancelTime { get; set; }
		public DateTime SendDate { get; set; }
		public DateTime SendTime { get; set; }
		public int DocStatus { get; set; }
		public int DetailLine { get; set; }
		public int ResponseStatus { get; set; }
        public int SendStatus { get; set; }
		public int IsCancel { get; set; }
		public int Revised { get; set; }
		public int GoodCtlType { get; set; }

		public List<GoodCtl_Header> get()
		{
			var rows = new List<GoodCtl_Header>();
			using (Connection cn = new Connection())
			{
				using (var rd = cn.getDataReader("select * from " + tbname))
				{
					while (rd.Read())
					{
						rows.Add(new GoodCtl_Header()
						{
							oid = rd.GetInt32("oid"),
							BranchCode = rd.GetString("BranchCode"),
							RefNO = rd.GetString("RefNO"),
							ContainerNo = rd.GetString("ContainerNo"),
							ContainerType = rd.GetString("ContainerType"),
							ContainerCode = rd.GetString("ContainerCode"),
							CarLicense = rd.GetString("CarLicense"),
							CarProvince = rd.GetString("CarProvince"),
							VesselName = rd.GetString("VesselName"),
							Voyage = rd.GetString("Voyage"),
							CompanyTaxNo = rd.GetString("CompanyTaxNo"),
							CompanyCode = rd.GetString("CompanyCode"),
							CompanyBranch = rd.GetString("CompanyBranch"),
							DepartureDate = rd.GetString("DepartureDate"),
							LoadPort = rd.GetString("LoadPort"),
							ReleasePort = rd.GetString("ReleasePort"),
							TransportMode = rd.GetString("TransportMode"),
							DischargePort = rd.GetString("DischargePort"),
							SealNo1 = rd.GetString("SealNo1"),
							SealNo2 = rd.GetString("SealNo2"),
							SealNo3 = rd.GetString("SealNo3"),
							UIDTransmit = rd.GetString("UIDTransmit"),
							DateTransmit = rd.GetString("DateTransmit"),
							TimeTransmit = rd.GetString("TimeTransmit"),
							RecByUser = rd.GetString("RecByUser"),
							TrailerLicense = rd.GetString("TrailerLicense"),
							TrailerProvince = rd.GetString("TrailerProvince"),
							PackingPort = rd.GetString("PackingPort"),
							CarCountry = rd.GetString("CarCountry"),
							TrailerCountry = rd.GetString("TrailerCountry"),
							MovementMode = rd.GetString("MovementMode"),
							eSealNo = rd.GetString("eSealNo"),
							GPSID = rd.GetString("GPSID"),
							VGMWeight = rd.GetString("VGMWeight"),
							VGMAuthorizeName = rd.GetString("VGMAuthorizeName"),
							CancelReson = rd.GetString("CancelReson"),
							CancelBy = rd.GetString("CancelBy"),
							CancelProve = rd.GetString("CancelProve"),
							GoodCtlListNo = rd.GetString("GoodCtlListNo"),
							RevisedReason = rd.GetString("RevisedReason"),
							RevisedCode = rd.GetString("RevisedCode"),
							BookingNo = rd.GetString("BookingNo"),
							VGMWeightUnit = rd.GetString("VGMWeightUnit"),
							GoodsCargoType = rd.GetString("GoodsCargoType"),
							UNDGNumber = rd.GetString("UNDGNumber"),
							SignBy = rd.GetString("SignBy"),
							FileToSend = rd.GetString("FileToSend"),
							IMOClass = rd.GetString("IMOClass"),
							ContainerIndicator = rd.GetString("ContainerIndicator"),
							OperatorTaxNo = rd.GetString("OperatorTaxNo"),
							OperatorBranch = rd.GetString("OperatorBranch"),
							OperatorCode = rd.GetString("OperatorCode"),
							TransitPort = rd.GetString("TransitPort"),
							FinalPort = rd.GetString("FinalPort"),
							IsReeferDry = rd.GetString("IsReeferDry"),
							ReeferTemp = rd.GetString("ReeferTemp"),
							VentDesc = rd.GetString("VentDesc"),
                            VentUnit = rd.GetString("VentUnit"),
							Overheight = rd.GetString("Overheight"),
							OverlengthFore = rd.GetString("OverlengthFore"),
							OverlengthAfter = rd.GetString("OverlengthAfter"),
							OverwidthR = rd.GetString("OverwidthR"),
							Remark = rd.GetString("Remark"),
							OverwidthL = rd.GetString("OverwidthL"),

							AcceptDate = rd.GetDateTime("AcceptDate"),
							AcceptTime = rd.GetDateTime("AcceptTime"),
							RecDate = rd.GetDateTime("RecDate"),
							RecTime = rd.GetDateTime("RecTime"),
							SignDate = rd.GetDateTime("SignDate"),
							SignTime = rd.GetDateTime("SignTime"),
                            SendDate = rd.GetDateTime("SendDate"),
							SendTime = rd.GetDateTime("SendTime"),
							CancelProveDate = rd.GetDateTime("CancelProveDate"),
                            CancelProveTime = rd.GetDateTime("CancelProveTime"),

							DocStatus = rd.GetInt32("DocStatus"),
							DetailLine = rd.GetInt32("DetailLine"),
							ResponseStatus = rd.GetInt32("ResponseStatus"),
							IsCancel = rd.GetInt32("IsCancel"),
							Revised = rd.GetInt32("Revised"),
							GoodCtlType = rd.GetInt32("GoodCtlType"),
                            SendStatus = rd.GetInt32("SendStatus")					
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
						dr["BranchCode"] = this.BranchCode;
						dr["RefNO"] = this.RefNO;
						dr["ContainerNo"] = this.ContainerNo;
						dr["ContainerType"] = this.ContainerType;
						dr["ContainerCode"] = this.ContainerCode;
						dr["CarLicense"] = this.CarLicense;
						dr["CarProvince"] = this.CarProvince;
						dr["VesselName"] = this.VesselName;
						dr["Voyage"] = this.Voyage;
						dr["CompanyTaxNo"] = this.CompanyTaxNo;
						dr["CompanyCode"] = this.CompanyCode;
						dr["CompanyBranch"] = this.CompanyBranch;
						dr["DepartureDate"] = this.DepartureDate;
						dr["LoadPort"] = this.LoadPort;
						dr["ReleasePort"] = this.ReleasePort;
						dr["TransportMode"] = this.TransportMode;
						dr["DischargePort"] = this.DischargePort;
						dr["SealNo1"] = this.SealNo1;
						dr["SealNo2"] = this.SealNo2;
						dr["SealNo3"] = this.SealNo3;
						dr["UIDTransmit"] = this.UIDTransmit;
						dr["DateTransmit"] = this.DateTransmit;
						dr["TimeTransmit"] = this.TimeTransmit;
						dr["RecByUser"] = this.RecByUser;
						dr["CancelReson"] = this.CancelReson;
						dr["CancelBy"] = this.CancelBy;
						dr["CancelProve"] = this.CancelProve;
						dr["GoodCtlListNo"] = this.GoodCtlListNo;
						dr["RevisedReason"] = this.RevisedReason;
						dr["RevisedCode"] = this.RevisedCode;
						dr["TrailerLicense"] = this.TrailerLicense;
						dr["TrailerProvince"] = this.TrailerProvince;
						dr["PackingPort"] = this.PackingPort;
						dr["CarCountry"] = this.CarCountry;
						dr["TrailerCountry"] = this.TrailerCountry;
						dr["MovementMode"] = this.MovementMode;
						dr["eSealNo"] = this.eSealNo;
						dr["GPSID"] = this.GPSID;
						dr["VGMWeight"] = this.VGMWeight;
						dr["VGMAuthorizeName"] = this.VGMAuthorizeName;
						dr["BookingNo"] = this.BookingNo;
						dr["VGMWeightUnit"] = this.VGMWeightUnit;
						dr["GoodsCargoType"] = this.GoodsCargoType;
						dr["UNDGNumber"] = this.UNDGNumber;
						dr["SignBy"] = this.SignBy;
						dr["FileToSend"] = this.FileToSend;
						dr["IMOClass"] = this.IMOClass;
						dr["ContainerIndicator"] = this.ContainerIndicator;
						dr["OperatorTaxNo"] = this.OperatorTaxNo;
						dr["OperatorBranch"] = this.OperatorBranch;
						dr["OperatorCode"] = this.OperatorCode;
						dr["TransitPort"] = this.TransitPort;
						dr["FinalPort"] = this.FinalPort;
						dr["IsReeferDry"] = this.IsReeferDry;
						dr["ReeferTemp"] = this.ReeferTemp;
						dr["VentDesc"] = this.VentDesc;
						dr["VentUnit"] = this.VentUnit;
						dr["Overheight"] = this.Overheight;
						dr["OverlengthFore"] = this.OverlengthFore;
						dr["OverlengthAfter"] = this.OverlengthAfter;
						dr["OverwidthR"] = this.OverwidthR;
						dr["Remark"] = this.Remark;
						dr["OverwidthL"] = this.OverwidthL;

						dr["SendStatus"] = this.SendStatus;
						dr["DocStatus"] = this.DocStatus;
						dr["DetailLine"] = this.DetailLine;
						dr["ResponseStatus"] = this.ResponseStatus;
						dr["IsCancel"] = this.IsCancel;
						dr["Revised"] = this.Revised;
						dr["GoodCtlType"] = this.GoodCtlType;

						dr["AcceptDate"] = this.AcceptDate;
						dr["AcceptTime"] = this.AcceptTime;
						dr["RecDate"] = this.RecDate;
						dr["RecTime"] = this.RecTime;
						dr["SignDate"] = this.SignDate;
						dr["SignTime"] = this.SignTime;
                        dr["SendDate"] = this.SendDate;
						dr["AcceptDate"] = this.AcceptDate;
						dr["SendTime"] = this.SendTime;
						dr["AcceptTime"] = this.AcceptTime;
						dr["CancelProveDate"] = this.CancelProveDate;
						dr["CancelProveTime"] = this.CancelProveTime;

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