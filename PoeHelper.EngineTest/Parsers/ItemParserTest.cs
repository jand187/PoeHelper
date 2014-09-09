using FluentAssertions;
using PoeHelper.Engine.Models;
using PoeHelper.Engine.Parsers;
using Xunit;

namespace PoeHelper.EngineTest.Parsers
{
	public class ItemParserTest
	{
		[Fact]
		public void Should_parse_magic_rarity()
		{
			var target = new ItemParser();
			var text = "Rarity: Magic\r\nWizard's Copper Kris of Mastery\r\n--------";

			var item = target.Parse(text);

			item.Rarity.Should().Be(ItemRarity.Magic);
		}
	}
}
