using System;
using System.Text.RegularExpressions;
using PoeHelper.GUI.Model;

namespace PoeHelper.GUI.Parsers
{
	public class ElementalDamageParser : IParser<PoeItem>
	{
		public bool CanParse(string line)
		{
			return Regex.Match(line, @"^Elemental Damage: (\d+)-(\d+)").Success;
		}

		public PoeItem Parse(string line, PoeItem target)
		{
			var matches = Regex.Matches(line, @" ((\d+)-(\d+))");

			for (var index = 0; index < matches.Count; index++)
			{
				var match = matches[index];
				target.AddDamageType(new DamageType
				{
					Type = "Elemental",
					Low = Convert.ToDecimal(match.Groups[2].Value),
					High = Convert.ToDecimal(match.Groups[3].Value),
				});
			}

			return target;
		}
	}
}