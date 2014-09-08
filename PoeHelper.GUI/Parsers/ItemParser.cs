using System;
using System.Collections.Generic;
using System.Linq;
using PoeHelper.GUI.Model;
using PoeHelper.GUI.Parsers.Mods;

namespace PoeHelper.GUI.Parsers
{
	public class ItemParser
	{
		private readonly IEnumerable<IParser<PoeItem>> parsers;

		public ItemParser()
		{
			parsers = new IParser<PoeItem>[]
			{
				new PhysicalDamagaParser(),
				new ElementalDamageParser(),
				new AttackSpeedParser(),
				new ItemLevelParser(),
				new IncreasedDamageModParser(), 
				new IncreasedDamageWithWeaponsModParser(), 
				new IncreasedResistanceModParser(), 
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
