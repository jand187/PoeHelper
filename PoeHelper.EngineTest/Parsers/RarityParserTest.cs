using System;
using System.Linq;
using FluentAssertions;
using PoeHelper.Engine.Models;
using PoeHelper.Engine.Parsers;
using Xunit.Extensions;

namespace PoeHelper.EngineTest.Parsers
{
	public class RarityParserTest
	{
		[Theory]
		[InlineData("Rarity: Normal\r\nSuperior Citadel Bow\r\n--------", ItemRarity.Normal)]
		[InlineData("Rarity: Magic\r\nWizard's Copper Kris of Mastery\r\n--------", ItemRarity.Magic)]
		[InlineData("Rarity: Rare\r\nDoom Suit\r\nSharkskin Tunic\r\n--------", ItemRarity.Rare)]
		[InlineData("Rarity: Unique\r\nChin Sol\r\nMaraketh Bow\r\n--------", ItemRarity.Unique)]
		[InlineData("Rarity: Currency\r\nBlacksmith's Whetstone\r\n--------", ItemRarity.Currency)]
		[InlineData("Rarity: Gem\r\nSlower Projectiles", ItemRarity.Gem)]
		public void Should_parse_rarities(string text, ItemRarity expectedRarity)
		{
			var lines = text.Split(new[] {Environment.NewLine}, StringSplitOptions.None).ToList();

			var itemRarity = new ItemRarityParser().Parse(lines);

			itemRarity.Should().Be(expectedRarity);
		}
	}
}
