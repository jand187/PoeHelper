using System;
using System.Text.RegularExpressions;
using PoeHelper.GUI.Model;

namespace PoeHelper.GUI.Parsers.Mods
{
	public class IncreasedDamageModParser : IParser<PoeItem>
	{
		private readonly IModDatabase modDatabase;
		private readonly string pattern;

		public IncreasedDamageModParser(IModDatabase modDatabase)
		{
			this.modDatabase = modDatabase;
			pattern = @"(\d+)% increased ([\w ]+) Damage$";
		}

		public bool CanParse(string line)
		{
			return Regex.Match(line, pattern).Success;
		}

		public PoeItem Parse(string line, PoeItem target)
		{
			var match = Regex.Match(line, pattern);
			var amount = Convert.ToInt32(match.Groups[1].Value);
			var name = match.Groups[2].Value.TrimEnd();
			target.AddMod(
				new ModType
				{
					Amount = amount,
					Name = name,
					ModRequiredLevel = modDatabase.GetLevel(amount, string.Format("% increased {0} Damage", name)),
					DisplayText = m => string.Format("{0}% increased {1} Damage ({2})*", m.Amount, m.Name, m.ModRequiredLevel),
				});

			return target;
		}
	}
}
