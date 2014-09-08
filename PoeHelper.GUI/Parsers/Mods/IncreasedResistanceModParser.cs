using System;
using System.Text.RegularExpressions;
using PoeHelper.GUI.Model;

namespace PoeHelper.GUI.Parsers.Mods
{
	public class IncreasedResistanceModParser : IParser<PoeItem>
	{
		private readonly string pattern;

		public IncreasedResistanceModParser()
		{
			pattern = @"\+(\d+)% to ([\w ]+) Resistance$";
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
					Name = match.Groups[2].Value,
					DisplayText = (m) => string.Format("+{0}% to {1} Resistance", m.Amount, m.Name),
				});
			target.ItemLevel = Convert.ToInt32(match.Groups[1].Value);
			return target;
		}
	}
}
