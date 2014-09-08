using System;
using System.Text.RegularExpressions;
using PoeHelper.GUI.Model;

namespace PoeHelper.GUI.Parsers.Mods
{
	public class IncreasedPercentagePropertyModParser : IParser<PoeItem>
	{
		private readonly IModDatabase modDatabase;
		private readonly string pattern;

		public IncreasedPercentagePropertyModParser(IModDatabase modDatabase)
		{
			this.modDatabase = modDatabase;
			pattern = @"(\d+)% increased ([\w ]+)";
		}

		public bool CanParse(string line)
		{
			return Regex.Match(line, pattern).Success;
		}

		public PoeItem Parse(string line, PoeItem target)
		{
			var match = Regex.Match(line, pattern);
			var amount = Convert.ToInt32(match.Groups[1].Value);
			var name = match.Groups[2].Value;
			target.AddMod(
				new ModType
				{
					Amount = amount,
					Name = name,
					ModRequiredLevel = modDatabase.GetLevel(amount, string.Format("% increased {0}", name)),
					DisplayText = m => string.Format("{0}% increased {1} ({2})", m.Amount, m.Name, m.ModRequiredLevel),
				});

			return target;
		}
	}
}
