using System;
using System.Linq;
using PoeHelper.Engine.Models;

namespace PoeHelper.Engine.Parsers
{
	internal class ItemParser
	{
		private readonly IItemRarityParser itemRarityParser;
		private readonly ItemTypeParser itemTypeParser;
		private readonly IParser<Item, object>[] parsers;

		public ItemParser()
		{
			itemRarityParser = new ItemRarityParser();
			itemTypeParser = new ItemTypeParser(new ItemDefinition[0], itemRarityParser);
			parsers = new IParser<Item, object>[]
			{
			};
		}

		public Item Parse(string text)
		{
			var lines = text.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

			var itemRarity = itemRarityParser.Parse(lines);
			var item = new Item
			{
				Rarity = itemRarity,
				ItemType = itemTypeParser.Parse(lines)
			};

			foreach (var parser in parsers)
			{
				var changes = parser.Parse(lines);
				changes.ToList().ForEach(c => c.Invoke(item));
			}

			return item;
		}
	}
}
