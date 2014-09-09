using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using PoeHelper.Engine.Models;

namespace PoeHelper.Engine.Parsers
{
	public interface IItemRarityParser
	{
		ItemRarity Parse(IEnumerable<string> lines);
	}

	public class ItemRarityParser : IItemRarityParser
	{
		public ItemRarity Parse(IEnumerable<string> lines)
		{
			var regex = new Regex(@"Rarity: (\w+)");

			foreach (var line in lines)
			{
				var match = regex.Match(line);
				if (match.Success)
					return (ItemRarity) Enum.Parse(typeof (ItemRarity), match.Groups[1].Value);
			}

			return ItemRarity.Unknown;
		}
	}

	//public class ItemRarityParser : IParser<Item, object>
	//{
	//	public IEnumerable<Func<Item, object>> Parse(IEnumerable<string> lines)
	//	{
	//		var regex = new Regex(@"Rarity: (\w+)");

	//		foreach (var line in lines)
	//		{
	//			var match = regex.Match(line);
	//			if (!match.Success)
	//				continue;

	//			var value = match.Groups[1].Value;
	//			var rarity = (ItemRarity) Enum.Parse(typeof (ItemRarity), value);
	//			yield return item => item.Rarity = rarity;
	//			//yield return new Func<Item, object>[] {item => item.Rarity = rarity};
	//		}
	//	}
	//}
}
