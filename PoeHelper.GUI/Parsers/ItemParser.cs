using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using PoeHelper.GUI.Model;
using PoeHelper.GUI.Parsers.Mods;

namespace PoeHelper.GUI.Parsers
{
	public class ItemParser
	{
		private readonly IEnumerable<IParser<PoeItem>> parsers;

		public ItemParser()
		{
			var modDefinitionsFile = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Data\ModDefinitions.json"));

			var modDefinitions = JsonConvert.DeserializeObject<IEnumerable<ModDefinition>>(modDefinitionsFile);

			//var modDefs = JsonConvert.SerializeObject(modDefinitions);

			parsers = new IParser<PoeItem>[]
			{
				new PhysicalDamagaParser(),
				new ElementalDamageParser(),
				new AttackSpeedParser(),
				new ItemLevelParser(),
				new IncreasedDamageModParser(modDefinitions), 
				new IncreasedDamageWithWeaponsModParser(), 
				new IncreasedResistanceModParser(modDefinitions), 
			};
		}

		public string Parse(string text)
		{
			var lines = text.Split(new[] {Environment.NewLine}, StringSplitOptions.None).ToList();

			var item = new PoeItem();

			lines.ForEach(l => parsers
				.Where(p => p.CanParse(l))
				.ToList()
				.ForEach(p => p.Parse(l, item)));

			return item.Report();
		}
	}
}
