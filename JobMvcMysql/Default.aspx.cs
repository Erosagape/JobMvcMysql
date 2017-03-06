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
				using (Connection cn=new Connection())
				{
					if (cn.State == true)
					{
						Response.Redirect("/CustomsFile/Country");
					}
				}
			}
			catch (Exception e)
			{
				label1.Text = e.Message;
			}

		}
	}
}
