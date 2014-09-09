using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using PoeHelper.Engine.Models;
using PoeHelper.Engine.Parsers;
using Xunit.Extensions;

namespace PoeHelper.EngineTest.Parsers
{
	public class ItemTypeParserTest
	{
		private readonly IItemRarityParser itemRarityParser;
		private readonly ItemDefinition[] wandDefinitions;

		public ItemTypeParserTest()
		{
			itemRarityParser = Substitute.For<IItemRarityParser>();
			wandDefinitions = new[]
			{
				new ItemDefinition
				{
					ItemType = ItemType.Wand,
					ItemSubTypes = new[]
					{
						new ItemSubType {Name = "Driftwood Wand"},
						new ItemSubType {Name = "Goat's Horn"},
						new ItemSubType {Name = "Carved Wand"},
						new ItemSubType {Name = "Quartz Wand"},
						new ItemSubType {Name = "Spiraled Wand"},
						new ItemSubType {Name = "Sage Wand"},
						new ItemSubType {Name = "Faun's Horn"},
						new ItemSubType {Name = "Engraved Wand"},
						new ItemSubType {Name = "Crystal Wand"},
						new ItemSubType {Name = "Serpent Wand"},
						new ItemSubType {Name = "Omen Wand"},
						new ItemSubType {Name = "Demon's Horn"},
						new ItemSubType {Name = "Imbued Wand"},
						new ItemSubType {Name = "Opal Wand"},
						new ItemSubType {Name = "Tornado Wand"},
						new ItemSubType {Name = "Prophecy Wand"}
					}
				}
			};
		}

		[Theory]
		[InlineData(new[] {"Rarity: Normal", "Engraved Wand", "--------"}, ItemRarity.Normal, ItemType.Wand)]
		[InlineData(new[] {"Rarity: Magic", "Buzzing Goat's Horn", "--------"}, ItemRarity.Magic, ItemType.Wand)]
		[InlineData(new[] {"Rarity: Rare", "Maelström Thirst", "Imbued Wand", "--------"}, ItemRarity.Rare, ItemType.Wand)]
		[InlineData(new[] {"Rarity: Unique", "Moonsorrow", "Imbued Wand", "--------"}, ItemRarity.Unique, ItemType.Wand)]
		public void Should_parse_all_rarities(IEnumerable<string> lines, ItemRarity itemRarity, ItemType expectedItemType)
		{
			itemRarityParser.Parse(Arg.Any<IEnumerable<string>>()).Returns(itemRarity);

			var target = new ItemTypeParser(wandDefinitions, itemRarityParser);

			target.Parse(lines).Should().Be(expectedItemType);
		}
	}
}
