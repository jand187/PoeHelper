using System;
using System.Text.RegularExpressions;
using PoeHelper.GUI.Model;

namespace PoeHelper.GUI.Parsers.Mods
{
	public class IncreasedDamageModParser : IParser<PoeItem>
	{
		private readonly string pattern;

		public IncreasedDamageModParser()
		{
			pattern = @"(\d+)% increased ([\w ]+) Damage$";
		}

		public bool CanParse(string line)
		{
			return Regex.Match(line, pattern).Success;
		}

		public PoeItem Parse(string line, PoeItem target)
		{
			var match = Regex.Match(line, pattern);
			target.AddMod(
				new ModType
				{
					Amount = Convert.ToInt32(match.Groups[1].Value),
					Name = match.Groups[2].Value.TrimEnd(),
					DisplayText = (m) => string.Format("{0}% increased {1} Damage", m.Amount, m.Name),
				}
				);
			target.ItemLevel = Convert.ToInt32(match.Groups[1].Value);
			return target;
		}
	}
}
