using System;
using System.IO;
using Newtonsoft.Json;

namespace DoorServer
{
	public class ConfigModel
	{
		public string ConnectionString { get; set; }
	}

	public static class Configuration
	{
		public static ConfigModel Config;

		public static void Configure()
		{
			var file = Path.Combine(AppContext.BaseDirectory, "_config.json");

			if (!File.Exists(file))
				throw new ApplicationException(
					"Unable to locate the configuration file, Please create a new one named \"_config.json\"");

			Config = JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText(file));
		}
	}
}