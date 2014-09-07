using System;
using System.Text.RegularExpressions;
using PoeHelper.GUI.Model;

namespace PoeHelper.GUI.Parsers
{
	public class ItemLevelParser : IParser<PoeItem>
	{
		public bool CanParse(string line)
		{
			return Regex.Match(line, @"^Itemlevel: (\d+)").Success;
		}

		public PoeItem Parse(string line, PoeItem target)
		{
			var match = Regex.Match(line, @"^Itemlevel: (\d+)");
			target.ItemLevel = Convert.ToInt32(match.Groups[1].Value);
			return target;
		}
	}
}
