using Microsoft.Extensions.Configuration;

namespace DataAccess.Tools
{
	public static class Connection
	{
		public static string GetConnection
		{
			get
			{
				ConfigurationManager configurationManager = new();
				configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebAPI"));
				configurationManager.AddJsonFile("appsettings.json");
				return configurationManager.GetConnectionString("SqlServer");
			}
		}
	}
}
