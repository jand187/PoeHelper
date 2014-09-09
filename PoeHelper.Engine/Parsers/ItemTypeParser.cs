using System;
using System.Collections.Generic;
using System.Linq;
using PoeHelper.Engine.Models;

namespace PoeHelper.Engine.Parsers
{
	public class ItemTypeParser
	{
		private readonly IEnumerable<ItemDefinition> itemDefinitions;
		private readonly IItemRarityParser itemRarityParser;

		public ItemTypeParser(IEnumerable<ItemDefinition> itemDefinitions, IItemRarityParser itemRarityParser)
		{
			this.itemDefinitions = itemDefinitions;
			this.itemRarityParser = itemRarityParser;
		}

		public ItemType Parse(IEnumerable<string> lines)
		{
			var itemRarity = itemRarityParser.Parse(lines);

			if (itemRarity == ItemRarity.Gem)
				return ItemType.SkillGem;

			if (itemRarity == ItemRarity.Currency)
				return ItemType.Currency;

			var index = GetItemTypeLineIndex(itemRarity);

			return GetItemDefinition(lines.Skip(index).First()).ItemType;
		}

		private ItemDefinition GetItemDefinition(string line)
		{
			foreach (var itemDefinition in itemDefinitions)
			{
				foreach (var itemSubType in itemDefinition.ItemSubTypes)
				{
					if (line.Contains(itemSubType.Name))
						return itemDefinition;
				}
			}

			throw new ItemDefinitionNotFoundException(string.Format("Parsing line '{0}', didn't result in a match", line));
		}

		private static int GetItemTypeLineIndex(ItemRarity itemRarity)
		{
			switch (itemRarity)
			{
				case ItemRarity.Normal:
				case ItemRarity.Magic:
				case ItemRarity.Gem:
				case ItemRarity.Currency:
					return 1;

				case ItemRarity.Rare:
				case ItemRarity.Unique:
					return 2;
			}

			return -1;
		}
	}

	public class ItemDefinitionNotFoundException : Exception
	{
		public ItemDefinitionNotFoundException(string message) : base(message)
		{
		}
	}
}
