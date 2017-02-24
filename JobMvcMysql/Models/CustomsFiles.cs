using System;
namespace JobMvcMysql
{
	public class Currency
	{
		public int oid { get; set; }
		public string currencyCode { get; set; }
		public string currencyName { get; set; }
		public string countryCode { get; set; }
	}
	public class Country
	{
		public int oid { get; set; }
		public string countryCode { get; set; }
		public string countryName { get; set; }
	}
}
