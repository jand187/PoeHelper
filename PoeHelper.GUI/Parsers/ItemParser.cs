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
			//var modDefinitions = new[]
			//{
			//	new ModDefinition
			//	{
			//		Name = "% increased Fire Damage",
			//		Tiers = new[]
			//		{
			//			new ModTier
			//			{
			//				RequiredLevel = 76,
			//				DamageRange = new ValueRange
			//				{
			//					Min = 27,
			//					Max = 30,
			//				}
			//			},
			//			new ModTier
			//			{
			//				RequiredLevel = 64,
			//				DamageRange = new ValueRange
			//				{
			//					Min = 23,
			//					Max = 26,
			//				}
			//			},
			//			new ModTier
			//			{
			//				RequiredLevel = 50,
			//				DamageRange = new ValueRange
			//				{
			//					Min = 18,
			//					Max = 22,
			//				}
			//			},
			//			new ModTier
			//			{
			//				RequiredLevel = 36,
			//				DamageRange = new ValueRange
			//				{
			//					Min = 13,
			//					Max = 17,
			//				}
			//			},
			//			new ModTier
			//			{
			//				RequiredLevel = 22,
			//				DamageRange = new ValueRange
			//				{
			//					Min = 8,
			//					Max = 12,
			//				}
			//			},
			//			new ModTier
			//			{
			//				RequiredLevel = 8,
			//				DamageRange = new ValueRange
			//				{
			//					Min = 3,
			//					Max = 7,
			//				}
			//			},
			//		}
			//	}
			//};


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
