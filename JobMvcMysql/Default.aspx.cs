using System;
using MySql.Data.MySqlClient;
namespace JobMvcMysql
{

	public partial class Default : System.Web.UI.Page
	{
		public void button1Clicked(object sender, EventArgs args)
		{
			try
			{
				using (MySqlConnection cn = new MySqlConnection("server=182.50.133.78;uid=mvc_test;pwd=test_mvc;database=mvc_test;port=3306;"))
				{
					cn.Open();
					label1.Text = "Connected!";
					Response.Redirect("/CustomsFile");
				}
			}
			catch (Exception e)
			{
				label1.Text = e.Message;
			}

		}
	}
}
