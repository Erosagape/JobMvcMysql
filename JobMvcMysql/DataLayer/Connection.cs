using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
namespace JobMvcMysql
{
	public class Connection : IDisposable
	{
		public string Message { get; set; }
		public bool State { get; set; }
		private readonly MySqlConnection cn;
		public Connection()
		{
			State = false;
			try
			{
				cn = new MySqlConnection("server=182.50.133.78;uid=mvc_test;pwd=test_mvc;database=mvc_test;port=3306;");
				cn.Open();
				State = true;
			}
			catch (Exception e)
			{
				Message = e.Message;
			}
		}
		public List<Country> getCountry_all()
		{
			MySqlDataReader rd = new MySqlCommand("select * from Country", cn).ExecuteReader();
			List<Country> rows = new List<Country>();
			while (rd.Read())
			{
				rows.Add(new Country() 
				{
					oid=rd.GetInt32("oid"),
					countryCode =rd.GetString("countryCode"),
					countryName =rd.GetString("countryName")
				});
			}
			return rows;
		}
		public void Close()
		{
			if(cn.State.Equals(ConnectionState.Open)) cn.Close(); 
			this.Dispose();
		}

		public void Dispose()
		{
			cn.Dispose();
		}
	}
}
